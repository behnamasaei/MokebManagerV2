using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MokebManagerV2.Dtos;
using MokebManagerV2.Interfaces;
using MokebManagerV2.Models;
using MokebManagerV2.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Pagination;

namespace MokebManagerV2.Web.Pages.Mokeb
{
    public class IndexModel : PageModel
    {
        private readonly IMokebAppService _mokebAppService;

        public IndexModel(IMokebAppService mokebAppService)
        {
            _mokebAppService = mokebAppService;
        }

        [BindProperty(SupportsGet = true, Name = "currentPage")]
        public int CurrentPage { get; set; } = 1;

        [BindProperty]
        public CreateUpdateMokebDto Input { get; set; }

        public PagerModel PagerModel { get; set; }
        public PagedResultDto<MokebDto> Mokebs { get; set; } = new();
        public int PageSize { get; set; } = 10;
        public int TotalPages { get; set; } = 0;



        public async Task OnGetAsync()
        {
            int skipCount = (CurrentPage - 1) * PageSize;
            Mokebs = await _mokebAppService.GetListAsync(new PagedAndSortedResultRequestDto
            {
                SkipCount = skipCount < 0 ? 0 : skipCount,
                MaxResultCount = PageSize,
                Sorting = "CreationTime desc"
            });
            PagerModel = new PagerModel(Mokebs.TotalCount, 10, CurrentPage, PageSize,"/mokeb");
            TotalPages = (int)Math.Ceiling(Mokebs.TotalCount / (double)PageSize);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove(nameof(Page));
            if (ModelState.IsValid)
            {
                var mokebDto = await _mokebAppService.CreateAsync(Input);
                if (mokebDto != null)
                {
                    return RedirectToPage("/Mokeb/Index");
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnGetDeleteRecord(Guid id)
        {
            await _mokebAppService.DeleteAsync(id);
            return RedirectToPage("/Mokeb/Index");
        }
    }
}
