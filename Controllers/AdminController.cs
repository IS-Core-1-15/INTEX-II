﻿using INTEX_II.Models;
using INTEX_II.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX_II.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ICrashRepository _repo;

        public AdminController(ICrashRepository temp) => _repo = temp;

        //// take out later possibly
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //Admin get
        public IActionResult Main(int severity = 0, int pageNum = 1)
        {
            //max crashes per page
            int pageSize = 25;

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

        public IActionResult Details(int id, int returnPage)
        {
            var crash = _repo.Crashes.FirstOrDefault(yeet => yeet.CRASH_ID == id);

            ViewBag.pageNumReturn = returnPage;
            return View(crash);
        }

        [HttpGet]
        public IActionResult Add(int returnPage)
        {
            ViewBag.pageNumReturn = returnPage;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Crash c)
        {
            if (ModelState.IsValid)
            {

                _repo.CreateCrash(c);

                return RedirectToAction("Main");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id, int returnPage)
        {
            var crash = _repo.Crashes.FirstOrDefault(yeet => yeet.CRASH_ID == id);

            ViewBag.dateTime = DateTime.Parse(crash.CRASH_DATETIME).ToString("s");

            ViewBag.pageNumReturn = returnPage;

            return View(crash);
        }

        [HttpPost]
        public IActionResult Edit(Crash c)
        {
            if (ModelState.IsValid)
            {
                c.CRASH_DATETIME = DateTime.Parse(c.CRASH_DATETIME).ToString("M/dd/yy HH:mm");

                _repo.SaveCrash(c);

                return RedirectToAction("Main");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult DeleteConfirmation(int id, int returnPage)
        {
            var crash = _repo.Crashes.FirstOrDefault(yeet => yeet.CRASH_ID == id);

            ViewBag.pageNumReturn = returnPage;

            return View(crash);
        }

        [HttpPost]
        public IActionResult DeleteConfirmation(int id)
        {
            Crash c = _repo.Crashes.FirstOrDefault(yeet => yeet.CRASH_ID == id);
            
            _repo.DeleteCrash(c);

            return RedirectToAction("Main");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
