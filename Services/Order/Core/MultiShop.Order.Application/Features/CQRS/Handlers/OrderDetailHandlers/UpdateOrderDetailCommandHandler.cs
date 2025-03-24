using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IReadRepository<OrderDetail> _readRepository;
        private readonly IWriteRepository<OrderDetail> _writeRepository;

        public UpdateOrderDetailCommandHandler(IWriteRepository<OrderDetail> writeRepository, IReadRepository<OrderDetail> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var value = await _readRepository.GetByIdAsync(command.Id);

            value.ProductId = command.ProductId;
            value.ProductName = command.ProductName;
            value.ProductPrice = command.ProductPrice;
            value.ProductAmount = command.ProductAmount;
            value.ProductTotalPrice = command.ProductTotalPrice;
            value.OrderingId = command.OrderingId;
            await _writeRepository.UpdateAsync(value);
        }
    }
}
