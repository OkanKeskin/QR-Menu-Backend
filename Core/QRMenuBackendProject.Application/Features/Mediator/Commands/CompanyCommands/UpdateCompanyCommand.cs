using MediatR;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.CompanyCommands;

public class UpdateCompanyCommand : IRequest
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string OwnerName { get; set; }
    public string OwnerSurname { get; set; }
    public string PhoneNumber { get; set; }
    public string Image { get; set; }
}