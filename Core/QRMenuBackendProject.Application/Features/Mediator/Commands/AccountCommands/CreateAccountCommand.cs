using MediatR;
using QRMenuBackendProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.AccountCommands
{
    public class CreateAccountCommand : IRequest<Guid>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public AccountsType Type { get; set; }
    }
}
