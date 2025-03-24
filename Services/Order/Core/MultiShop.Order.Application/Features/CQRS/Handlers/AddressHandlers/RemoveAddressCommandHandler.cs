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
    public class RemoveAddressCommandHandler
    {
        private readonly IWriteRepository<Address> _readRepository;
        private readonly IWriteRepository<Address> _writeRepository;

        public RemoveAddressCommandHandler(IWriteRepository<Address> writeRepository, IWriteRepository<Address> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(RemoveAddressCommand command)
        {
            var value = await _readRepository.GetByIdAsync(command.Id);
            await _writeRepository.DeleteAsync(value);
        }
    }
}
