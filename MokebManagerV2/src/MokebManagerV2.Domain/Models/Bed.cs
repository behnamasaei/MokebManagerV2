using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace MokebManagerV2.Models
{
    public class Bed : AuditedAggregateRoot<Guid> , IMultiTenant , ISoftDelete
    {
        public int BedNumber { get; set; }

        [Required]
        public Guid PilgrimId { get; set; }
        public virtual Pilgrim Pilgrim { get; set; }

        [Required]
        public Guid MokebId { get; set; }
        public virtual Mokeb Mokeb { get; set; }

        public Guid? TenantId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
