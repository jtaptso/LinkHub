using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LHBLL;
using LHUI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LHUI.Controllers
{
    [AllowAnonymous]
    public class BrowseURLsController : Controller
    {
        ILHUrlBs lHUrlBs;
        public BrowseURLsController(ILHUrlBs _lHUrlBs)
        {
            lHUrlBs = _lHUrlBs;
        }
        public IActionResult Index()
        {
            List<BrowseURLsViewModel> browseURLs = new List<BrowseURLsViewModel>();
            var urls = lHUrlBs.GetAll(true);
            foreach (var item in urls)
            {
                BrowseURLsViewModel model = new BrowseURLsViewModel()
                {
                    CategoryName = item.Category.CategoryName,
                    Description = item.Description,
                    LHUrlName = item.LHUrlName,
                    UrlTitle = item.UrlTitle,
                    UserName = item.LHUser.UserName,
                    UrlId = item.UrlId
                };
                browseURLs.Add(model);
            }
            return View(browseURLs);
        }
    }
}