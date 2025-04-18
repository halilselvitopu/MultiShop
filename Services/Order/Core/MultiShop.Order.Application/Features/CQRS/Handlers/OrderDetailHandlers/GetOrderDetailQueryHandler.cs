﻿using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IReadRepository<OrderDetail> _readRepository;

        public GetOrderDetailQueryHandler(IReadRepository<OrderDetail> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var values = await _readRepository.GetAllAsync();
            return values.Select(x => new GetOrderDetailQueryResult
            {
                Id = x.Id,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductAmount = x.ProductAmount,
                ProductTotalPrice = x.ProductTotalPrice,
                OrderingId = x.OrderingId
            }).ToList();

        }
    }
}
