using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaginaPessoal2.Models
{
    public class RegistoUtilizadorViewModel
    {
        [Required]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }

        [Required]
        [StringLength(256)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(256)]
        [Compare("Password", ErrorMessage = "Palavra-passe não coincidente")]
        [Display(Name = "Confirme a password")]
        [DataType(DataType.Password)]
        public string ConfirmePassword { get; set; }
    }
}
