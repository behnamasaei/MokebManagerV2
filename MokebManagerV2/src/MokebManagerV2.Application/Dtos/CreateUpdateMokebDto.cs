using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MokebManagerV2.Localization;
using MokebManagerV2.Models;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;

namespace MokebManagerV2.Dtos
{
    [Serializable]
    public class CreateUpdateMokebDto : ExtensibleObject , IMultiTenant
    {
        [Required(ErrorMessage = "فیلد نام اجباری می باشد.")]
        [MaxLength(300, ErrorMessage = "نام موکب باید حداکثر 300 کاراکتر باشد.")]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ظرفیت اجباری می باشد."), Range(0, int.MaxValue, ErrorMessage = "ظرفیت باید عددی مثبت باشد.")]
        [Display(Name="Capacity")]
        public int Capacity { get; set; }

        [MaxLength(300)]
        [Display(Name="Location")]
        public string Location { get; set; } = string.Empty;

        [Display(Name = "Sex")]
        [Required(ErrorMessage = "جنسیت اجباری می باشد.")]
        public Sex Sex { get; set; }

        public Guid? TenantId { get; set; }
    }
}
