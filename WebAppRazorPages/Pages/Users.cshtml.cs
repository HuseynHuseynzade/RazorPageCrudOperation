using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Model;

namespace WebAppRazorPages.Pages
{
    public class UsersModel : PageModel
    {
        private readonly RegisterDbContext _registerDbContext;
        public UsersModel(RegisterDbContext registerDbContext)
        {
            _registerDbContext = registerDbContext;
            Users = _registerDbContext.Users.ToList();
        }

        public IEnumerable<User> Users { get; private set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
           User currentUser = await _registerDbContext.Users.FindAsync(id);
            if (currentUser == null)
            {
                ModelState.AddModelError("", "User is not exists");
                
            }
            else
            {
                _registerDbContext.Users.Remove(currentUser);
                await _registerDbContext.SaveChangesAsync();
                Users = _registerDbContext.Users.ToList();
                return RedirectToPage("/Users");

            }
            return Page();
        }
    }
}