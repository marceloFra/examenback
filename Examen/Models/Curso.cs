using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Examen.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Nota = new HashSet<Nota>();
        }

        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public string Obligatoriedad { get; set; }

        public virtual ICollection<Nota> Nota { get; set; }
    }
}
