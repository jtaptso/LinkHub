using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LHUI.ViewModel
{
    public class BrowseURLsViewModel
    {
        public int UrlId { get; set; }
        [Display(Name = "Url Title")]

        public string UrlTitle { get; set; }
        [Display(Name = "Url Name")]

        public string LHUrlName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        public string UserName { get; set; }
    }
}
