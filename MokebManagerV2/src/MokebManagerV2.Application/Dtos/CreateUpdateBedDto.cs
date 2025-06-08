using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.MultiTenancy;

namespace MokebManagerV2.Dtos
{
    public class CreateUpdateBedDto : IMultiTenant
    {
        public Guid Id { get; set; }
        public bool IsUsed { get; set; }
        public Guid PilgrimId { get; set; }
        public Guid? TenantId { get; set; }
    }
}
