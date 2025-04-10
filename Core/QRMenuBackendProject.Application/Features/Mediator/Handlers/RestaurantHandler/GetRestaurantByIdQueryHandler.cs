using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Queries.RestaurantQueries;
using QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.RestaurantHandler
{
    public class GetRestaurantByIdQueryHandler : IRequestHandler<GetRestaurantByIdQuery, GetRestaurantByIdQueryResult>
    {
        private readonly IRepository<Restaurant> _repository;

        public GetRestaurantByIdQueryHandler(IRepository<Restaurant> repository)
        {
            _repository = repository;
        }

        public async Task<GetRestaurantByIdQueryResult> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id);
            return new GetRestaurantByIdQueryResult
            {
                Id = result.Id,
                Name = result.Name,
                Address = result.Address,
                City = result.City,
                District = result.District,
				ContentType = result.ContentType,
			};  
        }
    }
}
