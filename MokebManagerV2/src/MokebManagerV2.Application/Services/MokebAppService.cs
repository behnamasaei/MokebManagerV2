using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MokebManagerV2.Dtos;
using MokebManagerV2.Features;
using MokebManagerV2.Interfaces;
using MokebManagerV2.Models;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Features;
using static MokebManagerV2.Permissions.MokebManagerV2Permissions;

namespace MokebManagerV2.Services
{
    [Authorize(MokebsPermissions.Default)]
    public class MokebAppService :
        CrudAppService<Mokeb, MokebDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateMokebDto, CreateUpdateMokebDto>,
        IMokebAppService
    {
        private readonly IFeatureChecker _featureChecker;
        private readonly IBedAppService _bedAppService;

        public MokebAppService(IRepository<Mokeb, Guid> repository, IBedAppService bedAppService, IFeatureChecker featureChecker) : base(repository)
        {
            GetPolicyName = MokebsPermissions.Default;
            GetListPolicyName = MokebsPermissions.Default;
            CreatePolicyName = MokebsPermissions.Create;
            UpdatePolicyName = MokebsPermissions.Edit;
            DeletePolicyName = MokebsPermissions.Delete;
            _bedAppService = bedAppService;
            _featureChecker = featureChecker;
        }

        public override async Task<MokebDto> CreateAsync(CreateUpdateMokebDto input)
        {
            input.FreeCapacity = input.Capacity;
            return await base.CreateAsync(input);
        }

        public override async Task<MokebDto> UpdateAsync(Guid id, CreateUpdateMokebDto input)
        {
            if(!await _featureChecker.IsEnabledAsync(MokebFeatures.BedStatusFeature))
            {
                return await base.UpdateAsync(id, input);
            }

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

        public Task<IQueryable<Mokeb>> WithDetailsAsync(params Expression<Func<Mokeb, object>>[] propertySelectors)
        {
            return base.Repository.WithDetailsAsync(propertySelectors);
        }
    }
}
