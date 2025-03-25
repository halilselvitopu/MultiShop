using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IReadRepository<Ordering> _readRepository;

        public GetOrderingByIdQueryHandler(IReadRepository<Ordering> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _readRepository.GetByIdAsync(request.Id);
            return new GetOrderingByIdQueryResult
            {
                Id = values.Id,
                UserId = values.UserId,
                OrderDate = values.OrderDate,
                TotalPrice = values.TotalPrice,
            };
        }
    }
}
