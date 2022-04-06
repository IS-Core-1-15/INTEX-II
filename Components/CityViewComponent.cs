using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX_II.Components
{
    public class CityViewComponent : ViewComponent
    {
        public string[] Cities = { "Alpine", "Alta", "Amalga", "American Fork", "Beaver", "Beryl", "Blanding", "Bluff", "Bluffdale", "Boulder Town", "Bountiful", "Brian Head", "Brigham City", "Brighton, Town of", "Castle Valley", 
            "Castle Dale", "Cedar City", "Cedar Fort", "Cedar Hills", "Centerville", "Charleston", "Circleville", "Clearfield", "Clinton", "Coalville", "Copperton Metro Township", "Cottonwood Heights", "Daniel", "Delta", 
            "Deweyville", "Draper", "Duchesne", "Dutch John", "Eagle Mountain", "Elk Ridge", "Elwood", "Emigration Canyon Metro Township", "Enterprise", "Ephraim", "Escalante", "Eureka", "Fairview", "Farmington", "Farr West", 
            "Ferron City", "Fillmore", "Fountain Green", "Fruit Heights City", "Garden City", "Garfield", "Garland", "Genola", "Grantsville", "Green River", "Grouse Creek", "Gunnison", "Hanksville", "Harrisville City", "Heber", 
            "Helper", "Henefer", "Herriman", "Hideout", "Highland", "Hildale", "Hill Air Force Base", "Hinckley", "Holladay", "Honeyville", "Hooper City", "Huntsville Town", "Huntington", "Hurricane", "Hyde Park", "Hyrum", 
            "Independence", "Ivins", "Junction", "Kamas", "Kanab", "Kaysville", "Kearns Metro Township", "La Verkin", "Laketown", "Layton", "Leeds", "Lehi", "Levan", "Lewiston", "Lindon", "Logan", "Magna", "Manila", "Manti", 
            "Mapleton", "Marysvale", "Mayfield", "Mendon", "Midvale City", "Midway", "Milford", "Millcreek", "Moab", "Monroe City", "Monticello", "Morgan City", "Moroni", "Murray", "Mt. Pleasant", "Myton", "Naples City", "Nephi City", 
            "Newton", "Nibley City", "North Logan", "North Ogden", "North Salt Lake", "Oak City", "Oakley City", "Ogden", "Orangeville", "Orem", "Panguitch", "Paradise", "Park City", "Payson", "Perry", "Plain City", "Pleasant Grove", 
            "Pleasant View City", "Price", "Providence City", "Provo", "Richfield", "Richmond", "Riverdale City", "Riverton", "River Heights", "Rockville", "Roosevelt", "Roy City", "Salem", "Salina", "Salt Lake City", "Sandy", 
            "Santaquin", "Saratoga Springs", "Smithfield", "South Jordan", "South Ogden", "South Salt Lake", "South Weber", "Spanish Fork", "Spring City", "Springdale", "Springville", "St. George", "Stansbury Park", "Sterling", 
            "Stockton", "Sunset", "Syracuse", "Taylorsville", "Tooele", "Tremonton", "Tropic", "Uinta City", "Vernal", "Vineyard", "Wales", "Washington City", "Washington Terrace", "Wellington", "Wellsville", "West Bountiful", 
            "West Jordan", "Wendover", "West Point", "West Valley", "White City", "Woodland Hills", "Woods Cross" };

        public CityViewComponent()
        {
        }

        //gets a list of severities for severity component
        public IViewComponentResult Invoke()
        {
            return View(Cities);
        }
    }
}
