using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DataAnnotation.Models.Entities;
using DataAnnotation.Models.List;


namespace DataAnnotation.Models.ViewModel
{
    public class ModelForView
    {
        public ListDepartamentos listaDepartamentos { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public int id { get; set; }

        public int idDepartamento { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nombre")]
        public String nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(50)]
        [Display(Name = "Apellido")]
        public String apellido { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fechaNac { get; set; }

        [MaxLength(200)]
        public String direccion { get; set; }

        [RegularExpression("9[0-9]{8}")]//"^ [9]{1} [0-9]{8} $"
        public String telefono { get; set; }

        public ModelForView()
        {
            listaDepartamentos = new ListDepartamentos();
            id = 0;
            idDepartamento = 0;
            nombre = "Iván";
            apellido = "Castillo";
            fechaNac = new DateTime(1990, 10, 2);
            direccion = "C/ S/N";
            telefono = "955111111";
        }


    }
}