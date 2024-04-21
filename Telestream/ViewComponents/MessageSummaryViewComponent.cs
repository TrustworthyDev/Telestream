using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telestream.Models;
using Telestream.Models.ViewModel;
using System;

namespace Telestream.ViewComponents
{
    public class MessageSummaryViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public MessageSummaryViewComponent(ApplicationDbContext context)
        {
            db = context;
        }

        public IViewComponentResult Invoke()
        {
            DateTime today = DateTime.Now;

            int nMonthSent = db.SMSes.Where(sms => sms.sent == true && sms.createdAt.Year == today.Year && sms.createdAt.Month == today.Month).Count();
            int nMonthRecived = db.SMSes.Where(sms => sms.sent == false && sms.createdAt.Year == today.Year && sms.createdAt.Month == today.Month).Count();
            int nTodaySent = db.SMSes.Where(sms => sms.sent == true && sms.createdAt.Year == today.Year && sms.createdAt.Month == today.Month && sms.createdAt.Date == today.Date).Count();
            int nTodayRecived = db.SMSes.Where(sms => sms.sent == false && sms.createdAt.Year == today.Year && sms.createdAt.Month == today.Month && sms.createdAt.Date == today.Date).Count();

            MessageSummaryModel currentSummary = new MessageSummaryModel() {
                nMonthSent = nMonthSent,
                nMonthRecived = nMonthRecived,
                nTodaySent = nTodaySent,
                nTodayRecived = nTodayRecived
            };
            
            return View(currentSummary);
        }
   }
}