using System.ComponentModel.DataAnnotations;
using Ecommerce.Shared.Enums;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Shared.Entities
{
    public  class User :IdentityUser
    {
        [Display(Name = "El Documento Es Obligatorio")]
        [Required(ErrorMessage = "El Campo {0} Es Obligatorio ")]
        [MaxLength(100)]
        public string  Document { get; set; }


        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; } = null!;
        [Display(Name = "Apellidos")]

        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Dirección")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Address { get; set; } = null!;
        [Display(Name = "Tipo de usuario")]
        public UserType UserType { get; set; }
        public City? City { get; set; }

        [Display(Name = "Ciudad")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una {0}.")]
        public int CityId { get; set; }

        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName}";


    }
}
