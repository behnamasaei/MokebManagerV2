﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MokebManagerV2.Dtos;
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
    }
}
