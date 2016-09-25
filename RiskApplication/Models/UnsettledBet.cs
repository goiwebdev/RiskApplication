using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiskApplication.Models
{
    public class UnsettledBet
    {
        public int CustomerId { get; set; }
        public int EventId { get; set; }

        public int ParticipantId { get; set; }

        public int Stake { get; set; }

        public int ToWin { get; set; }
        public bool IsRisky { get; set; }
        public bool IsUnusual { get; set; }

        public bool IsHighlyUnusual { get; set; }

    }
}