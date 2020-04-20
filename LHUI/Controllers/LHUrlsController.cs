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
    public class LHUrlsController : Controller
    {
        ILHUrlBs lHUrlBs;
        public LHUrlsController(ILHUrlBs _lHUrlBs)
        {
            lHUrlBs = _lHUrlBs;
        }
        public IActionResult Index()
        {
            var lHUrls = lHUrlBs.GetAll();
            return View(lHUrls);
        }
    }
}