using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QRMenuBackendProject.Application.Features.Mediator.Commands.CoustomerCommands;
using QRMenuBackendProject.Application.Features.Mediator.Commands.InvoiceCommands;
using QRMenuBackendProject.Application.Features.Mediator.Queries.CompanyQueries;
using QRMenuBackendProject.Application.Features.Mediator.Queries.CustomerQueries;
using QRMenuBackendProject.Application.Features.Mediator.Queries.OrdersQueries.OrderItemsQueries;

namespace QRMenuBackendProject.WebApi.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerById([BindRequired] Guid customerId)
        {
            var values = await _mediator.Send(new GetCustomerByIdQuery(customerId));
            return Ok(values);
        }
        
        [HttpPatch("{customerId}")]
        public async Task<IActionResult> UpdateCustomerById(UpdateCustomerCommand commad)
        {
            await _mediator.Send(commad);
            return Ok("Güncellendi");   
        }
        
    }
}
