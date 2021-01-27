using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaginaPessoal2.Models
{
    public class Habilitacoes
    {

        public int HabilitacoesId { get; set; }

        [Required(ErrorMessage = "Deve preencher o(s) ano(s).")]
        public string Ano { get; set; }

        [Required(ErrorMessage = "Deve preencher o curso.")]
        public string Curso { get; set; }

        [Required(ErrorMessage = "Deve preencher a Instituição.")]
        public string Instituicao { get; set; }
    }
}
