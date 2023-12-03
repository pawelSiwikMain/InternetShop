using Domain.entities;
using Domain.interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ShopContext _context;

        public AddressRepository(ShopContext context)
        {
            this._context = context;
        }

        public Address Add(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return address;
        }

        public void Delete(Address address)
        {
            _context.Addresses.Remove(address);
            _context.SaveChanges();
        }

        public Address Get(int id)
        {
            return _context.Addresses.SingleOrDefault(a => a.Id == id);
        }
        public void Update(Address address)
        {
            _context.Addresses.Update(address);
            _context.SaveChanges();
        }
    }
}
