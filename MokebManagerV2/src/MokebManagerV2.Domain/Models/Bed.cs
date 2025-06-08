using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.MultiTenancy;

namespace MokebManagerV2.Models
{
    public class Bed : IMultiTenant
    {
        public Guid Id { get; set; }
        public bool IsUsed { get; set; }

        [Required]
        public Guid PilgrimId { get; set; }
        public virtual Pilgrim Pilgrim { get; set; }
        public Guid? TenantId { get; set; }
    }
}
