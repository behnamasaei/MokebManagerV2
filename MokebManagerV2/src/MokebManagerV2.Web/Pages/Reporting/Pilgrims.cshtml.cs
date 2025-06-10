using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MokebManagerV2.Dtos;
using MokebManagerV2.Interfaces;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Pagination;

namespace MokebManagerV2.Web.Pages.Reporting
{
    public class PilgrimsModel : PageModel
    {
        private readonly IPilgrimAppService _pilgrimAppService;

        public PilgrimsModel(IPilgrimAppService pilgrimAppService)
        {
            _pilgrimAppService = pilgrimAppService;
        }

        [BindProperty(SupportsGet = true, Name = "currentPage")]
        public int CurrentPage { get; set; } = 1;
        public PagerModel PagerModel { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalPages { get; set; } = 0;

        public PagedResultDto<PilgrimDto> Pilgrims { get; set; }

        public async Task OnGetAsync()
        {
            Pilgrims = await _pilgrimAppService.GetListWithDetailAsync(new PagedAndSortedResultRequestDto
            {
                SkipCount = (CurrentPage - 1) * PageSize,
                MaxResultCount = PageSize
            });

            PagerModel = new PagerModel(Pilgrims.TotalCount, PageSize, CurrentPage, PageSize, "~/reporting/pilgrims");
        }
    }
}
