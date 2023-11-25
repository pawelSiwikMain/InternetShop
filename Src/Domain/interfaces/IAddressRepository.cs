using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAll();
        Address Get(int id);
        Address Add(Address address);
        void Update(Address address);
        void Delete(Address address);
    }
}
