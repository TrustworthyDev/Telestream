using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telestream.Models;
using Telestream.Models.Entities;
using System.Linq;
using Telestream.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Telestream.Controllers
{
    [ApiController]
    [Route("messaging/[controller]")]
    public class OutboundController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHubContext<NotificationHub> _notificationHubContext;
                
        public OutboundController(IHubContext<NotificationHub> notificationHubContext, ApplicationDbContext dbContext)
        {
            _notificationHubContext = notificationHubContext;
            _dbContext = dbContext;
        }
        // POST messaging/Outbound  - Delivery Receipts
        [HttpPost]
        [Consumes("application/json")]
        public async Task<string> MessageDLRCallback()
        {
            dynamic webhook = await WebhookHelpers.deserializeCallbackToDynamic(this.Request);
            string messageId = webhook.data.payload.id.ToString();
            SMS currentSms = _dbContext.SMSes.FirstOrDefault(item => item.messageId == messageId);
            if (currentSms != null) {
                if (currentSms.successed == false) {
                    currentSms.successed = true;
                    _dbContext.SaveChanges();
                    await _notificationHubContext.Clients.All.SendAsync("DLRCallback", currentSms);
                    Console.WriteLine($"Received DLR for message with ID: {webhook.data.payload.id}");
                }
            }
            return "";
        }
    }
}