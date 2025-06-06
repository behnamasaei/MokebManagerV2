using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MokebManagerV2.Models;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;

namespace MokebManagerV2.Dtos
{
    [Serializable]
    public class CreateUpdatePilgrimDto : ExtensibleObject, IMultiTenant
    {
        [MaxLength(100, ErrorMessage = "حداکثر 100 کاراکتر باشد.")]
        public string FullName { get; set; }

        [MaxLength(15)]
        [Phone(ErrorMessage = "موبایل به درستی وارد شود.")]
        public string PhoneNumber { get; set; }

        [MaxLength(20)]
        public string NationalCode { get; set; }

        [Required(ErrorMessage = "شماره پاسپورت اجباری می باشد.")]
        [MaxLength(30)]
        public string PassportNo { get; set; }

        public Sex Sex { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "شماره تخت باید عددی مثبت باشد.")]
        public int BedNumber { get; set; }

        [Required(ErrorMessage = "موکب انتخاب شود.")]
        public Guid MokebId { get; set; }

        public string Image { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime ForceExitDate { get; set; }

        public DateTime ExitDate { get; set; }

        public Guid? TenantId { get; set; }
    }
}
