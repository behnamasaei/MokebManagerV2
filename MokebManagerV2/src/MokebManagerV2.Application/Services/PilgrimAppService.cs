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
            PilgrimDto pilgrim = null;
            var mokeb = await _mokebAppService.GetAsync(input.MokebId);
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

        public async Task DischargeAsync(string passportOrBarcode)
        {
            var pilgrim = await base.Repository.FirstOrDefaultAsync(p => p.PassportNo.ToUpper() == passportOrBarcode.ToUpper() ||
                    p.Barcode.ToString() == passportOrBarcode);

            if (pilgrim != null)
            {
                var mokeb = await _mokebAppService.GetAsync(pilgrim.MokebId);
                var updateMokebInput = ObjectMapper.Map<MokebDto, CreateUpdateMokebDto>(mokeb);
                updateMokebInput.FreeCapacity++;
                await _mokebAppService.UpdateAsync(mokeb.Id, updateMokebInput);

                var updatePilgrimInput = ObjectMapper.Map<Pilgrim, CreateUpdatePilgrimDto>(pilgrim);
                updatePilgrimInput.ExitDate = DateTime.Now;
                await base.UpdateAsync(pilgrim.Id, updatePilgrimInput);
                if (pilgrim.BedId.HasValue)
                {
                    await _bedAppService.DeleteAsync(pilgrim.BedId.Value);
                }
            }
        }
    }
}
