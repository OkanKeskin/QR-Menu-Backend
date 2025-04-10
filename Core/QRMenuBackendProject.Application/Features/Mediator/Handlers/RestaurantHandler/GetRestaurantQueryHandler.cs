using MediatR;
using Microsoft.IdentityModel.Tokens;
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
    public class GetRestaurantQueryHandler : IRequestHandler<GetRestaurantQuery, List<GetRestaurantQueryResult>>
    {
        private readonly IRepository<Restaurant> _repository;

        public GetRestaurantQueryHandler(IRepository<Restaurant> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRestaurantQueryResult>> Handle(GetRestaurantQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetRestaurantQueryResult
            {
                Address = x.Address,
                City = x.City,
                District = x.District,
                Id = x.Id,
                Name = x.Name,
                ContentType = x.ContentType,
            }).ToList();
        }
    }
}
