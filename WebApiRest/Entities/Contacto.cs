using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRest.Entities
{
    public class Contacto
    {
        [Key]
        public int idContacto { get; set; }
        public string nombreCompleto { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public DateTime fechaNacimiento { get; set; }
    }
}
