using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.AccountResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Queries.AccountQueries
{
    public class GetCheckAccountQuery : IRequest<GetCheckAccountQueryResults>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
