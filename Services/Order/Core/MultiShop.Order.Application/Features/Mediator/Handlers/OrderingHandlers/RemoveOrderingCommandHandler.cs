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
    public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommand>
    {
        private readonly IWriteRepository<Ordering> _writeRepository;
        private readonly IReadRepository<Ordering> _readRepository;

        public RemoveOrderingCommandHandler(IReadRepository<Ordering> readRepository, IWriteRepository<Ordering> writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
        {
            var values = await _readRepository.GetByIdAsync(request.Id);
            await _writeRepository.RemoveAsync(values);
        }
    }
}
