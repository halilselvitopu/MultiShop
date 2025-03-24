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
    public class CreateOrderDetailCommandHandler
    {
        private readonly IWriteRepository<OrderDetail> _writeRepository;

        public CreateOrderDetailCommandHandler(IWriteRepository<OrderDetail> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(CreateOrderDetailCommand command)
        {
            var orderDetail = new OrderDetail
            {
                ProductId = command.ProductId,
                ProductName = command.ProductName,
                ProductPrice = command.ProductPrice,
                ProductAmount = command.ProductAmount,
                ProductTotalPrice = command.ProductTotalPrice,
                OrderingId = command.OrderingId
            };
            await _writeRepository.CreateAsync(orderDetail);
        }
    }
}
