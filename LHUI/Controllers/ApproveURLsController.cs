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
    [Authorize(Roles = "Admin")]
    public class ApproveURLsController : Controller
    {
        ILHUrlBs lHUrlBs;
        public ApproveURLsController(ILHUrlBs _lHUrlBs)
        {
            lHUrlBs = _lHUrlBs;
        }
        public IActionResult Index()
        {
            List<ApproveURLsViewModel> approveURLs = new List<ApproveURLsViewModel>();
            var urls = lHUrlBs.GetAll(false);
            foreach (var item in urls)
            {
                ApproveURLsViewModel model = new ApproveURLsViewModel()
                {
                    CategoryName = item.Category.CategoryName,
                    Description = item.Description,
                    LHUrlName = item.LHUrlName,
                    UrlTitle = item.UrlTitle,
                    UserName = item.LHUser.UserName,
                    UrlId = item.UrlId,
                    IsApproved = item.IsApproved
                };
                approveURLs.Add(model);
            }
            return View(approveURLs);
        }
        [HttpPost]
        public IActionResult Approve (int urlId)
        {
            var lHUrl = lHUrlBs.GetById(urlId);
            lHUrl.IsApproved = true;
            lHUrlBs.Update(lHUrl);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult ApproveALL(List<int> urlIds)
        {
            if (urlIds.Count != 0)
            {
                foreach (var urlId in urlIds)
                {
                    var lHUrl = lHUrlBs.GetById(urlId);
                    lHUrl.IsApproved = true;
                    lHUrlBs.Update(lHUrl);
                }
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}