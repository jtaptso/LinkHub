using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LHBOL
{
    [Table("LHUser")]
    public class LHUser : IdentityUser
    {
        public string Contact { get; set; }
        public IEnumerable<LHUrl> LHUrls { get; set; }
    }
}
