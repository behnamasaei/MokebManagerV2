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

        [Required(ErrorMessage = "بارکد اجباری می باشد.")]
        [Display(Name ="Barcode")]
        public string Barcode { get; set; }


        [MaxLength(50, ErrorMessage = "حداکثر 50 کاراکتر باشد.")]
        [Display(Name = "FullName")]
        public string? FullName { get; set; } = string.Empty;

        [MaxLength(15)]
        [Phone(ErrorMessage = "موبایل به درستی وارد شود.")]
        [Display(Name = "PhoneNumber")]
        public string? PhoneNumber { get; set; } = string.Empty;

        [MaxLength(20)]
        [Display(Name = "NationalCode")]
        public string? NationalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "شماره پاسپورت اجباری می باشد.")]
        [MaxLength(30)]
        [Display(Name = "PassportNo")]
        public string PassportNo { get; set; }

        [Display(Name = "Sex")]
        public Sex Sex { get; set; }

        [Required(ErrorMessage = "موکب انتخاب شود.")]
        [Display(Name = "Mokeb")]
        public Guid MokebId { get; set; }

        [Display(Name = "Image")]
        public string? Image { get; set; } = string.Empty;

        [Display(Name = "EntryDate")]
        public DateTime EntryDate { get; set; }

        [Display(Name = "ForceExitDate")]
        public DateTime ForceExitDate { get; set; }

        [Display(Name = "ExitDate")]
        public DateTime? ExitDate { get; set; }

        [Display(Name = "Traffic")]
        public List<DateTime>? Traffic { get; set; } = new();

        [Display(Name = "BedNumber")]
        public Guid? BedId { get; set; }

        [Display(Name = "BedNumber")]
        public int BedNumber { get; set; }

        public Guid? TenantId { get; set; }
    }
}
