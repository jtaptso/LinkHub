using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LHBLL;
using LHBOL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LHUI.Controllers
{
    [AllowAnonymous]
    public class LHUsersController : Controller
    {
        ILHUserBs lHUserBs;
        public LHUsersController(ILHUserBs _lHUserBs)
        {
            lHUserBs = _lHUserBs;
        }
        public IActionResult Index()
        {
            var lHUsers = lHUserBs.GetAll();
            return View(lHUsers);
        }
    }
}