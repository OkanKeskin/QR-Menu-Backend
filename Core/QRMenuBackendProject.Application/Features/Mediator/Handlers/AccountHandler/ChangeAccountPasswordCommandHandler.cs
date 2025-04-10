using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.AccountCommands;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.AccountHandler
{
    public class ChangeAccountPasswordCommandHandler : IRequestHandler<ChangeAccountPasswordCommand>
    {
        private readonly IRepository<Accounts> _repository;

        public ChangeAccountPasswordCommandHandler(IRepository<Accounts> repository)
        {
            _repository = repository;
        }
        public async Task Handle(ChangeAccountPasswordCommand request, CancellationToken cancellationToken)
        {
            var acc = await _repository.GetByFilterAsync(a => a.Email == request.Email);
            acc.Password = request.Password;
            await _repository.UpdateAsync(acc);
        }
    }
}
