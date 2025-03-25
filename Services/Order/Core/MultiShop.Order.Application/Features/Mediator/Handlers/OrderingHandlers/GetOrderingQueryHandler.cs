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
    public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
    {
        private readonly IReadRepository<Ordering> _readRepository;

        public GetOrderingQueryHandler(IReadRepository<Ordering> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
           var values = await _readRepository.GetAllAsync();
            return values.Select(x => new GetOrderingQueryResult
            {
                Id = x.Id,
                UserId = x.UserId,
                TotalPrice = x.TotalPrice,
                OrderDate = x.OrderDate,

            }).ToList();
        }
    }
}
