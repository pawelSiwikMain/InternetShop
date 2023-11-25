using Application.Dtos.AddressDtos;
using Application.Interfaces.DataService;
using AutoMapper;
using Domain.entities;
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
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public AddressDto AddAddress(CreateAddressDto address)
        {
            var newAddress = _mapper.Map<Address>(address);
            _addressRepository.Add(newAddress);
            return _mapper.Map<AddressDto>(newAddress);
        }

        public void DeleteAddress(string id)
        {
            var address = _addressRepository.Get(id);
            _addressRepository.Delete(address);
        }

        public IEnumerable<AddressDto> GetAllAddresses()
        {
            var addresses = _addressRepository.GetAll();
            return _mapper.Map<IEnumerable<AddressDto>>(addresses);
        }

        public AddressDto GetByIdAddress(string id)
        {
            var address = _addressRepository.Get(id);
            return _mapper.Map<AddressDto>(address);
        }

        public void UpdateAddress(UpdateAddressDto address)
        {
            var existingAddress = _addressRepository.Get(address.Id);
            var newAddress = _mapper.Map(address, existingAddress);
            _addressRepository.Update(newAddress); 
        }
    }
}
