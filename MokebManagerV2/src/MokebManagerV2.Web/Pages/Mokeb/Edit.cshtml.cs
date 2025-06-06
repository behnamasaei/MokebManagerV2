using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MokebManagerV2.Dtos;
using MokebManagerV2.Interfaces;
using Volo.Abp.ObjectMapping;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MokebManagerV2.Web.Pages.Mokeb
{
    public class EditModel : PageModel
    {
        private readonly IMokebAppService _mokebAppService;
        private readonly IObjectMapper _objectMapper;

        [BindProperty(SupportsGet = true , Name = "id")]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateMokebDto Input { get; set; } = new();

        public EditModel(IMokebAppService mokebAppService, IObjectMapper objectMapper)
        {
            _mokebAppService = mokebAppService;
            _objectMapper = objectMapper;
        }

        public async Task OnGetAsync()
        {
            if (Id != Guid.Empty)
            {
                var mokeb = await _mokebAppService.GetAsync(id: Id);
                Input = _objectMapper.Map<MokebDto, CreateUpdateMokebDto>(mokeb);
            }
            else
            {
                RedirectToPage("/Mokeb/Index");
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var mokebDto = await _mokebAppService.UpdateAsync(Id, Input);
                if (mokebDto != null)
                {
                    return RedirectToPage("/Mokeb/Index");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid data. Please check your input.");
            }

            return Page();
        }
    }
}
