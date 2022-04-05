﻿using INTEX_II.Models;
using INTEX_II.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX_II.Controllers
{
    public class HomeController : Controller
    {
        private ICrashRepository _repo;

        public HomeController(ICrashRepository temp) => _repo = temp;

        //// take out later possibly
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //index get
        public IActionResult Index()
        {
            return View();
        }

        //get summary view page
        public IActionResult SummaryInformation(string countyName, int pageNum = 1)
        {
            //max crashes per page
            int pageSize = 25;

            var yeet = new CrashesViewModel
            {
                //crashes queryable with only crashes in filter
                Crashes = _repo.Crashes
                .Where(c => c.COUNTY_NAME == countyName || countyName == null)
                .OrderBy(c => c.CRASH_DATETIME)
                .Skip(pageSize * (pageNum - 1))
                .Take(pageSize)
                .ToList(),

                // page info saved as type page info
                PageInfo = new PageInfo
                {
                    TotalNumCrashes = (countyName == null ?
                        _repo.Crashes.Count()
                        : _repo.Crashes.Where(yeet => yeet.COUNTY_NAME == countyName).Count()),
                    CrashesPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(yeet);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
