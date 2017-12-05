using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Entities
{
    public class Persona
    {
        private int _id;
        private string _nombre;
        private string _apellidos;
        private DateTime _fechaNac;


        public Persona()
        {
            _id = 0;
            _nombre = "";
            _apellidos = "";
            _fechaNac = new DateTime();
        }

        
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }


        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nombre")]
        public string nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = value;
            }
        }

        public string apellidos
        {
            get
            {
                return this._apellidos;
            }
            set
            {
                this._apellidos = value;
            }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name ="Fecha Nacimiento")]
        public DateTime fechaNac
        {
            get
            {
                return this._fechaNac;
            }
            set
            {
                this._fechaNac = value;
            }
        }



    }
}