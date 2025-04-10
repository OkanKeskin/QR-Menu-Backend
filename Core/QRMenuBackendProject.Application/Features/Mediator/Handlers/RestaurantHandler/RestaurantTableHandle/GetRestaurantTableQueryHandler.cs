using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Queries.RestaurantQueries;
using QRMenuBackendProject.Application.Features.Mediator.Queries.RestaurantQueries.RestaurantTableQueries;
using QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults;
using QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults.RestaurantTableResult;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.RestaurantHandler.RestaurantTableHandle
{
    public class GetRestaurantTableQueryHandler : IRequestHandler<GetRestaurantTableQuery, List<GetRestaurantTableQueryResult>>
    {
        private readonly IRepository<RestaurantTable> _repository;

        public GetRestaurantTableQueryHandler(IRepository<RestaurantTable> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetRestaurantTableQueryResult>> Handle(GetRestaurantTableQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetRestaurantTableQueryResult
            {
                Id = x.Id,
                TableNo = x.TableNo,
                TableCapacity = x.TableCapacity,
                QrUrl = x.QrUrl,
                RestaurantId = x.RestaurantId
            }).ToList();
        }
    }
}
