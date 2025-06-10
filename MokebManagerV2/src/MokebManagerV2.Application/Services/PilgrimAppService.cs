using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MokebManagerV2.Dtos;
using MokebManagerV2.Features;
using MokebManagerV2.Interfaces;
using MokebManagerV2.Models;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Emailing;
using Volo.Abp.Features;
using Volo.Abp.ObjectMapping;
using static MokebManagerV2.Permissions.MokebManagerV2Permissions;

namespace MokebManagerV2.Services
{
    public class PilgrimAppService : CrudAppService
        <Pilgrim, PilgrimDto, Guid, PagedAndSortedResultRequestDto, CreateUpdatePilgrimDto, CreateUpdatePilgrimDto>, IPilgrimAppService
    {
        private readonly IBedAppService _bedAppService;
        private readonly IMokebAppService _mokebAppService;
        private readonly IFeatureChecker _featureChecker;
        private readonly IRepository<Pilgrim, Guid> _pilgrimAppService;

        public PilgrimAppService(IRepository<Pilgrim, Guid> repository, IBedAppService bedAppService, IMokebAppService mokebAppService, IRepository<Pilgrim, Guid> pilgrimAppService, IFeatureChecker featureChecker) : base(repository)
        {
            GetPolicyName = PilgrimsPermissions.Default;
            GetListPolicyName = PilgrimsPermissions.Default;
            CreatePolicyName = PilgrimsPermissions.Create;
            UpdatePolicyName = PilgrimsPermissions.Edit;
            DeletePolicyName = PilgrimsPermissions.Delete;
            _bedAppService = bedAppService;
            _mokebAppService = mokebAppService;
            _pilgrimAppService = pilgrimAppService;
            _featureChecker = featureChecker;
        }

        public override async Task<PilgrimDto> CreateAsync(CreateUpdatePilgrimDto input)
        {
            if (!await _featureChecker.IsEnabledAsync(MokebFeatures.BedStatusFeature))
            {
                return await base.CreateAsync(input);
            }

            PilgrimDto pilgrim = null;
            var mokebQueryable = await _mokebAppService.WithDetailsAsync(x => x.Beds);
            var mokebQuery = mokebQueryable.Where(x => x.Id == input.MokebId);
            var mokeb = ObjectMapper.Map<Mokeb, MokebDto>(await AsyncExecuter.FirstOrDefaultAsync(mokebQuery));
            var beds = mokeb.Beds;

            for (int i = 1; i <= mokeb.Capacity; i++)
            {
                var existingBed = beds.FirstOrDefault(b => b.BedNumber == i);
                if (existingBed == null)
                {
                    input.BedNumber = i;
                    pilgrim = await base.CreateAsync(input);


                    var newBed = await _bedAppService.CreateAsync(new CreateUpdateBedDto
                    {
                        BedNumber = i,
                        PilgrimId = pilgrim.Id,
                        MokebId = input.MokebId,
                        TenantId = pilgrim.TenantId
                    });

                    var updatePilgrimInput = ObjectMapper.Map<PilgrimDto, CreateUpdatePilgrimDto>(pilgrim);
                    updatePilgrimInput.BedId = newBed.Id;

                    await base.UpdateAsync(pilgrim.Id, updatePilgrimInput);

                    var mokebUpdateInput = ObjectMapper.Map<MokebDto, CreateUpdateMokebDto>(mokeb);
                    mokebUpdateInput.FreeCapacity--;
                    await _mokebAppService.UpdateAsync(mokeb.Id, mokebUpdateInput);
                    return pilgrim;
                }
            }
            return pilgrim;
        }

        

        public async Task<PagedResultDto<PilgrimDto>> GetListWithDetailAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await _pilgrimAppService.WithDetailsAsync(x => x.Mokeb);

            var query = queryable.Skip(input.SkipCount).Take(input.MaxResultCount);

            var pilgrims = await AsyncExecuter.ToListAsync(query);
            var totalCount = await AsyncExecuter.CountAsync(queryable);
            var dtos = ObjectMapper.Map<List<Pilgrim>, List<PilgrimDto>>(pilgrims);

            return new PagedResultDto<PilgrimDto>(totalCount, dtos);
        }

        public async Task DischargeAsync(string passportOrBarcode)
        {
            if (string.IsNullOrWhiteSpace(passportOrBarcode))
                return;

            var normalizedInput = passportOrBarcode.ToUpperInvariant();
            var pilgrim = await Repository
                .FirstOrDefaultAsync(p =>
                    p.PassportNo.ToUpperInvariant() == normalizedInput ||
                    p.Barcode.ToUpper().ToString() == passportOrBarcode.ToUpper());

            if (pilgrim == null)
                return;

            await ReleaseMokebCapacityAsync(pilgrim.MokebId);
            await UpdatePilgrimExitAsync(pilgrim);
            await FreeBedAsync(pilgrim.BedId);
        }

        private async Task ReleaseMokebCapacityAsync(Guid mokebId)
        {
            // if the feature is on, we don’t need to manually bump capacity
            if (await _featureChecker.IsEnabledAsync(MokebFeatures.BedStatusFeature))
                return;

            var mokeb = await _mokebAppService.GetAsync(mokebId);
            var dto = ObjectMapper.Map<MokebDto, CreateUpdateMokebDto>(mokeb);
            dto.FreeCapacity++;
            await _mokebAppService.UpdateAsync(mokeb.Id, dto);
        }

        private async Task UpdatePilgrimExitAsync(Pilgrim pilgrim)
        {
            var dto = ObjectMapper.Map<Pilgrim, CreateUpdatePilgrimDto>(pilgrim);
            dto.ExitDate = DateTime.Now;
            await UpdateAsync(pilgrim.Id, dto);
        }

        private Task FreeBedAsync(Guid? bedId)
        {
            return bedId.HasValue
                ? _bedAppService.DeleteAsync(bedId.Value)
                : Task.CompletedTask;
        }

    }
}
