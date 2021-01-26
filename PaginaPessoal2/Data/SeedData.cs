using PaginaPessoal2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaginaPessoal2.Data
{
    public class SeedData
    {
        internal static void PreencheDadosExperienciaficticia(PaginaPessoalDBContext bd)
        {
            InsereExperienciaficticia(bd);
        }

        private static void InsereExperienciaficticia(PaginaPessoalDBContext bd)
        {
            if (bd.Experiencia.Any()) return;

            bd.Experiencia.AddRange(new Experiencia[] {
                new Experiencia
                {
                    Ano = "2018/2019",
                    Empresa = "Visabeira",
                    Cargo = "Responsável Administrativo e de armazém",
                    
                },
                new Experiencia
                {
                    Ano = "2016/2017",
                    Empresa = "Omega Hotel London",
                    Cargo = "Recepcionista",

                },
                new Experiencia
                {
                    Ano = "2013/2014",
                    Empresa = "NA Cobranças",
                    Cargo = "Responsável de cobranças",

                }
            });

            bd.SaveChanges();
        }
    }
}
