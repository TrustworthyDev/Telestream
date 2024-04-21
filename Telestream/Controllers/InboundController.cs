using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Telestream.Models;
using Telestream.Models.Entities;
using System.Linq;
using Telestream.Helpers;
using Telestream.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Telestream.Controllers
{

    [ApiController]
    [Route("messaging/[controller]")]
    public class InboundController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHubContext<NotificationHub> _notificationHubContext;
        
        public InboundController(IHubContext<NotificationHub> notificationHubContext, ApplicationDbContext dbContext)
        {
            _notificationHubContext = notificationHubContext;
            _dbContext = dbContext;
        }

        // POST messaging/Inbound
        [HttpPost]
        [Consumes("application/json")]
        public async Task<string> MessageInboundCallback()
        {
            dynamic webhook = await WebhookHelpers.deserializeCallbackToDynamic(this.Request);
            string to = webhook.data.payload.to[0].phone_number;
            string from = webhook.data.payload.from.phone_number;
            string message = webhook.data.payload.text;
            string messageId = webhook.data.payload.id;
            string contact = Global.GetContactName(from);

            SMS newSms = new SMS() {
                from = from,
                to = to,
                contact = contact,
                content = message,
                createdAt = DateTime.Now,
                messageId = messageId,
            };
            _dbContext.Add(newSms);
            _dbContext.SaveChanges();

            await _notificationHubContext.Clients.All.SendAsync("InboundCallback", newSms);

            Console.WriteLine($"Received message with ID: {messageId}");
            return "";
        }
    }
}