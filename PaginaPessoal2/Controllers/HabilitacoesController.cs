using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Create([Bind("HabilitacoesId,Ano,Curso,Instituicao")] Habilitacoes habilitacoes, IFormFile ficheiroFoto)
        {
            if (ModelState.IsValid)
            {

                AtualizaFotohabilitacoes(habilitacoes, ficheiroFoto);
                bd.Add(habilitacoes);
                await bd.SaveChangesAsync();
                ViewBag.Mensagem = "Habilitação adicionada com sucesso.";
                return View("Sucesso");


            }
            return View(habilitacoes);
        }

        private static void AtualizaFotohabilitacoes(Habilitacoes habilitacoes, IFormFile ficheiroFoto)
        {
            if (ficheiroFoto != null && ficheiroFoto.Length > 0)
            {
                using (var ficheiroMemoria = new MemoryStream())
                {
                    ficheiroFoto.CopyTo(ficheiroMemoria);
                    habilitacoes.Foto = ficheiroMemoria.ToArray();
                }
            }
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
        public async Task<IActionResult> Edit(int id, [Bind("HabilitacoesId,Ano,Curso,Instituicao,Foto")] Habilitacoes habilitacoes, IFormFile ficheiroFoto)
        {
            if (id != habilitacoes.HabilitacoesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    AtualizaFotohabilitacoes(habilitacoes, ficheiroFoto);
                    bd.Update(habilitacoes);
                    await bd.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabilitacoesExists(habilitacoes.HabilitacoesId))
                    {
                        return View("EliminarInserir", habilitacoes);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ocorreu um erro. Não foi possível guardar a habilitação. Tente novamente e se o problema persistir contacte a assistência.");
                        return View(habilitacoes);
                    }
                }
                ViewBag.Mensagem = "Habilitação alterada com sucesso";
                return View("Sucesso");
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
                ViewBag.Mensagem = "A Habilitação que estava a tentar apagar foi eliminado por outra pessoa.";
                return View("Sucesso");
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
            ViewBag.Mensagem = "A Habilitação foi eliminada com sucesso";
            return View("Sucesso");
        }

        private bool HabilitacoesExists(int id)
        {
            return bd.Habilitacoes.Any(e => e.HabilitacoesId == id);
        }
    }
}
