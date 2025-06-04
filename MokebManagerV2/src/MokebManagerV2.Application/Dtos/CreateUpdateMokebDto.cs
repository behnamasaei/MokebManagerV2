using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MokebManagerV2.Models;

namespace MokebManagerV2.Dtos
{
    public class CreateUpdateMokebDto
    {
        [Required,MaxLength(300, ErrorMessage = "نام موکب باید حداکثر 300 کاراکتر باشد.")]
        public string Name { get; set; }

        [Required, Range(0, int.MaxValue, ErrorMessage = "ظرفیت باید عددی مثبت باشد.")]
        public int Capacity { get; set; }

        [MaxLength(300)]
        public string Location { get; set; }

        [Required]
        public Sex Sex { get; set; }

        public Guid? TenantId { get; set; }
    }
}
