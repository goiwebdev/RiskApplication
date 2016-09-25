using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiskApplication.Models
{
    public class SettledBet
    {
        public int CustomerId { get; set; }
        public int EventId { get; set; }

        public int ParticipantId { get; set; }
        public int Stake { get; set; }

        public int Win { get; set; }
    }
}