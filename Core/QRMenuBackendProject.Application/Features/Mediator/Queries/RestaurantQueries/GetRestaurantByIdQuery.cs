using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Queries.RestaurantQueries
{
    public class GetRestaurantByIdQuery: IRequest<GetRestaurantByIdQueryResult>
    {
        public Guid Id { get; set; }

        public GetRestaurantByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
