using Microsoft.AspNetCore.Identity;
using PaginaPessoal2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaginaPessoal2.Data
{
    public class SeedData
    {

        private const string NOME_UTILIZADOR_ADMIN_PADRAO = "admin@ipg.pt";
        private const string PASSWORD_UTILIZADOR_ADMIN_PADRAO = "Secret123$";

        private const string ROLE_ADIMINISTRADOR = "Administrador";
        private const string ROLE_UTILIZADOR = "Utilizador";
        
        internal static void PreencheDadosficticios(PaginaPessoalDBContext bd)
        {
            InsereExperienciaficticia(bd);
            Inserehabilitacoesficticia(bd);
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

        private static void Inserehabilitacoesficticia(PaginaPessoalDBContext bd)
        {
            if (bd.Habilitacoes.Any()) return;

            bd.Habilitacoes.AddRange(new Habilitacoes[] {
                new Habilitacoes
                {
                    Ano = "1994",
                    Curso = "12º ano Técnico-Profissional de Contabilidade e Administração",
                    Instituicao = "E.S.S.João do Estoril",

                },
                new Habilitacoes
                {
                    Ano = "2002",
                    Curso = "Bacharelato Engenharia Informática",
                    Instituicao = " Instituto Politácnio da Guarda",

                }
            });

            bd.SaveChanges();
        }



        internal static async Task InsereUtilizadoresFicticiosAsync(UserManager<IdentityUser> gestorUtilizadores)
        {
            IdentityUser utilizador = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, "joao@ipg.pt", "Secret123$");
            await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, utilizador, ROLE_UTILIZADOR);


        }

        internal static async Task InsereRolesAsync(RoleManager<IdentityRole> gestorRoles)
        {
            await CriaRoleSeNecessario(gestorRoles, ROLE_ADIMINISTRADOR);
            await CriaRoleSeNecessario(gestorRoles, ROLE_UTILIZADOR);

        }

        private static async Task CriaRoleSeNecessario(RoleManager<IdentityRole> gestorRoles, string funcao)
        {
            if (!await gestorRoles.RoleExistsAsync(funcao))
            {
                IdentityRole role = new IdentityRole(funcao);
                await gestorRoles.CreateAsync(role);
            }
        }

        internal static async Task InsereAdministradorPadraoAsync(UserManager<IdentityUser> gestorUtilizadores)
        {
            IdentityUser utilizador = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, NOME_UTILIZADOR_ADMIN_PADRAO, PASSWORD_UTILIZADOR_ADMIN_PADRAO);
            await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, utilizador, ROLE_ADIMINISTRADOR);
        }

        private static async Task AdicionaUtilizadorRoleSeNecessario(UserManager<IdentityUser> gestorUtilizadores, IdentityUser utilizador, string role)
        {
            if (!await gestorUtilizadores.IsInRoleAsync(utilizador, role))
            {
                await gestorUtilizadores.AddToRoleAsync(utilizador, role);
            }
        }

        private static async Task<IdentityUser> CriaUtilizadorSeNaoExiste(UserManager<IdentityUser> gestorUtilizadores, string nomeUtilizador, string password)
        {
            IdentityUser utilizador = await gestorUtilizadores.FindByNameAsync(nomeUtilizador);

            if (utilizador == null)
            {
                utilizador = new IdentityUser(nomeUtilizador);
                await gestorUtilizadores.CreateAsync(utilizador, password);
            }

            return utilizador;
        }
    }
}
