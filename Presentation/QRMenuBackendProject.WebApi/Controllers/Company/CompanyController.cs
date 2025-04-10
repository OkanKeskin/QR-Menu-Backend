using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QRMenuBackendProject.Application.Features.Mediator.Commands.CompanyCommands;
using QRMenuBackendProject.Application.Features.Mediator.Commands.InvoiceCommands;
using QRMenuBackendProject.Application.Features.Mediator.Queries.CompanyQueries;
using QRMenuBackendProject.Application.Features.Mediator.Queries.OrdersQueries.OrderItemsQueries;

namespace QRMenuBackendProject.WebApi.Controllers.Company
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{companyId}")]
        public async Task<IActionResult> GetCompanyById([BindRequired] Guid companyId)
        {
            var values = await _mediator.Send(new GetCompanyByIdQuery(companyId));
            return Ok(values);
        }

        [HttpPut("{companyId}")]
        public async Task<IActionResult> PutCompanyById(UpdateCompanyCommand commad)
        {
            await _mediator.Send(commad);
            return Ok("Güncellendi");
        }
    }
}
