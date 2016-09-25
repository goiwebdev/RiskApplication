using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiskApplication.Models
{
    public class RiskViewModel
    {
        public string SettledFileName { get; set; }
        public string UnSettledFileName { get; set; }

        public List<SettledBet> settledBets;
        public List<UnsettledBet> unsettledBets;

    }
}