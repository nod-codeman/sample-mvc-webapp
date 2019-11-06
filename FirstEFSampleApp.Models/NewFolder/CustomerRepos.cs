using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace FirstEFSampleApp.Models.NewFolder
{
    public class CustomerRepos
    {
        private MyDbContext _context;

        public CustomerRepos(MyDbContext ctx)
        {
            _context = ctx;
        }

        //returns only one customer information
        public async Task<Customer> Get(int? id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.ID == id);
            return customer;
        }
        
        //returns a list of all customers
        public async Task<List<Customer>> Get()
        {
            var customer = await _context.Customers.ToListAsync();
            return customer;
        }

        //create a new customer
        public async Task<bool> Add(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        //edit customer
        public async Task<bool> Edit(int id, Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var customer = await this.Get((int?)id);
            _context.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        //check if customer exists
        public bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.ID == id);
        }
    }
}
