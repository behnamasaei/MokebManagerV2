using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MokebManagerV2.Interfaces;

namespace MokebManagerV2.Web.Pages.Pilgrim
{
    public class TrafficTrackingModel : PageModel
    {

        private readonly IPilgrimAppService _pilgrimAppService;

        public TrafficTrackingModel(IPilgrimAppService pilgrimAppService)
        {
            _pilgrimAppService = pilgrimAppService;
        }

        public void OnGet()
        {
        }

        public async Task<JsonResult> OnGetCheckTrackingAsync(string passBarcode)
        {
            return new JsonResult( new
            {
                response = await _pilgrimAppService.CheckTrackingAsync(passBarcode) 
            });
        }
    }
}
