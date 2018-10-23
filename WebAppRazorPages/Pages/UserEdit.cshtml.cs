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
    
    public class UserEditModel : PageModel
    {
        
        private readonly RegisterDbContext _registerDbContext;
        public UserEditModel(RegisterDbContext registerDbContext)
        {
            _registerDbContext = registerDbContext;
        }
        [BindProperty]
        public User CurrentUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
          User findedUser = await  _registerDbContext.Users.FindAsync(id);
            if (findedUser == null)
            {
                ModelState.AddModelError("", "This user is not exists");
                return RedirectToPage("/Users");
            }
            else
            {
                CurrentUser = findedUser;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                User user = await _registerDbContext.Users.Where(x => x.Id == CurrentUser.Id).FirstOrDefaultAsync();

                if (user == null)
                {
                    ModelState.AddModelError("", "This user not exists");
                   
                }
                else
                {
                    user.Email = CurrentUser.Email;
                    user.Name = CurrentUser.Name;
                    user.Password = CurrentUser.Password;
                    await _registerDbContext.SaveChangesAsync();
                   
                }

            }
            return RedirectToPage("/Users");
        }
    }
}