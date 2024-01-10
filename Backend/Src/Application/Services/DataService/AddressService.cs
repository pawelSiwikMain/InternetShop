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

        public void DeleteAddress(int id)
        {
            var address = _addressRepository.Get(id);
            _addressRepository.Delete(address);
        }

        public AddressDto GetByIdAddress(int id)
        {
            var address = _addressRepository.Get(id);
            return _mapper.Map<AddressDto>(address);
        }

        public AddressDto GetByUserId(int id)
        {
            var address =_addressRepository.GetByUserId(id);
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
