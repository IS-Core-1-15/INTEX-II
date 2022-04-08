using INTEX_II.Models;
using INTEX_II.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX_II.Controllers
{
    public class HomeController : Controller
    {


        // take out later possibly
        private readonly ILogger<HomeController> _logger;


        private ICrashRepository _repo;
        private InferenceSession _session;


        public HomeController(ICrashRepository temp, InferenceSession session, ILogger<HomeController> logger)
        {
            _repo = temp;
            _session = session;
            _logger = logger;
        }

        //index get
        public IActionResult Index()
        {
            return View();
        }

        // privacy statement
        public IActionResult Privacy()
        {
            return View();
        }

        // cookies statement
        public IActionResult Cookies()
        {
            return View();
        }

        //get summary view page
        public IActionResult SummaryInformation(int severity, int pageNum = 1, int pageSize = 25)
        {
            ViewBag.pageSize = pageSize;
            ViewBag.pageNum = pageNum;

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

            ViewBag.totalCrashes = (severity == 0 ? _repo.Crashes.Count() : _repo.Crashes.Where(yeet => yeet.CRASH_SEVERITY_ID == severity).Count());

            return View(yeet);
        }

        [HttpGet]
        public IActionResult Calculator()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculator(RawForm raw)
        {
            PredictorForm data = new PredictorForm(raw);

            var result = _session.Run(new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("float_input", data.AsTensor())
            });

            var stringResult = result.ToList()[0].AsTensor<long>().ToArray<long>()[0].ToString();
            var score = Int32.Parse(stringResult);

            ViewBag.results = score;
            
            result.Dispose();
            return View("Calculator");
        }

        [HttpGet]
        public IActionResult YeetedComments()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
