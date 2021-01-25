using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaginaPessoal2.Models;

namespace PaginaPessoal2.Controllers
{
    public class ExperienciasController : Controller
    {
        private readonly PaginaPessoalDBContext bd;

        public ExperienciasController(PaginaPessoalDBContext context)
        {
            bd = context;
        }

        // GET: Experiencias
        public async Task<IActionResult> Index()
        {
            return View(await bd.Experiencia.ToListAsync());
        }

        // GET: Experiencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiencia = await bd.Experiencia
                .FirstOrDefaultAsync(m => m.ExperienciaId == id);
            if (experiencia == null)
            {
                return NotFound();
            }

            return View(experiencia);
        }

        // GET: Experiencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Experiencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExperienciaId,Ano,Empresa,Cargo")] Experiencia experiencia)
        {
            if (ModelState.IsValid)
            {
                bd.Add(experiencia);
                await bd.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experiencia);
        }

        // GET: Experiencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiencia = await bd.Experiencia.FindAsync(id);
            if (experiencia == null)
            {
                return NotFound();
            }
            return View(experiencia);
        }

        // POST: Experiencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExperienciaId,Ano,Empresa,Cargo")] Experiencia experiencia)
        {
            if (id != experiencia.ExperienciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bd.Update(experiencia);
                    await bd.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienciaExists(experiencia.ExperienciaId))
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
            return View(experiencia);
        }

        // GET: Experiencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiencia = await bd.Experiencia
                .FirstOrDefaultAsync(m => m.ExperienciaId == id);
            if (experiencia == null)
            {
                return NotFound();
            }

            return View(experiencia);
        }

        // POST: Experiencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experiencia = await bd.Experiencia.FindAsync(id);
            bd.Experiencia.Remove(experiencia);
            await bd.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienciaExists(int id)
        {
            return bd.Experiencia.Any(e => e.ExperienciaId == id);
        }
    }
}
