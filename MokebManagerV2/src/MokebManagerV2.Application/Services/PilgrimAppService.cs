﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MokebManagerV2.Dtos;
using MokebManagerV2.Interfaces;
using MokebManagerV2.Models;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using static MokebManagerV2.Permissions.MokebManagerV2Permissions;

namespace MokebManagerV2.Services
{
    public class PilgrimAppService : CrudAppService
        <Pilgrim, PilgrimDto, Guid, PagedAndSortedResultRequestDto, CreateUpdatePilgrimDto, CreateUpdatePilgrimDto>, IPilgrimAppService
    {
        public PilgrimAppService(IRepository<Pilgrim, Guid> repository) : base(repository)
        {
            GetPolicyName = PilgrimsPermissions.Default;
            GetListPolicyName = PilgrimsPermissions.Default;
            CreatePolicyName = PilgrimsPermissions.Create;
            UpdatePolicyName = PilgrimsPermissions.Edit;
            DeletePolicyName = PilgrimsPermissions.Delete;
        }
    }
}
