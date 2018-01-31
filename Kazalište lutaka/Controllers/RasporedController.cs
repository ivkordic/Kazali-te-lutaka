using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kazalište_lutaka.Models;

namespace Kazalište_lutaka.Controllers
{
    public class RasporedController : Controller
    {
        private readonly Kazalište_lutakaContext _context;

        public RasporedController(Kazalište_lutakaContext context)
        {
            _context = context;    
        }

        // GET: Raspored
        public async Task<IActionResult> Index()
        {
            var kazalište_lutakaContext = _context.Raspored.Include(r => r.Predstave);
            return View(await kazalište_lutakaContext.ToListAsync());
        }

        // GET: Raspored/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raspored = await _context.Raspored
                .Include(r => r.Predstave)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (raspored == null)
            {
                return NotFound();
            }

            return View(raspored);
        }

        // GET: Raspored/Create
        public IActionResult Create()
        {
            ViewData["PredstaveId"] = new SelectList(_context.Predstave, "Id", "Naziv");
            return View();
        }

        // POST: Raspored/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DatPredstave,PredstaveId")] Raspored raspored)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raspored);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["PredstaveId"] = new SelectList(_context.Predstave, "Id", "Naziv", raspored.PredstaveId);
            return View(raspored);
        }

        // GET: Raspored/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raspored = await _context.Raspored.SingleOrDefaultAsync(m => m.Id == id);
            if (raspored == null)
            {
                return NotFound();
            }
            ViewData["PredstaveId"] = new SelectList(_context.Predstave, "Id", "Naziv", raspored.PredstaveId);
            return View(raspored);
        }

        // POST: Raspored/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DatPredstave,PredstaveId")] Raspored raspored)
        {
            if (id != raspored.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raspored);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RasporedExists(raspored.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["PredstaveId"] = new SelectList(_context.Predstave, "Id", "Naziv", raspored.PredstaveId);
            return View(raspored);
        }

        // GET: Raspored/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raspored = await _context.Raspored
                .Include(r => r.Predstave)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (raspored == null)
            {
                return NotFound();
            }

            return View(raspored);
        }

        // POST: Raspored/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raspored = await _context.Raspored.SingleOrDefaultAsync(m => m.Id == id);
            _context.Raspored.Remove(raspored);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RasporedExists(int id)
        {
            return _context.Raspored.Any(e => e.Id == id);
        }
    }
}
