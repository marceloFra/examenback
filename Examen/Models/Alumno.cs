using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Examen.Models
{
    public partial class Alumno
    {
        public Alumno()
        {
            Nota = new HashSet<Nota>();
        }

        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string ApellidoMaterno { get; set; }
        public string ApellidoPaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }

        public virtual ICollection<Nota> Nota { get; set; }
    }
}
