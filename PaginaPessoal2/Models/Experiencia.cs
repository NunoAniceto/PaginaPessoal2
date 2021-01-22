using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaginaPessoal2.Models
{
    public class Experiencia
    {
            public int ExperienciaId { get; set; }

            [Required(ErrorMessage = "Deve preencher o(s) ano(s).")]
            public string Ano { get; set; }

            [Required(ErrorMessage = "Deve preencher a empresa.")]
            public string Empresa { get; set; }

            [Required(ErrorMessage = "Deve preencher o cargo.")]
            public string Cargo { get; set; }
            
        

    }
}
