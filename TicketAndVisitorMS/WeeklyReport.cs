using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAndVisitorMS
{
    public class WeeklyReport
    {
        public string Day { get; set; }

        public DateTime Date { get; set; }

        public int TotalVisitor { get; set; }

        public double TotalEarning { get; set; }
    }
}