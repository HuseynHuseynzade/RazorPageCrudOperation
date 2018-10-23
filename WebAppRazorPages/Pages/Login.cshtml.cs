using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Model;

namespace WebAppRazorPages.Pages
{
    public class InfoModel : PageModel
    {
        [BindProperty]
        public Login Login { get; set; }
        public IActionResult OnPost()
        {

            if (Login.Name == "admin")
            {
                ModelState.AddModelError("", "sahsjahs");
            }
            if (ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                return Page();
            }
        }
    }
}