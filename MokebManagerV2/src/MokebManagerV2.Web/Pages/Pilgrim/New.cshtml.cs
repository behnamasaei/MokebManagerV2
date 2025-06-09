using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MokebManagerV2.Dtos;
using MokebManagerV2.Interfaces;
using Volo.Abp.Application.Dtos;
using Volo.Abp.ObjectMapping;

namespace MokebManagerV2.Web.Pages.Pilgrim
{
    public class NewModel : PageModel
    {
        private readonly IMokebAppService _mokebAppService;
        private readonly IObjectMapper _objectMapper;
        private readonly IPilgrimAppService _pilgrimAppService;

        public NewModel(IMokebAppService mokebAppService, IObjectMapper objectMapper, IPilgrimAppService pilgrimAppService)
        {
            _mokebAppService = mokebAppService;
            _objectMapper = objectMapper;
            _pilgrimAppService = pilgrimAppService;
        }

        [BindProperty]
        public CreateUpdatePilgrimDto Input { get; set; } = new();
        public IReadOnlyList<MokebDto> Mokebs { get; set; }
        public MokebDto MokebSelected { get; set; } = new();

        public async Task OnGetAsync()
        {
            var PagedMokebs = await _mokebAppService.GetListAsync(new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 });
            Mokebs = PagedMokebs.Items;
            Input.EntryDate = DateTime.Now;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Input.EntryDate = DateTime.Now;
                await _pilgrimAppService.CreateAsync(Input);
                return RedirectToPage("/pilgrim/new");
            }
            return Page();
        }

        public async Task<JsonResult> OnGetMokebDataAsync(Guid id)
        {
            MokebSelected = await _mokebAppService.GetAsync(id);
            Input.ForceExitDate = DateTime.Today.AddDays(MokebSelected.DurationStay).AddHours(10);
            return new JsonResult(new
            {
                forceExitDate = Input.ForceExitDate.ToString("yyyy/MM/dd HH:mm:ss"),
                freeCapacity = MokebSelected.FreeCapacity
            });
        }

    }
}
