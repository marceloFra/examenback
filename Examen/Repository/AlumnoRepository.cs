using Examen.Interfaces;
using Examen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Repository
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly BDExamenContext _context;
        public AlumnoRepository(BDExamenContext context)
        {
            _context = context;
        }
         

        public async Task<List<Alumno>> GetAlumno()
        {
            return await _context.Alumno.ToListAsync();
        }
        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
