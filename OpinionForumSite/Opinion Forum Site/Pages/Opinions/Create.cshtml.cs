using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Opinion_Forum_Site.Data;
using Opinion_Forum_Site.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Opinion_Forum_Site.Pages.Opinions
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly Opinion_Forum_Site.Data.Opinion_Forum_SiteContext _context;
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        public CreateModel(Opinion_Forum_Site.Data.Opinion_Forum_SiteContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager
            )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

       
        public IActionResult OnGet()
        {
              return Page();
        }

        [BindProperty]
        public Opinion Opinion { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Opinion.Username = User.Identity.Name;
            _context.Opinion.Add(Opinion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
