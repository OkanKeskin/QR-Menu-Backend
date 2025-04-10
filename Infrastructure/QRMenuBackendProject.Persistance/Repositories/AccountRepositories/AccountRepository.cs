using Microsoft.EntityFrameworkCore;
using QRMenuBackendProject.Application.Interfaces.AccountInterface;
using QRMenuBackendProject.Domain.Entities;
using QRMenuBackendProject.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Persistance.Repositories.AccountRepositories
{
    public class AccountRepository : Repository<Accounts>, IAccountRepository
    {
        public AccountRepository(QRMenuBackendProjectContext context) : base(context)
        {
            
        }

        public async Task<List<Accounts>> GetByFilterAsync(Expression<Func<Accounts, bool>> filter)
        {
            return await _context.Set<Accounts>().Where(filter).ToListAsync();
        }   
    }
}
