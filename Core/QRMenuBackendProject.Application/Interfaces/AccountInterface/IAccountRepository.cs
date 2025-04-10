using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Interfaces.AccountInterface
{
    public interface IAccountRepository : IRepository<Accounts>
    {
        Task<List<Accounts>> GetByFilterAsync(Expression<Func<Accounts, bool>> filter);
    }
}
