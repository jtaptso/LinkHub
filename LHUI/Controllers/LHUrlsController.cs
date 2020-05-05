using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LHBOL;
using LHDAL;

namespace LHUI.Controllers
{
    public class LHUrlsController : Controller
    {
        private readonly LHDbContext _context;

        public LHUrlsController(LHDbContext context)
        {
            _context = context;
        }

        // GET: LHUrls
        public async Task<IActionResult> Index()
        {
            var lHDbContext = _context.LHUrls.Include(l => l.Category).Include(l => l.LHUser);
            return View(await lHDbContext.ToListAsync());
        }

        // GET: LHUrls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lHUrl = await _context.LHUrls
                .Include(l => l.Category)
                .Include(l => l.LHUser)
                .FirstOrDefaultAsync(m => m.UrlId == id);
            if (lHUrl == null)
            {
                return NotFound();
            }

            return View(lHUrl);
        }

        // GET: LHUrls/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            ViewData["Id"] = new SelectList(_context.LHUsers, "Id", "Id");
            return View();
        }

        // POST: LHUrls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UrlId,UrlTitle,LHUrlName,Description,IsApproved,CategoryId,Id")] LHUrl lHUrl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lHUrl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", lHUrl.CategoryId);
            ViewData["Id"] = new SelectList(_context.LHUsers, "Id", "Id", lHUrl.Id);
            return View(lHUrl);
        }

        // GET: LHUrls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lHUrl = await _context.LHUrls.FindAsync(id);
            if (lHUrl == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", lHUrl.CategoryId);
            ViewData["Id"] = new SelectList(_context.LHUsers, "Id", "Id", lHUrl.Id);
            return View(lHUrl);
        }

        // POST: LHUrls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UrlId,UrlTitle,LHUrlName,Description,IsApproved,CategoryId,Id")] LHUrl lHUrl)
        {
            if (id != lHUrl.UrlId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lHUrl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LHUrlExists(lHUrl.UrlId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", lHUrl.CategoryId);
            ViewData["Id"] = new SelectList(_context.LHUsers, "Id", "Id", lHUrl.Id);
            return View(lHUrl);
        }

        // GET: LHUrls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lHUrl = await _context.LHUrls
                .Include(l => l.Category)
                .Include(l => l.LHUser)
                .FirstOrDefaultAsync(m => m.UrlId == id);
            if (lHUrl == null)
            {
                return NotFound();
            }

            return View(lHUrl);
        }

        // POST: LHUrls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lHUrl = await _context.LHUrls.FindAsync(id);
            _context.LHUrls.Remove(lHUrl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LHUrlExists(int id)
        {
            return _context.LHUrls.Any(e => e.UrlId == id);
        }
    }
}
