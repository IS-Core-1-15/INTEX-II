using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX_II.Models.ViewModels
{
    //class for keeping track of page info for pagination
    public class PageInfo
    {
        public int TotalNumCrashes { get; set; }
        public int CrashesPerPage { get; set; }
        public int CurrentPage { get; set; }
        //calc number of pages needed to display all crashes
        public int TotalPages => (int)Math.Ceiling((double)TotalNumCrashes / CrashesPerPage);
    }
}
