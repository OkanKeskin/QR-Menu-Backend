using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Queries.CompanyQueries;
using QRMenuBackendProject.Application.Features.Mediator.Results.CompanyResults;
using QRMenuBackendProject.Application.Features.Mediator.Results.InvoiceResults;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Application.Interfaces.FavoriteRestaurantInterface;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.CompanyHandler
{
    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, GetCompanyByIdQueryResults>
    {
        private readonly IRepository<Company> _repository;

        public GetCompanyByIdQueryHandler(IRepository<Company> repository)
        {
            _repository = repository;
        }
        public async Task<GetCompanyByIdQueryResults> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id);
            return new GetCompanyByIdQueryResults
            {
                CompanyName = result.CompanyName,
                Email = result.Email,
                Image = result.Image,
                Name = result.Name,
                PhoneNumber = result.PhoneNumber,
                Surname = result.Surname
            };
        }
    }
}
