using System;
namespace INTEX_II.Models
{
    public class RawForm
    {
        public bool PEDESTRIAN_INVOLVED { get; set; }
        public bool BICYCLIST_INVOLVED { get; set; }
        public bool MOTORCYCLE_INVOLVED { get; set; }
        public bool IMPROPER_RESTRAINT { get; set; }
        public bool UNRESTRAINED { get; set; }
        public bool DUI { get; set; }
        public bool INTERSECTION_RELATED { get; set; }
        public bool OVERTURN_ROLLOVER { get; set; }
        public bool OLDER_DRIVER_INVOLVED { get; set; }
        public float CRASH_MONTH { get; set; }
        public float CRASH_YEAR { get; set; }
    }
}
