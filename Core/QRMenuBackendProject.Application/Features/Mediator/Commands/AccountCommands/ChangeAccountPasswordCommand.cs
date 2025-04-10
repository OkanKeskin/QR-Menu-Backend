using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.AccountCommands
{
    public class ChangeAccountPasswordCommand : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
