using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.CompanyResults;
using QRMenuBackendProject.Application.Features.Mediator.Results.CustomerResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Queries.CustomerQueries
{
    public class GetCustomerByIdQuery : IRequest<GetCustomerByIdQueryResults>
    {
        public Guid Id { get; set; }

        public GetCustomerByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
