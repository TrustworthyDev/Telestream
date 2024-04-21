using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;
using Telnyx;
using Telnyx.net.Entities;
using Microsoft.AspNetCore.Http;

namespace Telestream.Controllers
{
    public class WebhookHelpers
    {
        public static async Task<dynamic> deserializeCallbackToDynamic(HttpRequest request){
            string json;
            using (var reader = new StreamReader(request.Body))
            {
                json = await reader.ReadToEndAsync();
            }
            dynamic webhook = JsonConvert.DeserializeObject<dynamic>(json);
            return webhook;
        }
    }
}