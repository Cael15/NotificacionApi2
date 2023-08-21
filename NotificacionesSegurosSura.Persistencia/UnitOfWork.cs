using NotificacionesSegurosSura.Domain.Interfaces;
using NotificacionesSegurosSura.Persistencia.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotificacionesSegurosSura.Persistencia
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NotificacionesDbContext _context;

        public UnitOfWork(NotificacionesDbContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
