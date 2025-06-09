using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MokebManagerV2.Models;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace MokebManagerV2.Dtos
{
    public class BedDto : ExtensibleAuditedEntityDto<Guid>, IMultiTenant, ISoftDelete
    {
        public int BedNumber { get; set; }
        public Guid PilgrimId { get; set; }
        public virtual PilgrimDto Pilgrim { get; set; }
        public Guid MokebId { get; set; }
        public virtual MokebDto Mokeb { get; set; }
        public Guid? TenantId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
