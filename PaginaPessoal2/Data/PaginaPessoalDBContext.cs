using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaginaPessoal2.Models;

    public class PaginaPessoalDBContext : DbContext
    {
        public PaginaPessoalDBContext (DbContextOptions<PaginaPessoalDBContext> options)
            : base(options)
        {
        }

        public DbSet<PaginaPessoal2.Models.Experiencia> Experiencia { get; set; }
    }
