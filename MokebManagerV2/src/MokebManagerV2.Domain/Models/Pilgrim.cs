using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace MokebManagerV2.Models
{
    public class Pilgrim : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        [MaxLength(100)]
        public string FullName { get; set; }
        
        [MaxLength(15)]
        [Phone]
        public string PhoneNumber { get; set; }

        [MaxLength(20)]
        public string NationalCode { get; set; }

        [Required]
        [MaxLength(30)]
        public string PassportNo { get; set; }

        public Sex Sex { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "شماره تخت باید عددی مثبت باشد.")]
        public int BedNumber { get; set; }

        public Guid MokebId { get; set; }
        public Mokeb Mokeb { get; set; }

        public string Image { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ForceExitDate { get; set; }
        public DateTime ExitDate { get; set; }
        public List<DateTime> Traffic { get; set; }

        public Guid? TenantId { get; set; }
    }
}
