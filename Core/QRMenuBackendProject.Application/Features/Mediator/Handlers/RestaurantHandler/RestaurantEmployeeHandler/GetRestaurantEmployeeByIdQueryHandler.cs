using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Queries.RestaurantQueries.RestaurantEmployeeQueries;
using QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults;
using QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults.RestaurantEmployees;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.RestaurantHandler.RestaurantEmployeeHandler
{
    public class GetRestaurantEmployeeByIdQueryHandler : IRequestHandler<GetRestaurantEmployeeByIdQuery, GetRestaurantEmployeeByIdQueryResult>
    {
        private readonly IRepository<RestaurantEmployee> _repository;

        public GetRestaurantEmployeeByIdQueryHandler(IRepository<RestaurantEmployee> repository)
        {
            _repository = repository;
        }

        public async Task<GetRestaurantEmployeeByIdQueryResult> Handle(GetRestaurantEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id);
            return new GetRestaurantEmployeeByIdQueryResult
            {
                Id = result.Id,
                DateOfStart = result.DateOfStart,
                Name = result.Name,
                Surname = result.Surname,
                PhoneNumber = result.PhoneNumber,
                TCKN = result.TCKN,
                Email = result.Email,
                Position = result.Position,
                Image = result.Image,
                RestaurantId = result.RestaurantId
            };
        }
    }
}
