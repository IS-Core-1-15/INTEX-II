using INTEX_II.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX_II.Components
{
    public class CountyViewComponent : ViewComponent
    {
        public string[] Counties = {"BEAVER", "BOX ELDER", "CACHE", "CARBON", "DAGGET", "DAVIS", "DUCHESNE", "EMERY", "GARFIELD", "GRAND", "IRON", "JUAB", "KANE", "MILLARD", "MORGAN", "PIUTE", "RICH", "SALT LAKE",
            "SAN JUAN", "SANPETE", "SEVIER", "SUMMIT", "TOOELE", "UINTAH", "UTAH", "WASATCH", "WASHINGTON", "WAYNE", "WEBER"};

        public CountyViewComponent()
        {
        }

        //gets a list of severities for severity component
        public IViewComponentResult Invoke()
        {
            return View(Counties);
        }
    }
}
