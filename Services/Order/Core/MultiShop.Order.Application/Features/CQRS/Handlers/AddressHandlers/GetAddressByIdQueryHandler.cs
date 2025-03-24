using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IWriteRepository<Address> _readRepository;

        public GetAddressByIdQueryHandler(IWriteRepository<Address> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var values = await _readRepository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult
            {
                Id = values.Id,
                UserId = values.UserId,
                City = values.City,
                District = values.District,
                Detail = values.Detail
            };
        }
    }
}
