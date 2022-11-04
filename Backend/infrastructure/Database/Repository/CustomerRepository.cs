using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using core.Entities;
using core.Interfaces;
using infrastructure.Database.Generic;
using infrastructure.Database.StoreContext;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Database.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Object> GetCustomerById(int id)
        {
            var cus = await _context.Customers
                .AsNoTracking()
                .AsQueryable()
                .Include(x => x.Country)
                .Include(a => a.CustomerAddresses)
                .SingleOrDefaultAsync(x => x.Id == id);
            
            return cus;
        }


        public async Task<IEnumerable<object>> ListOfCustomerName()
        {
            var lists = await (from customer in _context.Customers 
                                 select new {
                                    Id = customer.Id,
                                    Name = customer.CustomerName
                                 }
                                
                                ).ToListAsync();
                                
            return lists;
        }

        
    }
}