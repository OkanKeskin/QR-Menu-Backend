using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Queries.CompanyQueries;
using QRMenuBackendProject.Application.Features.Mediator.Queries.CustomerQueries;
using QRMenuBackendProject.Application.Features.Mediator.Results.CompanyResults;
using QRMenuBackendProject.Application.Features.Mediator.Results.CustomerResults;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.CustomerHandler
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdQueryResults>
    {
        private readonly IRepository<Customer> _repository;

        public GetCustomerByIdQueryHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }
        public async Task<GetCustomerByIdQueryResults> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id);
            return new GetCustomerByIdQueryResults
            {
                Name = result.Name,
                Surname = result.Surname,
                PhoneNumber = result.PhoneNumber,
                Image = result.Image,
                Email = result.Email
            };
        }
    }
}
