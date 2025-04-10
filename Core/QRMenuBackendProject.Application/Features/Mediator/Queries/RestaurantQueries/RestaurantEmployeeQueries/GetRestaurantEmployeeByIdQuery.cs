using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults;
using QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults.RestaurantEmployees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Queries.RestaurantQueries.RestaurantEmployeeQueries
{
    public class GetRestaurantEmployeeByIdQuery :IRequest<GetRestaurantEmployeeByIdQueryResult>
    {
        public Guid Id { get; set; }

        public GetRestaurantEmployeeByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
