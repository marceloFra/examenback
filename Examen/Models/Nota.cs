using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Examen.Models
{
    public partial class Nota
    {
        public int? IdNota  { get; set; }
        public int IdAlumno { get; set; }
        public int IdCurso { get; set; }
        public decimal PracticaA { get; set; }
        public decimal PracticaB { get; set; }
        public decimal PracticaC { get; set; }
        public decimal Promedio { get; set; }

        public virtual Alumno? IdAlumnoNavigation { get; set; }
        public virtual Curso? IdCursoNavigation { get; set; }
    }
}
