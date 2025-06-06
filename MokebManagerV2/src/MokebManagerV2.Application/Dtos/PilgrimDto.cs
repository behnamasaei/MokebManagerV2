using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MokebManagerV2.Models;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace MokebManagerV2.Dtos
{
    public class PilgrimDto : ExtensibleFullAuditedEntityDto<Guid>, IMultiTenant
    {
        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string NationalCode { get; set; }

        public string PassportNo { get; set; }

        public Sex Sex { get; set; }

        public int BedNumber { get; set; }

        public Guid MokebId { get; set; }

        public virtual Mokeb Mokeb { get; set; }

        public string Image { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime ForceExitDate { get; set; }

        public DateTime ExitDate { get; set; }

        public virtual List<DateTime> Traffic { get; set; }

        public Guid? TenantId { get; set; }
    }
}
