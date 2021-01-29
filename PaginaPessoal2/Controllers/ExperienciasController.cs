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
    public class ExperienciasController : Controller
    {
        private readonly PaginaPessoalDBContext bd;

        public ExperienciasController(PaginaPessoalDBContext context)
        {
            bd = context;
        }

        // GET: Experiencias
        [Authorize]
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await bd.Experiencia.Where(e => nomePesquisar == null || e.Empresa.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<Experiencia> experiencias = await bd.Experiencia.Where(e => nomePesquisar == null || e.Empresa.Contains(nomePesquisar))
                .OrderBy(a => a.ExperienciaId)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaExperienciaViewModel modelo = new ListaExperienciaViewModel
            {
                Paginacao = paginacao,
                Experiencias = experiencias,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);
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
                return View("Inexistente");
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
                //return RedirectToAction(nameof(Index));
                ViewBag.Mensagem = "Experiência adicionada com sucesso.";
                return View("Sucesso");
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
                return View("Inexistente");
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
                        return View("EliminarInserir", experiencia);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ocorreu um erro. Não foi possível guardar o produto. Tente novamente e se o problema persistir contacte a assistência.");
                        return View(experiencia);
                    }
                }
                //return RedirectToAction(nameof(Index));
                ViewBag.Mensagem = "Experiência alterada com sucesso";
                return View("Sucesso");
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
                ViewBag.Mensagem = "A Experiência que estava a tentar apagar foi eliminado por outra pessoa.";
                return View("Sucesso");
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
            ViewBag.Mensagem = "A Experiência foi eliminada com sucesso";
            return View("Sucesso");
        }

        private bool ExperienciaExists(int id)
        {
            return bd.Experiencia.Any(e => e.ExperienciaId == id);
        }
    }
}
