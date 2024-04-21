using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telestream.Models.ViewModel
{
    public class MessageSummaryModel
    {
        public int nMonthSent { get; set; }
        public int nMonthRecived { get; set; }
        public int nTodaySent { get; set; }
        public int nTodayRecived { get; set; }
    }
}
