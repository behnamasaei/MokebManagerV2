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
using Volo.Abp.Domain.Repositories;
using static MokebManagerV2.Permissions.MokebManagerV2Permissions;

namespace MokebManagerV2.Services
{
    [Authorize(MokebsPermissions.Default)]
    public class MokebAppService :
        CrudAppService<Mokeb, MokebDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateMokebDto, CreateUpdateMokebDto>,
        IMokebAppService
    {
        private readonly IRepository<Mokeb, Guid> _mokebRepository;

        public MokebAppService(IRepository<Mokeb, Guid> repository) : base(repository)
        {
            GetPolicyName = MokebsPermissions.Default;
            GetListPolicyName = MokebsPermissions.Default;
            CreatePolicyName = MokebsPermissions.Create;
            UpdatePolicyName = MokebsPermissions.Edit;
            DeletePolicyName = MokebsPermissions.Delete;
        }

    }
}
