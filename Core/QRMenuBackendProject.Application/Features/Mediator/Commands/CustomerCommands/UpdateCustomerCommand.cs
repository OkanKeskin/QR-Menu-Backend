using MediatR;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.CoustomerCommands;

public class UpdateCustomerCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public string Image { get; set; }
}