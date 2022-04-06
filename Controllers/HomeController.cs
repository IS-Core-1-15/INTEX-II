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
        public IActionResult SummaryInformation(int severity, int pageNum = 1, int pageSize = 25)
        {
            //max crashes per page
            //int pageSize = 25; //Now passed in parameter

            var yeet = new CrashesViewModel
            {
                //crashes queryable with only crashes in filter
                Crashes = (severity == 0 ? _repo.Crashes
                .OrderBy(c => c.CRASH_ID)
                .Skip(pageSize * (pageNum - 1))
                .Take(pageSize)
                .ToList() : _repo.Crashes
                .Where(c => c.CRASH_SEVERITY_ID == severity)
                .OrderBy(c => c.CRASH_ID)
                .Skip(pageSize * (pageNum - 1))
                .Take(pageSize)
                .ToList()),

                // page info saved as type page info
                PageInfo = new PageInfo
                {
                    TotalNumCrashes = (severity == 0 ?
                        _repo.Crashes.Count()
                        : _repo.Crashes.Where(yeet => yeet.CRASH_SEVERITY_ID == severity).Count()),
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
