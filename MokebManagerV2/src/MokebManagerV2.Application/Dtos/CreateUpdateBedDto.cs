using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace MokebManagerV2.Dtos
{
    public class CreateUpdateBedDto : EntityDto<Guid>, IMultiTenant
    {
        public bool IsUsed { get; set; }
        public Guid PilgrimId { get; set; }
        public Guid? TenantId { get; set; }
    }
}
