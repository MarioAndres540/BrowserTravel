using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrowserTravel;
using BrowserTravel.Entidades;

namespace BrowserTravel.Controllers
{
    public class EditorialsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EditorialsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Editorials
        public async Task<IActionResult> Index(string buscar)
        {
            var editorials = from editorial in _context.Editoriales select editorial;

            if (!String.IsNullOrEmpty(buscar))
            {
                editorials = editorials.Where(s => s.Nombre!.Contains(buscar));
            }

            return View(await editorials.ToListAsync());


        }

        // GET: Editorials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Editoriales == null)
            {
                return NotFound();
            }

            var editorials = await _context.Editoriales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (editorials == null)
            {
                return NotFound();
            }

            return View(editorials);
        }

        // GET: Editorials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editorials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Sede")] Editorials editorials)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editorials);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(editorials);
        }

        // GET: Editorials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Editoriales == null)
            {
                return NotFound();
            }

            var editorials = await _context.Editoriales.FindAsync(id);
            if (editorials == null)
            {
                return NotFound();
            }
            return View(editorials);
        }

        // POST: Editorials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Sede")] Editorials editorials)
        {
            if (id != editorials.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editorials);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditorialsExists(editorials.Id))
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
            return View(editorials);
        }

        // GET: Editorials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Editoriales == null)
            {
                return NotFound();
            }

            var editorials = await _context.Editoriales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (editorials == null)
            {
                return NotFound();
            }

            return View(editorials);
        }

        // POST: Editorials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Editoriales == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Editoriales'  is null.");
            }
            var editorials = await _context.Editoriales.FindAsync(id);
            if (editorials != null)
            {
                _context.Editoriales.Remove(editorials);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EditorialsExists(int id)
        {
          return (_context.Editoriales?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
