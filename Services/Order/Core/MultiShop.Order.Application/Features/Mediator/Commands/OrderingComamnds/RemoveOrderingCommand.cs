using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Commands.OrderingComamnds
{
    public class RemoveOrderingCommand(int id) : IRequest
    {
        public int Id { get; set; } = id;
    }
}
