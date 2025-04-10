using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Queries.AccountQueries;
using QRMenuBackendProject.Application.Features.Mediator.Results.AccountResults;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.AccountHandler
{
    public class GetCheckAccountQueryHandler : IRequestHandler<GetCheckAccountQuery, GetCheckAccountQueryResults>
    {
        private readonly IRepository<Accounts> _accountRepository;
        private readonly IRepository<Company> _companyRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<RestaurantEmployee> _restaurantEmployeeRepository;

        public GetCheckAccountQueryHandler(IRepository<Accounts> accountRepository, IRepository<Company> companyRepository, IRepository<Customer> customerRepository, IRepository<RestaurantEmployee> restaurantEmployeeRepository)
        {
            _accountRepository = accountRepository;
            _companyRepository = companyRepository;
            _customerRepository = customerRepository;
            _restaurantEmployeeRepository = restaurantEmployeeRepository;
        }

        public async Task<GetCheckAccountQueryResults> Handle(GetCheckAccountQuery request, CancellationToken cancellationToken)
        {
            var values = new GetCheckAccountQueryResults();
            var acc = await _accountRepository.GetByFilterAsync(x => x.Email == request.Email && x.Password == request.Password);
            
            if (acc == null)
            {
                values.IsExist = false;
            }
            else
            {
                if(acc.Type == Domain.Enums.AccountsType.Company)
                {
                    var company = await _companyRepository.GetByFilterAsync(c => c.Email == acc.Email);
                    values.Id = company.Id;
                }
                else if(acc.Type == Domain.Enums.AccountsType.Employee)
                {
                    var restorantEmployee = await _restaurantEmployeeRepository.GetByFilterAsync(e => e.Email == acc.Email);
                    values.Id = restorantEmployee.Id;
                }
                else if (acc.Type == Domain.Enums.AccountsType.Customer)
                {
                    var customer = await _customerRepository.GetByFilterAsync(e => e.Email == acc.Email);
                    values.Id = customer.Id;
                }

                values.IsExist = true;
                values.Email = acc.Email;
                values.Type = acc.Type;
                values.UserID = acc.Id;
                
            }
            return values;
        }
    }
}
