using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppRazorPages.Model;

namespace WebAppRazorPages.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly RegisterDbContext _registerDbContext;
        public RegisterModel(RegisterDbContext registerDbContext)
        {
            _registerDbContext = registerDbContext;
        }

        [BindProperty]
        public User RegisterUser { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                 User user = await _registerDbContext.Users.Where(x => x.Email == RegisterUser.Email).FirstOrDefaultAsync();

                    if (user != null)
                    {
                        ModelState.AddModelError("", "This email alredy exists");
                        return Page();
                    }
                    else
                    {
                        await _registerDbContext.Users.AddAsync(RegisterUser);
                        await _registerDbContext.SaveChangesAsync();
                        return RedirectToPage("/Users");
                    }
  
            }
            return Page();
        }
    }
}