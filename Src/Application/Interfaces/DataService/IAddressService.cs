using Application.Dtos.AddressDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.DataService
{
    public interface IAddressService
    {
        AddressDto AddAddress(CreateAddressDto address);
        AddressDto GetByIdAddress(int id);
        void UpdateAddress(UpdateAddressDto address);
        void DeleteAddress(int id);
        
    }
}
