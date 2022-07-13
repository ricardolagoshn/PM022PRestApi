using System;
using System.Collections.Generic;
using System.Text;

namespace PM022PRestApi.Models
{
  public class Alumno
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public int edad { get; set; }
        public string direccion { get; set; }
        public string sexo { get; set; }
        public string idcarrera { get; set; }
        public string foto { get; set; }
    }
}
