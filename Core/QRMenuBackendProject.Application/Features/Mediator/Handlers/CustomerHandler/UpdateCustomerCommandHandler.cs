using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.CoustomerCommands;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.CustomerHandler;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
{
    private readonly IRepository<Customer> _repository;

    public UpdateCustomerCommandHandler(IRepository<Customer> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.Id);
        values.Name = request.Name;
        values.Surname = request.Surname;
        values.Image = request.Image;
        values.PhoneNumber = request.PhoneNumber;
        await _repository.UpdateAsync(values);
    }
}