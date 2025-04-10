using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.OrdersResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Queries.OrdersQueries
{
    public class GetOrdersListByRestaurantIdQuery : IRequest<List<GetOrdersListByRestaurantIdQueryResult>>
    {
        public Guid RestaurantId { get; set; }

        public GetOrdersListByRestaurantIdQuery(Guid restaurantId)
        {
            RestaurantId = restaurantId;
        }
    }
}
