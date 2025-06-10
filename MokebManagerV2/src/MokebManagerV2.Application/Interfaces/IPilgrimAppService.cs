using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MokebManagerV2.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MokebManagerV2.Interfaces
{
    public interface IPilgrimAppService : ICrudAppService<
        PilgrimDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdatePilgrimDto,
        CreateUpdatePilgrimDto>
    {

        public Task DischargeAsync(string passportOrBarcode);
        public Task<PagedResultDto<PilgrimDto>> GetListWithDetailAsync(PagedAndSortedResultRequestDto input);
    }
}
