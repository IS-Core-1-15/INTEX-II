using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX_II.Models.ViewModels
{
    // for passing in more than one model to views
    public class CrashesViewModel
    {
        public List<Crash> Crashes { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
