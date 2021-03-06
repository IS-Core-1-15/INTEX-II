using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX_II.Models
{
    public class Crash
    {
        [Key]
        [Required]
        public int CRASH_ID { get; set; }
        [Required]
        public string CRASH_DATETIME { get; set; }
        [Required] 
        public int ROUTE { get; set; }
        [Required] 
        public double MILEPOINT { get; set; }
        [Required]
        public double LAT_UTM_Y { get; set; }
        [Required]
        public double LONG_UTM_X { get; set; }
        [Required] 
        public string MAIN_ROAD_NAME { get; set; }
        [Required] 
        public string CITY { get; set; }
        [Required] 
        public string COUNTY_NAME { get; set; }
        [Required]
        [Range(1,5,ErrorMessage ="Crash severity must be a number between 1 and 5, 1 meaning no injury and 5 meaning fatal injuries")]
        public int CRASH_SEVERITY_ID { get; set; }
        public bool WORK_ZONE_RELATED { get; set; }
        public bool PEDESTRIAN_INVOLVED { get; set; }
        public bool BICYCLIST_INVOLVED { get; set; }
        public bool MOTORCYCLE_INVOLVED { get; set; }
        public bool IMPROPER_RESTRAINT { get; set; }
        public bool UNRESTRAINED { get; set; }
        public bool DUI { get; set; }
        public bool INTERSECTION_RELATED { get; set; }
        public bool WILD_ANIMAL_RELATED { get; set; }
        public bool DOMESTIC_ANIMAL_RELATED { get; set; }
        public bool OVERTURN_ROLLOVER { get; set; }
        public bool COMMERCIAL_MOTOR_VEH_INVOLVED { get; set; }
        public bool TEENAGE_DRIVER_INVOLVED { get; set; }
        public bool OLDER_DRIVER_INVOLVED { get; set; }
        public bool NIGHT_DARK_CONDITION { get; set; }
        public bool SINGLE_VEHICLE { get; set; }
        public bool DISTRACTED_DRIVING { get; set; }
        public bool DROWSY_DRIVING { get; set; }
        public bool ROADWAY_DEPARTURE { get; set; }
    }
}
