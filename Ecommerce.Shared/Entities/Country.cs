using System;
<<<<<<< HEAD
using System.ComponentModel;
=======
>>>>>>> cb0bdcc138b7856e9375df06e0075ae12405c89e
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Shared.Entities
{
    public class Country
    {

        public int Id { get; set; }


        [Display(Name ="Pais")]
        [Required(ErrorMessage = "El Campo {0} Es Obligatorio ")]
        [MaxLength(100)]
        public string Name { get; set; }

<<<<<<< HEAD

        public ICollection<State> States { get; set; }


        [Display(Name ="Estados/Departamentos")]
        public int StatesNumber =>States==null? 0:States.Count(); 

=======
>>>>>>> cb0bdcc138b7856e9375df06e0075ae12405c89e
    }
}
