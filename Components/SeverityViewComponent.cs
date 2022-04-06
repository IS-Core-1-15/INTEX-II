using INTEX_II.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX_II.Components
{
    public class SeverityViewComponent : ViewComponent
    {
        private ICrashRepository _repo { get; set; }

        public SeverityViewComponent (ICrashRepository temp)
        {
            _repo = temp;
        }

        //gets a list of severities for severity component
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedSeverity = RouteData?.Values["severity"];

            var severities = _repo.Crashes
                .Select(yeet => yeet.CRASH_SEVERITY_ID)
                .Distinct()
                .OrderBy(yeet => yeet)
                .Skip(1);

            return View(severities);
        }
    }
}
