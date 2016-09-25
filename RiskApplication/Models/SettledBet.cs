using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        // added for task #1

        public int TotalWinsCount { get; set; }

        public int TotalBets { get; set; }

        public decimal AverageBet { get; set; }
        ///[DisplayFormat(DataFormatString = "{0:P}")]
        public decimal WinningPercentage { get; set; }

    }
}