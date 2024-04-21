using System;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telestream.Models;
using Telestream.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Telestream.Models.Entities;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Telnyx;
using Telestream.Helpers;

namespace Telestream.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;
        private const int API_KEY_INDEX = 1;
        private const int PHONE_NUMBER_INDEX = 2;
        private const int WEB_HOOK_URL_INDEX = 3;

        public HomeController(ApplicationDbContext dbContext, ILogger<HomeController> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/recent")]
        public IActionResult GetRecentSMS(string searchKey) {
            if (searchKey == null) {
                searchKey = "";
            }
            List<SMS> recentSMSes = _dbContext.SMSes.Where(item => item.sent == false && ( item.from.Contains(searchKey) || item.content.Contains(searchKey) || item.contact.Contains(searchKey))).ToList();
            int nUnread = recentSMSes.Where(item => item.read == false).GroupBy(item => item.from).Count();

            List<SMS> recentSMS = recentSMSes
                                    .GroupBy(m => m.from)
                                    .Select(g => g.OrderByDescending(n => n.createdAt).First())
                                    .ToList();

            return Json(new { recentSMS, nUnread });
        }

        [HttpPost("/sms/read")]
        public IActionResult MarkAsRead(int id) {
            SMS currentSMS = _dbContext.SMSes.FirstOrDefault(item => item.id == id);
            if (currentSMS != null) {
                currentSMS.read = true;
                _dbContext.SaveChanges();
            }
            return Ok();
        }

        [HttpPost("/sms/send")]
        public async Task<IActionResult> SendSMS(string contact, string phoneNumber, string message, int currentIdx) {
            List<string> phoneNumbers = GetPhoneNumbers();
            int phoneIdx = currentIdx % phoneNumbers.Count;
            string from = phoneNumbers.ElementAt(phoneIdx);
            from = Global.GetValidPhoneNumber(from);
            string to = Global.GetValidPhoneNumber(phoneNumber);
            
            TelnyxConfiguration.SetApiKey(GetApiKey());
            MessagingSenderIdService service = new MessagingSenderIdService();
            NewMessagingSenderId options = new NewMessagingSenderId
            {
                From = from,
                To = to,
                Text = message,
                WebhookUrl = GetWebHookUrl(),
                UseProfileWebhooks = false,
            };
            Console.WriteLine(GetWebHookUrl());

            string messageId = "";
            try {
                MessagingSenderId messageResponse = await service.CreateAsync(options);
                messageId = messageResponse.Id.ToString();
            } catch(Exception ex) {
                Console.Write(ex.Message);
            }


            SMS newSms = new SMS() {
                from = from,
                to = to,
                contact = contact,
                content = message,
                createdAt = DateTime.Now,
                messageId = messageId,
                sent = true
            };
            _dbContext.Add(newSms);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("/sms")]
        public int DeleteSms(int id) {
            SMS currentSms = _dbContext.SMSes.FirstOrDefault(item => item.id == id);
            if (currentSms != null) {
                _dbContext.SMSes.Remove(currentSms);
                _dbContext.SaveChanges();
            }
            return id;
        }

        [HttpGet("/campaign")]
        public IActionResult Campaign()
        {
            List<ContactList> contactLists = _dbContext.ContactLists.ToList();
            return View(contactLists);
        }

        [HttpGet("/inbox")]
        public IActionResult Inbox()
        {
            List<ContactDetailViewModel> contactLists = _dbContext.SMSes
                .Select(c => new ContactDetailViewModel
                {
                    name = c.contact,
                    phoneNumber = c.sent == true ? c.to : c.from,
                })
                .ToList()
                .GroupBy(b=> new { b.phoneNumber }, (key, g) => g.First())
                .ToList();
            return View(contactLists);
        }

        [HttpGet("/message_list")]
        public IActionResult MessageList(string phoneNumber)
        {
            phoneNumber = Global.GetValidPhoneNumber(phoneNumber);
            List<SMS> messages = _dbContext.SMSes
                .Where(item => item.from == phoneNumber || item.to == phoneNumber)
                .ToList();

            return Json(new {messages});
        }

        [HttpDelete("/message_list")]
        public string DeleteMessages(string phoneNumber) {
            List<SMS> messages = _dbContext.SMSes
                .Where(item => item.from.Equals(phoneNumber) || item.to.Equals(phoneNumber))
                .ToList();

            foreach(SMS message in messages) {
                _dbContext.SMSes.Remove(message);
            }
            _dbContext.SaveChanges();
            return phoneNumber;
        }

        [HttpPost("/clear_all")]
        public string ClearAllMessages()
        {
            List<SMS> messages = _dbContext.SMSes.ToList();
            foreach (SMS message in messages)
            {
                _dbContext.SMSes.Remove(message);
            }
            _dbContext.SaveChanges();

            return "Success";
        }

        [HttpGet("/contact_list")]
        public IActionResult ContactList()
        {
            List<ContactList> allContactLists = _dbContext.ContactLists.ToList();
            return View(allContactLists);
        }

        [HttpPost("/contact_list")]
        public async Task<IActionResult> UploadContactList(IFormFile contactListFile)
        {
            if (contactListFile != null && contactListFile.Length > 0)
            {
                string orgFileName = Path.GetFileNameWithoutExtension(contactListFile.FileName);
                string fileExtension = Path.GetExtension(contactListFile.FileName);
                string fileName = orgFileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".csv";
                orgFileName = orgFileName + fileExtension;
                string fullPath = Path.Combine(Path.GetFullPath("./wwwroot"), "uploads", fileName);
                using (var stream = System.IO.File.Create(fullPath))
                {
                    await contactListFile.CopyToAsync(stream);
                }

                ContactList newContactList = new ContactList() {
                    fileName = fileName,
                    displayName = orgFileName,
                    uploadedAt = DateTime.Now
                };
                _dbContext.Add(newContactList);
                _dbContext.SaveChanges();
            }

            return RedirectToAction(nameof(ContactList));
        }

        [HttpDelete("/contact_list")]
        public int DeleteContactList(int id) {
            ContactList currentContactList = _dbContext.ContactLists.FirstOrDefault(item => item.id == id);
            if (currentContactList != null) {
                string fullPath = Path.Combine(Path.GetFullPath("./wwwroot"), "uploads", currentContactList.fileName);
                System.IO.File.Delete(fullPath);
                _dbContext.ContactLists.Remove(currentContactList);
                _dbContext.SaveChanges();
            }
            return id;
        }

        [HttpGet("/settings")]
        public IActionResult Settings()
        {
            string apiKey = GetApiKey();
            List<string> phoneNumbers = GetPhoneNumbers();
            string webhookUrl = GetWebHookUrl();

            SettingViewModel settingViewModel = new SettingViewModel() {
                apiKey = apiKey,
                phoneNumbers = phoneNumbers,
                webhookUrl = webhookUrl
            };

            return View(settingViewModel);
        }

        [HttpPost("/settings")]
        public IActionResult UpdateSettings(SettingViewModel settings) {
            // var api_key = Request.Form["api_key"];
            // var phone_number = Request.Form["phone_number"];
            
            // Setting apiSetting = (select setting from _dbContext.Settings where setting.type == API_KEY_INDEX select setting).first();
            Setting apiSetting = _dbContext.Settings.FirstOrDefault(setting => setting.type == API_KEY_INDEX);
            Setting webhookSetting = _dbContext.Settings.FirstOrDefault(setting => setting.type == WEB_HOOK_URL_INDEX);
            if (apiSetting == null) {
                apiSetting = new Setting(){
                    type = API_KEY_INDEX,
                    value = settings.apiKey
                };
                _dbContext.Settings.Add(apiSetting);
            } else {
                apiSetting.value = settings.apiKey;
            }
            List<Setting> phonenumbersSetting = _dbContext.Settings.Where(setting => setting.type == PHONE_NUMBER_INDEX).ToList();
            _dbContext.Settings.RemoveRange(phonenumbersSetting);
            settings.phoneNumbers.ForEach(phoneNumber =>
            {
                Setting phonenumberSetting = new Setting()
                {
                    type = PHONE_NUMBER_INDEX,
                    value = phoneNumber
                };
                _dbContext.Settings.Add(phonenumberSetting);
            });

            if (webhookSetting == null) {
                webhookSetting = new Setting(){
                    type = WEB_HOOK_URL_INDEX,
                    value = settings.webhookUrl
                };
                _dbContext.Settings.Add(webhookSetting);
            } else {
                webhookSetting.value = settings.webhookUrl;
            }

            _dbContext.SaveChanges();

            return Ok();
        }
        
        private string GetApiKey() {
            Setting apikeySetting = _dbContext.Settings.FirstOrDefault(setting => setting.type == API_KEY_INDEX);
            if (apikeySetting == null) {
                return "";
            } else {
                return apikeySetting.value;
            }
        }
        private List<string> GetPhoneNumbers() {
            List<string> phonenmbers= _dbContext.Settings
                .Where(setting => setting.type == PHONE_NUMBER_INDEX)
                .Select(s => s.value)
                .ToList();
            return phonenmbers;
        }
        
        private string GetWebHookUrl() {
            Setting webhookUrlSetting = _dbContext.Settings.FirstOrDefault(setting => setting.type == WEB_HOOK_URL_INDEX);
            if (webhookUrlSetting == null) {
                return "";
            } else {
                return webhookUrlSetting.value;
            }
        }
        
        [HttpGet("/error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("/status-code")]
        public IActionResult StatusCodeHandler(int code)
        {
            ViewBag.StatusCode = code;
            ViewBag.StatusCodeDescription = ReasonPhrases.GetReasonPhrase(code);
            ViewBag.OriginalUrl = null;


            var statusCodeReExecuteFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            if (statusCodeReExecuteFeature != null)
            {
                ViewBag.OriginalUrl =
                    statusCodeReExecuteFeature.OriginalPathBase
                    + statusCodeReExecuteFeature.OriginalPath
                    + statusCodeReExecuteFeature.OriginalQueryString;
            }

            if (code == 404)
            {
                return View("Status404");
            }

            return View("Status4xx");
        }
    }
}
