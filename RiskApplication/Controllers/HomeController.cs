﻿using RiskApplication.Models;
using RiskApplication.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RiskApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(ReadRiskInitialData());
        }

        public RiskViewModel ReadRiskInitialData()
        {
            var initialData = new RiskViewModel();
            var settledFileName = "Settled.csv";

            string pathSettled = string.Format("{0}/{1}", Server.MapPath("~/Content/Uploads"), settledFileName);

            List<SettledBet> settledBets = new List<SettledBet>();
            List<UnsettledBet> unsettledBets = new List<UnsettledBet>();
            if (System.IO.File.Exists(pathSettled))
            {
                DataTable dtSettled = ConvertDataTable.ConvertCSVtoDataTable(pathSettled);
                List<SettledBet> settledList = new List<SettledBet>();
                foreach (DataRow dr in dtSettled.Rows)
                {
                    settledList.Add(new SettledBet
                    {
                        CustomerId = Convert.ToInt32(dr["Customer"].ToString()),
                        EventId = Convert.ToInt32(dr["Event"].ToString()),
                        ParticipantId = Convert.ToInt32(dr["Participant"].ToString()),
                        Stake = Convert.ToInt32(dr["Stake"].ToString()),
                        Win = Convert.ToInt32(dr["Win"].ToString())
                    });
                }
                    settledList.Select(a => a.CustomerId).Distinct().ToList().ForEach(a =>
                    {
                        int totalBets = 0;
                        int totalWins = 0;

                        totalBets = settledList.Where(x => x.CustomerId == a).Count();
                        totalWins = settledList.Where(x => x.CustomerId == a && x.Win > 0).Count();

                        var totalPlaceBets = settledList.Where(x => x.CustomerId == a).Select(c => c.Stake).Sum();



                        var settled = new SettledBet();
                        settled.CustomerId = a;
                        settled.TotalWinsCount = totalWins;
                        settled.TotalBets = totalBets;
                        settled.WinningPercentage = ((decimal)totalWins / totalBets) * 100;
                        settled.AverageBet = ((decimal)totalPlaceBets / totalBets);
                        settledBets.Add(settled);

                    });                
            }

            initialData.settledBets = settledBets;
            initialData.unsettledBets = unsettledBets;

            return initialData;

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}