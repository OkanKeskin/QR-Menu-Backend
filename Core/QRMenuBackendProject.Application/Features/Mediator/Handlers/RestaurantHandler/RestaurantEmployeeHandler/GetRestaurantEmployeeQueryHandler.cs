using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Queries.RestaurantQueries.RestaurantEmployeeQueries;
using QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults;
using QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults.RestaurantEmployees;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.RestaurantHandler.RestaurantEmployeeHandler
{
    public class GetRestaurantEmployeeQueryHandler : IRequestHandler<GetRestaurantEmployeeQuery, List<GetRestaurantEmployeeQueryResult>>
    {
        private readonly IRepository<RestaurantEmployee> _repository;

        public GetRestaurantEmployeeQueryHandler(IRepository<RestaurantEmployee> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRestaurantEmployeeQueryResult>> Handle(GetRestaurantEmployeeQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterListAsync(a=>a.RestaurantId == request.Id);
            return values.Select(x => new GetRestaurantEmployeeQueryResult
            {
                RestaurantId = x.Id,
                Position = x.Position,
                PhoneNumber = x.PhoneNumber,
                Surname = x.Surname,
                Email = x.Email,
                TCKN = x.TCKN,
                Name = x.Name,
                Id = x.Id,
                Image = x.Image,
                DateOfStart = x.DateOfStart
            }).ToList();
        }

    }
}
