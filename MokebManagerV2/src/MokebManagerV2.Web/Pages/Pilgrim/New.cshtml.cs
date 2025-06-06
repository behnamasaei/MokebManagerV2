using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MokebManagerV2.Dtos;

namespace MokebManagerV2.Web.Pages.Pilgrim
{
    public class NewModel : PageModel
    {

        [BindProperty]
        public CreateUpdatePilgrimDto Input { get; set; } = new();

        public void OnGet()
        {
            Input.EntryDate = DateTime.Now;
        }
    }
}
