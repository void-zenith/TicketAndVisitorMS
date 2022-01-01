using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAndVisitorMS
{
    public class DailyReport
    {
        public DateTime Date { get; set; }
        public string Category { get; set; }

        public int TotalVisitor { get; set; }
    }
}