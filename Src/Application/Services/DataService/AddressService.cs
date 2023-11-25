using Application.Dtos.AddressDtos;
using Application.Interfaces.DataService;
using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.DataService
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public AddressDto AddAddress(CreateAddressDto address)
        {
            throw new NotImplementedException();
        }

        public void DeleteAddress(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AddressDto> GetAllAddresses()
        {
            throw new NotImplementedException();
        }

        public AddressDto GetByIdAddress(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAddress(AddressDto address)
        {
            throw new NotImplementedException();
        }
    }
}
