using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LHBLL;
using LHBOL;
using LHUI.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LHUI.Controllers
{
    public class SubmitLHUrlsController : Controller
    {
        UserManager<LHUser> userManager;

        ILHUrlBs lHUrlBs;
        ICategoryBs categoryBs;

        public SubmitLHUrlsController(UserManager<LHUser> _userManager, ILHUrlBs _lHUrlBs, ICategoryBs _categoryBs)
        {
            userManager = _userManager;
            lHUrlBs = _lHUrlBs;
            categoryBs = _categoryBs;
        }
        //public IActionResult Index()
        //{
        //    var urls = lHUrlBs.GetAll();
        //    return View(urls);
        //}
        [HttpGet]
        public IActionResult CreateUrl()
        {
            ViewBag.Categories = categoryBs.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUrl(CreateUrlViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                var url = new LHUrl() 
                {
                    LHUrlName = model.LHUrlName, 
                    UrlTitle = model.UrlTitle, 
                    Description = model.Description, 
                    CategoryId = model.CategoryId,
                    IsApproved = false,
                    Id = user.Id
                };
                lHUrlBs.Create(url);

                return RedirectToAction("CreateUrl");
            }
            ViewBag.Categories = categoryBs.GetAll();

            return View();
        }
    }
}