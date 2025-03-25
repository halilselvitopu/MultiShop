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
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IReadRepository<Ordering> _readRepository;
        private readonly IWriteRepository<Ordering> _writeRepository;

        public UpdateOrderingCommandHandler(IWriteRepository<Ordering> writeRepository, IReadRepository<Ordering> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var values = await _readRepository.GetByIdAsync(request.Id);
            values.UserId = request.UserId;
            values.OrderDate = request.OrderDate;
            values.TotalPrice = request.TotalPrice;
            await _writeRepository.UpdateAsync(values);
        }
    }
}
