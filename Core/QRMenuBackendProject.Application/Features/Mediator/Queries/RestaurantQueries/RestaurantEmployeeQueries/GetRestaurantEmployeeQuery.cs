using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults.RestaurantEmployees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Queries.RestaurantQueries.RestaurantEmployeeQueries
{
    public class GetRestaurantEmployeeQuery : IRequest<List<GetRestaurantEmployeeQueryResult>>
    {
        public Guid Id { get; set; }
        public GetRestaurantEmployeeQuery(Guid ıd)
        {
            Id = ıd;
        }
    }
}
