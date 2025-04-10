using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults;
using QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults.RestaurantTableResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Queries.RestaurantQueries.RestaurantTableQueries
{
    public class GetRestaurantTableQuery : IRequest<List<GetRestaurantTableQueryResult>>
    {
    }
}
