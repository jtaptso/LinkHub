using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LHBOL;
using LHDAL;
using LHUI.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LHUI.Controllers
{
    public class LHUsersController : Controller
    {
        private readonly LHDbContext _context;
        UserManager<LHUser> userManager;
        public LHUsersController(UserManager<LHUser> _userManager, LHDbContext context)
        {
            userManager = _userManager;
            _context = context;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var users = _context.LHUsers;

            List<LHUsersViewModel> usersViewModel = new List<LHUsersViewModel>();
            foreach (var user in users)
            {
                var viewModel = new LHUsersViewModel();
                viewModel.UserName = user.UserName;
                viewModel.UserEmail = user.Email;
                usersViewModel.Add(viewModel);
            }
            return View(usersViewModel);
        }

        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.LHUsers
        //        .FirstOrDefaultAsync(u => u.Id == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        //// POST: Categories/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
            
        //    var category = await _context.Categories.FindAsync(id);
        //    _context.Categories.Remove(category);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}