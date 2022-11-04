using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Interfaces;
using infrastructure.Database.Repository;
using infrastructure.Database.StoreContext;

namespace infrastructure.Database.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Customer = new CustomerRepository(this._context);
        }

        public ICustomerRepository Customer {get; private set;}

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        
        public async Task RollbackAsync()
        {
            await _context.DisposeAsync();
        }
    }
}