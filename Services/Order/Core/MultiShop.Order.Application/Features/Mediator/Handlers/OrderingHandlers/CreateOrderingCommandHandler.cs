using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingComamnds;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
    {
        private readonly IWriteRepository<Ordering> _writeRepository;

        public CreateOrderingCommandHandler(IWriteRepository<Ordering> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {
            await _writeRepository.CreateAsync(new Ordering
            {
                UserId = request.UserId,
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
            });
        }
    }
}
