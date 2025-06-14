﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using MokebManagerV2.Models;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace MokebManagerV2.Dtos
{
    [Serializable]
    public class MokebDto : ExtensibleFullAuditedEntityDto<Guid>, IMultiTenant
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int FreeCapacity { get; set; }
        public string Location { get; set; }
        public Sex Sex { get; set; }
        public virtual ICollection<PilgrimDto> Pilgrims{ get; set; }
        public virtual ICollection<BedDto> Beds { get; set; }

        public int DurationStay { get; set; }
        public Guid? TenantId { get; set; }
    }
}
