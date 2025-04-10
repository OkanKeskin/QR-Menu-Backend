using MediatR;
using Microsoft.AspNetCore.Mvc;
using QRMenuBackendProject.Application.Features.Mediator.Commands.AccountCommands;
using QRMenuBackendProject.Application.Features.Mediator.Commands.CompanyCommands;
using QRMenuBackendProject.Application.Features.Mediator.Commands.CoustomerCommands;
using QRMenuBackendProject.Application.Features.Mediator.Commands.EmployeeCommands;
using QRMenuBackendProject.Application.Features.Mediator.Queries.AccountQueries;
using QRMenuBackendProject.Application.Tools;
using QRMenuBackendProject.WebApi.Models;

namespace QRMenuBackendProject.WebApi.Controllers.Account
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(GetCheckAccountQuery query)
        {
            var values = await _mediator.Send(query);
            if (values.IsExist)
            {
                return Created("", JwtTokenGenerator.GenerateToken(values));
            }
            else
            {
                return BadRequest("Email veya Şifre hatalıdır");
            }
        }

        [HttpPost("company")]
        public async Task<IActionResult> RegisterCompany(CompanyRegisterModel query)
        {
            //Company Oluştur
            //Account Oluştur
            var createAcc = new CreateAccountCommand
            {
                Password = query.Password,
                Email = query.Email,
                Type = Domain.Enums.AccountsType.Company
            };
            var res = await _mediator.Send(createAcc);

            var createCom = new CreateCompanyCommand
            {
                AccountsId = res,
                CompanyName = query.CompanyName,
                Email = query.Email,
                Name = query.OwnerName,
                PhoneNumber = query.PhoneNumber,
                Surname = query.OwnerSurname,
            };
            var co = await _mediator.Send(createCom);

            return Ok(co);
        }

        [HttpPost("customer")]
        public async Task<IActionResult> RegisterCoustomer(CustomerRegisterModel query)
        {
            //coustomer Oluştur
            //Account Oluştur
            var createAcc = new CreateAccountCommand
            {
                Password = query.Password,
                Email = query.Email,
                Type = Domain.Enums.AccountsType.Customer
            };
            var res = await _mediator.Send(createAcc);

            var createCus = new CreateCustomerCommand
            {
                AccountsId = res,
                Email = query.Email,
                Name = query.Name,
                PhoneNumber = query.PhoneNumber,
                Surname = query.Surname,
            };
            var cus = await _mediator.Send(createCus);

            return Ok(cus);
        }

        [HttpPost("employee")]
        public async Task<IActionResult> RegisterEmployee(EmployeeRegisterModel query)
        {
            //employee Oluştur
            //Account Oluştur

            var createAcc = new CreateAccountCommand
            {
                Password = query.TCKN,
                Email = query.Email,
                Type = Domain.Enums.AccountsType.Employee
            };
            var res = await _mediator.Send(createAcc);

            var createEmp = new CreateEmployeeCommand
            {
                AccountsId = res,
                Email = query.Email,
                Name = query.Name,
                PhoneNumber = query.PhoneNumber,
                Surname = query.Surname,
                DateOfStart = query.DateOfStart,
                TCKN = query.TCKN,
                Position = query.Position,
                RestaurantId = query.RestaurantId
            };
            var emp = await _mediator.Send(createEmp);
            return Ok(emp);
        }

        [HttpPost("password/change")]
        public async Task<IActionResult> ChangePassword(AccountPasswordChangeModel query)
        {
            var change = new ChangeAccountPasswordCommand
            {
                Email = query.Email,
                Password = query.Password,
            };
            await _mediator.Send(change);

            return Ok();
        }
    }
}
