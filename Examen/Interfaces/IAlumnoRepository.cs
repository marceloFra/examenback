using Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Interfaces
{
    public interface IAlumnoRepository: IDisposable
    {
        Task<List<Alumno>> GetAlumno();
    }
}
