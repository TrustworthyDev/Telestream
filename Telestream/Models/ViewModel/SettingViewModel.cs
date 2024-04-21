using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telestream.Models.ViewModel
{
    public class SettingViewModel
    {
        public string apiKey { get; set; }
        public List<string> phoneNumbers { get; set; }

        public string webhookUrl {get; set;}
    }
}
