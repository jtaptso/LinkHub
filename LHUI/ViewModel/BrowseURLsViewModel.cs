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
        public string UrlTitle { get; set; }
        public string LHUrlName { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string UserName { get; set; }
    }
}
