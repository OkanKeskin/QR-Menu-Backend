using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults.RestaurantCommentResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Queries.RestaurantQueries.RestaurantCommentQueries
{
    public class GetRestaurantCommentByRestaurantIdQuery : IRequest<List<GetRestaurantCommentByRestaurantIdQueryResult>>
    {
        public Guid Id { get; set; }

        public GetRestaurantCommentByRestaurantIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
