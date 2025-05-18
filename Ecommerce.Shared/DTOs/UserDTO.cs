using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Shared.Entities;

namespace Ecommerce.Shared.DTOs
{
    public class UserDTO : User
    {
        [DataType(DataType.Password)]
        [Display(Name = "Contrasena")]
        [Required(ErrorMessage ="El Campo {0} Es Requerido")]
        [StringLength(20,MinimumLength =6 , ErrorMessage= "El Campo {0} debe tener {2} y {1} Caracteres")]

        public string Password { get; set; } = null!;

        [Compare("Password", ErrorMessage ="LA Contrasena de Confirmacion Debe Igual ")]
        [Display(Name = "Confirmacion Contrasena")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El Campo {0} Es Requerido")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El Campo {0} debe tener {2} y {1} Caracteres")]
        public string PasswordConfirm { get; set; } = null!;

    }
}
