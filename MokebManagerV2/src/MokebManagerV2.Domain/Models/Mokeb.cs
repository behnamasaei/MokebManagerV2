using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace MokebManagerV2.Models
{
    public class Mokeb : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {

        [Required(ErrorMessage = "نام موکب الزامی است.")]
        [MaxLength(300)]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "ظرفیت باید عددی مثبت باشد.")]
        public int Capacity { get; set; }

        [MaxLength(300)]
        public string Location { get; set; }

        public Sex Sex { get; set; }

        public virtual ICollection<Pilgrim> Pilgrims { get; set; }

        [Range(0, 100)]
        [Required]
        public int DurationStay { get; set; }

        public Guid? TenantId { get; set; }
    }
}