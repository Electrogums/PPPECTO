using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoProspectos.Models;

namespace ProyectoProspectos.Controllers
{
    public class ProspectoesController : Controller
    {
        private readonly Context _context;

        public ProspectoesController(Context context)
        {
            _context = context;
        }

        // GET: Prospectoes
        public async Task<IActionResult> Index()
        {
            var context = _context.Prospectos.Include(p => p.IdEstatusNavigation);
            return View(await context.ToListAsync());
        }

        // GET: Prospectoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prospecto = await _context.Prospectos
                .Include(p => p.IdEstatusNavigation)
                .FirstOrDefaultAsync(m => m.IdProspecto == id);
            if (prospecto == null)
            {
                return NotFound();
            }

            return View(prospecto);
        }

        // GET: Prospectoes/Create
        public IActionResult Create()
        {
            ViewData["IdEstatus"] = new SelectList(_context.CatStatuses, "IdEstatus", "IdEstatus");
            return View();
        }

        // POST: Prospectoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProspecto,Nombre,PrimerApellido,SegundoApellido,Calle,Colonia,Cp,Telefono,Rfc,IdEstatus,Observación")] Prospecto prospecto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prospecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstatus"] = new SelectList(_context.CatStatuses, "IdEstatus", "IdEstatus", prospecto.IdEstatus);
            return View(prospecto);
        }

        // GET: Prospectoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prospecto = await _context.Prospectos.FindAsync(id);
            if (prospecto == null)
            {
                return NotFound();
            }
            ViewData["IdEstatus"] = new SelectList(_context.CatStatuses, "IdEstatus", "IdEstatus", prospecto.IdEstatus);
            return View(prospecto);
        }

        // POST: Prospectoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProspecto,Nombre,PrimerApellido,SegundoApellido,Calle,Colonia,Cp,Telefono,Rfc,IdEstatus,Observación")] Prospecto prospecto)
        {
            if (id != prospecto.IdProspecto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prospecto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProspectoExists(prospecto.IdProspecto))
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
            ViewData["IdEstatus"] = new SelectList(_context.CatStatuses, "IdEstatus", "IdEstatus", prospecto.IdEstatus);
            return View(prospecto);
        }

        // GET: Prospectoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prospecto = await _context.Prospectos
                .Include(p => p.IdEstatusNavigation)
                .FirstOrDefaultAsync(m => m.IdProspecto == id);
            if (prospecto == null)
            {
                return NotFound();
            }

            return View(prospecto);
        }

        // POST: Prospectoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prospecto = await _context.Prospectos.FindAsync(id);
            _context.Prospectos.Remove(prospecto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       
        private bool ProspectoExists(int id)
        {
            return _context.Prospectos.Any(e => e.IdProspecto == id);
        }
    }
}
