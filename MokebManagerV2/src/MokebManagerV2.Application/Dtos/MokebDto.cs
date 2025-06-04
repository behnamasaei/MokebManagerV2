using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MokebManagerV2.Models;
using Volo.Abp.Application.Dtos;

namespace MokebManagerV2.Dtos
{
    public class MokebDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
        public Sex Sex { get; set; }
        public ICollection<Pilgrim> Pilgrims{ get; set; }
    }
}
