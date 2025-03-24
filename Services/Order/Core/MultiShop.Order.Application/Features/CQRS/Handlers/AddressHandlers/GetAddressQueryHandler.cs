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
    public class GetAddressQueryHandler
    {
        private readonly IReadRepository<Address> _readRepository;
        public GetAddressQueryHandler(IReadRepository<Address> readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _readRepository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult
            {
                Id = x.Id,
                UserId = x.UserId,
                City = x.City,
                District = x.District,
                Detail = x.Detail

            }).ToList();
        }
    }
}
