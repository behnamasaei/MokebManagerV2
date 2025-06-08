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
    public interface IBedAppService : ICrudAppService<
        BedDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateBedDto,
        CreateUpdateBedDto>
    {
    }
}
