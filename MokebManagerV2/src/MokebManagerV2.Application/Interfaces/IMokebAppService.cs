using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MokebManagerV2.Dtos;
using MokebManagerV2.Models;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MokebManagerV2.Interfaces
{
    public interface IMokebAppService : ICrudAppService<
        MokebDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateMokebDto,
        CreateUpdateMokebDto>
    {

        public Task<IQueryable<Mokeb>> WithDetailsAsync(params Expression<Func<Mokeb,object>>[] propertySelectors);
    }
}
