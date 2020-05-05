using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LHUI.ViewModel
{
    public class LHUsersViewModel
    {
        public string UserName { get; set; }
        [Display(Name = "Email")]
        public string UserEmail { get; set; }
    }
}
