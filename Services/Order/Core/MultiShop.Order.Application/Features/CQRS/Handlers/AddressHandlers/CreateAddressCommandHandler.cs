using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler 
    {
        private readonly IWriteRepository<Address> _writeRepository;

        public CreateAddressCommandHandler(IWriteRepository<Address> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(CreateAddressCommand command)
        {
            await _writeRepository.CreateAsync(new Address
            {
                UserId = command.UserId,
                City = command.City,
                District = command.District,
                Detail = command.Detail
            });
        }
    }
}
