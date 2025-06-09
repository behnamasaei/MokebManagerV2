using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MokebManagerV2.Dtos;
using MokebManagerV2.Interfaces;
using MokebManagerV2.Models;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using static MokebManagerV2.Permissions.MokebManagerV2Permissions;

namespace MokebManagerV2.Services
{
    [Authorize(MokebsPermissions.Default)]
    public class MokebAppService :
        CrudAppService<Mokeb, MokebDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateMokebDto, CreateUpdateMokebDto>,
        IMokebAppService
    {
        private readonly IBedAppService _bedAppService;

        public MokebAppService(IRepository<Mokeb, Guid> repository, IBedAppService bedAppService) : base(repository)
        {
            GetPolicyName = MokebsPermissions.Default;
            GetListPolicyName = MokebsPermissions.Default;
            CreatePolicyName = MokebsPermissions.Create;
            UpdatePolicyName = MokebsPermissions.Edit;
            DeletePolicyName = MokebsPermissions.Delete;
            _bedAppService = bedAppService;
        }

        public override async Task<MokebDto> CreateAsync(CreateUpdateMokebDto input)
        {
            input.FreeCapacity = input.Capacity;
            return await base.CreateAsync(input);
        }

        public override async Task<MokebDto> UpdateAsync(Guid id, CreateUpdateMokebDto input)
        {
            var oldMokeb = await base.GetAsync(id);

            if (input.Capacity > oldMokeb.Capacity)
            {
                input.FreeCapacity += (input.Capacity - oldMokeb.Capacity);
            }
            else if (input.Capacity < oldMokeb.Capacity && input.FreeCapacity - (oldMokeb.Capacity - input.Capacity) > 0)
            {
                input.FreeCapacity -= (oldMokeb.Capacity - input.Capacity);
            }
            else
            {
                // not have freeCapacity to minuse
            }

            return await base.UpdateAsync(id, input);
        }
    }
}
