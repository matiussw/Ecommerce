using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Shared.DTOs
{
    public class LoginDTO
    {
     

        [Required(ErrorMessage = "El Campo {0} Es Requerido")]
        [EmailAddress (ErrorMessage = "Debe Ingresar Un Email Valido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

  
        [Display(Name = "Contrasena")]
        [Required(ErrorMessage = "El Campo {0} Es Requerido")]
        [MinLength(6, ErrorMessage = "El Campo {0} debe tener  almenos {1} Caracteres")]
        public string Password { get; set; }



    }
}
