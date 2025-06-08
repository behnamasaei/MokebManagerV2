using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MokebManagerV2.Models;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace MokebManagerV2.Dtos
{
    public class BedDto : EntityDto<Guid>, IMultiTenant
    {
        public bool IsUsed { get; set; }
        public Guid PilgrimId { get; set; }
        public virtual PilgrimDto Pilgrim { get; set; }
        public Guid MokebId { get; set; }
        public virtual MokebDto Mokeb { get; set; }
        public Guid? TenantId { get; set; }
    }
}
