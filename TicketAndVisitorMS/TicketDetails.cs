using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAndVisitorMS
{
    internal class TicketDetails
    {
        public string ticketID { get; set; }

        public string ticketCategory { get; set; }

        public string ticketDay { get; set; }

        public double ticketPrice { get; set; }

        public int ticketNoOfIndividuals { get; set; }

        public string ticketDuration { get; set; }
    }
}