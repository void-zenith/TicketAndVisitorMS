using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAndVisitorMS
{
    public class VisitorDetails
    {
        public string visitorTicketNo { get; set; }

        public string visitorName { get; set; }

        public string visitorContactNo { get; set; }

        public string visitorCategory { get; set; }

        public string visitorTicketInfoID { get; set; }

        public string visitorDay { get; set; }
        public string visitorCheckInTime { get; set; }

        public string visitorCheckOutTime { get; set; }

        public string visitorDuration { get; set; }

        public DateTime visitorDate { get; set; }

        public string visitorTotalPrice { get; set; }

        public string visitorNoOfIndividual { get; set; }
    }
}