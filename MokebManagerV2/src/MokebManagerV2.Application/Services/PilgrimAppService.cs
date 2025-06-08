using System;
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
        private readonly IBedAppService _bedAppService;
        private readonly IMokebAppService _mokebAppService;

        public PilgrimAppService(IRepository<Pilgrim, Guid> repository, IBedAppService bedAppService, IMokebAppService mokebAppService) : base(repository)
        {
            GetPolicyName = PilgrimsPermissions.Default;
            GetListPolicyName = PilgrimsPermissions.Default;
            CreatePolicyName = PilgrimsPermissions.Create;
            UpdatePolicyName = PilgrimsPermissions.Edit;
            DeletePolicyName = PilgrimsPermissions.Delete;
            _bedAppService = bedAppService;
            _mokebAppService = mokebAppService;
        }

        public override async Task<PilgrimDto> CreateAsync(CreateUpdatePilgrimDto input)
        {
            var mokeb = await _mokebAppService.GetAsync(input.MokebId);
            var beds = await _bedAppService.GetListAsync(new PagedAndSortedResultRequestDto { SkipCount = 0 , MaxResultCount=int.MaxValue });
            var usedBeds = beds.Items.Where(b => b.MokebId == input.MokebId && b.IsUsed).Select(b => b.Id).ToList();
            return await base.CreateAsync(input);
        }
    }
}
