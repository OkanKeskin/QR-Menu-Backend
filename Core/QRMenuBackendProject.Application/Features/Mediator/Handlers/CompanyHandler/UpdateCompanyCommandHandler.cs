using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.CompanyCommands;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.CompanyHandler;

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
{
    private readonly IRepository<Company> _repository;

    public UpdateCompanyCommandHandler(IRepository<Company> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.Id);
        values.Name = request.OwnerName;
        values.Image = request.Image;
        values.Surname = request.OwnerSurname;
        values.PhoneNumber = request.PhoneNumber;
        values.CompanyName = request.CompanyName;
        await _repository.UpdateAsync(values);
    }
}