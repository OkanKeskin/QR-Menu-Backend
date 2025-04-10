using QRMenuBackendProject.Domain.Entities.Base;
using QRMenuBackendProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Domain.Entities
{
	public class Invoice : AuditableEntity
	{
		public Orders Orders { get; set; }
		public Guid OrdersId { get; set; }
        public DateTime ProccesDate { get; set; }
        public double Total { get; set; }
    }
}
