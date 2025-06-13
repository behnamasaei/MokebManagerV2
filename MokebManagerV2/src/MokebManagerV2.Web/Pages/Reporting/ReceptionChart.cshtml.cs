using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.OpenApi.Writers;
using MokebManagerV2.Dtos;
using MokebManagerV2.Extentions;
using MokebManagerV2.Interfaces;
using Volo.Abp.Application.Dtos;

namespace MokebManagerV2.Web.Pages.Reporting
{
    public class ReceptionChartModel : PageModel
    {
        private readonly IMokebAppService _mokebAppService;
        private readonly IPilgrimAppService _pilgrimAppService;

        public ReceptionChartModel(IMokebAppService mokebAppService, IPilgrimAppService pilgrimAppService)
        {
            _mokebAppService = mokebAppService;
            _pilgrimAppService = pilgrimAppService;
        }

        [BindProperty(SupportsGet = true)]
        public ReceptionDateRange Input { get; set; } = new();

        public IReadOnlyList<MokebDto> Mokebs { get; set; }

        public async Task OnGetAsync()
        {
            var PagedMokebs = await _mokebAppService.GetListAsync(new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 });
            Mokebs = PagedMokebs.Items;
        }

        public async Task<JsonResult> OnGetRangeDataAsync(DateTime startDate, DateTime endDate, Guid mokebId)
        {
            var pilgrims = await _pilgrimAppService.GetAllFromMokebAsync(mokebId);
            var receptions = new List<Reception>();

            for (DateTime date = startDate; date < endDate; date = date.AddDays(1))
            {
                receptions.Add(new Reception
                {
                    Date = date,
                    Count = pilgrims.Count(x =>
                                            x.EntryDate.Date <= date.Date
                                            && (
                                                (x.ExitDate == DateTime.MinValue || x.ExitDate == null)
                                                  ? x.ForceExitDate.Date > date.Date
                                                  : x.ExitDate.Date > date.Date
                                               ))
                });
            }

            var result = new
            {
                mokeb = Mokebs.FirstOrDefault(x => x.Id == mokebId)?.Name ?? "",
                labels = receptions.OrderBy(x => x.Date).Select(x => x.Date.ToShortDateString()).ToList(),
                data = receptions.OrderBy(x => x.Date).Select(x => x.Count).ToList()
            };

            return new JsonResult(result);
        }
    }

    public class ReceptionDateRange
    {
        [Required(ErrorMessage = "موکب انتخاب شود.")]
        [Display(Name = "Mokeb")]
        public Guid MokebId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);
    }

    public class Reception
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}
