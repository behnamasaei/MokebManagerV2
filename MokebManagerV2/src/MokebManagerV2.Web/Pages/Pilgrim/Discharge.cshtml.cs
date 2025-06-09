using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MokebManagerV2.Interfaces;

namespace MokebManagerV2.Web.Pages.Pilgrim
{
    public class DischargeModel : PageModel
    {
        [BindProperty]
        [Display(Name = "PassportOrBarcode")]
        public string PassportOrBarcode { get; set; }

        private readonly IPilgrimAppService _pilgrimAppService;

        public DischargeModel(IPilgrimAppService pilgrimAppService)
        {
            _pilgrimAppService = pilgrimAppService;
        }

        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _pilgrimAppService.DischargeAsync(PassportOrBarcode);
                RedirectToPage("/Pilgrim/Discharge");
            }
            else
            {
                // Handle validation errors
                TempData["ErrorMessage"] = "Please provide a valid passport or barcode.";
            }
        }
    }
}
