using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.CompanyResults;
using QRMenuBackendProject.Application.Features.Mediator.Results.FavoriteRestaurantResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Queries.CompanyQueries
{
    public class GetCompanyByIdQuery : IRequest<GetCompanyByIdQueryResults>
    {
        public Guid Id { get; set; }

        public GetCompanyByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
