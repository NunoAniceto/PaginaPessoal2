using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaginaPessoal2.Models;

namespace PaginaPessoal2.Controllers
{
    public class HabilitacoesController : Controller
    {
        private readonly PaginaPessoalDBContext bd;

        public HabilitacoesController(PaginaPessoalDBContext context)
        {
            bd = context;
        }

        [Authorize]
        // GET: Habilitacoes
        public async Task<IActionResult> Index()
        {
            return View(await bd.Habilitacoes.ToListAsync());
        }

        // GET: Habilitacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habilitacoes = await bd.Habilitacoes
                .FirstOrDefaultAsync(m => m.HabilitacoesId == id);
            if (habilitacoes == null)
            {
                return NotFound();
            }

            return View(habilitacoes);
        }

        // GET: Habilitacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Habilitacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HabilitacoesId,Ano,Curso,Instituicao")] Habilitacoes habilitacoes)
        {
            if (ModelState.IsValid)
            {
                bd.Add(habilitacoes);
                await bd.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habilitacoes);
        }

        // GET: Habilitacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habilitacoes = await bd.Habilitacoes.FindAsync(id);
            if (habilitacoes == null)
            {
                return NotFound();
            }
            return View(habilitacoes);
        }

        // POST: Habilitacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HabilitacoesId,Ano,Curso,Instituicao")] Habilitacoes habilitacoes)
        {
            if (id != habilitacoes.HabilitacoesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bd.Update(habilitacoes);
                    await bd.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabilitacoesExists(habilitacoes.HabilitacoesId))
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
            return View(habilitacoes);
        }

        // GET: Habilitacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habilitacoes = await bd.Habilitacoes
                .FirstOrDefaultAsync(m => m.HabilitacoesId == id);
            if (habilitacoes == null)
            {
                return NotFound();
            }

            return View(habilitacoes);
        }

        // POST: Habilitacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habilitacoes = await bd.Habilitacoes.FindAsync(id);
            bd.Habilitacoes.Remove(habilitacoes);
            await bd.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabilitacoesExists(int id)
        {
            return bd.Habilitacoes.Any(e => e.HabilitacoesId == id);
        }
    }
}
