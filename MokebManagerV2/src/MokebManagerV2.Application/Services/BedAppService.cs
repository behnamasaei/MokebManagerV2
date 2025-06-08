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

namespace MokebManagerV2.Services
{
    public class BedAppService : CrudAppService<
        Bed, BedDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBedDto, CreateUpdateBedDto>, IBedAppService
    {
        public BedAppService(IRepository<Bed, Guid> repository) : base(repository)
        {
        }
    }
}
