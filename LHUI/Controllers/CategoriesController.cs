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
    public class CategoriesController : Controller
    {
        ICategoryBs categoryBs;

        public CategoriesController(ICategoryBs _categoryBs)
        {
            categoryBs = _categoryBs;
        }
        public IActionResult Index()
        {
            var categories = categoryBs.GetAll();

            return View(categories);
        }
    }
}