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
    public class UpdateAddressCommandHandler
    {
        private readonly IReadRepository<Address> _readRepository;
        private readonly IWriteRepository<Address> _writeRepository;

        public UpdateAddressCommandHandler(IWriteRepository<Address> writeRepository, IReadRepository<Address> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            var values = await _readRepository.GetByIdAsync(command.Id);
            values.UserId = command.UserId;
            values.City = command.City;
            values.District = command.District;
            values.Detail = command.Detail;
            await _writeRepository.UpdateAsync(values);
        }
    }
}
