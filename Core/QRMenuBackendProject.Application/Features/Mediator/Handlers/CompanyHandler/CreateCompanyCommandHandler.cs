using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.AccountCommands;
using QRMenuBackendProject.Application.Features.Mediator.Commands.CompanyCommands;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.CompanyHandler
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Guid>
    {

        private readonly IRepository<Company> _repository;

        public CreateCompanyCommandHandler(IRepository<Company> repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var com = new Company
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Surname = request.Surname,
                Email = request.Email,
                CompanyName = request.CompanyName,
                AccountsId = request.AccountsId,
                Image = null
            };
            await _repository.CreateAsync(com);
            return com.Id;
        }
    }
}
