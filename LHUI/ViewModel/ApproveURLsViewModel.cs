using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LHUI.ViewModel
{
    public class ApproveURLsViewModel
    {
        public int UrlId { get; set; }
        public string UrlTitle { get; set; }
        public string LHUrlName { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string UserName { get; set; }
        public bool IsApproved { get; set; }
    }
}
