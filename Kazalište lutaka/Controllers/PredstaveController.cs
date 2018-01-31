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
    public class PredstaveController : Controller
    {
        private readonly Kazalište_lutakaContext _context;

        public PredstaveController(Kazalište_lutakaContext context)
        {
            _context = context;    
        }

        // GET: Predstave
        public async Task<IActionResult> Index()
        {
            return View(await _context.Predstave.ToListAsync());
        }

        // GET: Predstave/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predstave = await _context.Predstave
                .SingleOrDefaultAsync(m => m.Id == id);
            if (predstave == null)
            {
                return NotFound();
            }

            return View(predstave);
        }

        // GET: Predstave/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Predstave/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Trajanje,Uzrast")] Predstave predstave)
        {
            if (ModelState.IsValid)
            {
                _context.Add(predstave);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(predstave);
        }

        // GET: Predstave/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predstave = await _context.Predstave.SingleOrDefaultAsync(m => m.Id == id);
            if (predstave == null)
            {
                return NotFound();
            }
            return View(predstave);
        }

        // POST: Predstave/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Trajanje,Uzrast")] Predstave predstave)
        {
            if (id != predstave.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(predstave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PredstaveExists(predstave.Id))
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
            return View(predstave);
        }

        // GET: Predstave/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predstave = await _context.Predstave
                .SingleOrDefaultAsync(m => m.Id == id);
            if (predstave == null)
            {
                return NotFound();
            }

            return View(predstave);
        }

        // POST: Predstave/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var predstave = await _context.Predstave.SingleOrDefaultAsync(m => m.Id == id);
            _context.Predstave.Remove(predstave);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PredstaveExists(int id)
        {
            return _context.Predstave.Any(e => e.Id == id);
        }
    }
}
