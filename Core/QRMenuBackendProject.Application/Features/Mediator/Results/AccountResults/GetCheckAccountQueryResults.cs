using QRMenuBackendProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Results.AccountResults
{
    public class GetCheckAccountQueryResults
    {
        public Guid UserID { get; set; }
        public string Email { get; set; }
        public Guid Id { get; set; }
        public AccountsType Type { get; set; }
        public bool IsExist { get; set; }
    }
}
