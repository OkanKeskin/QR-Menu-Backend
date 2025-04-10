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
    public class GetRestaurantTableByIdQueryHandler : IRequestHandler<GetRestaurantTableByIdQuery, GetRestaurantTableByIdQueryResult>
    {
        private readonly IRepository<RestaurantTable> _repository;

        public GetRestaurantTableByIdQueryHandler(IRepository<RestaurantTable> repository)
        {
            _repository = repository;
        }

        public async Task<GetRestaurantTableByIdQueryResult> Handle(GetRestaurantTableByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id);
            return new GetRestaurantTableByIdQueryResult
            {
                Id = result.Id,
                QrUrl = result.QrUrl,
                TableCapacity = result.TableCapacity,
                TableNo = result.TableNo,
                RestaurantId = result.RestaurantId
            };
        }
    }
}
