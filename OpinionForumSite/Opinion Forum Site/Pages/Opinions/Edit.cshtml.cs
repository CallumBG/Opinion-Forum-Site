using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Opinion_Forum_Site.Data;
using Opinion_Forum_Site.Models;
using Microsoft.AspNetCore.Authorization;

namespace Opinion_Forum_Site.Pages.Opinions
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly Opinion_Forum_Site.Data.Opinion_Forum_SiteContext _context;

        public EditModel(Opinion_Forum_Site.Data.Opinion_Forum_SiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Opinion Opinion { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Opinion = await _context.Opinion.FirstOrDefaultAsync(m => m.ID == id);

            if (Opinion == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Opinion.Username = User.Identity.Name;
            _context.Attach(Opinion).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpinionExists(Opinion.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OpinionExists(int id)
        {
            return _context.Opinion.Any(e => e.ID == id);
        }
    }
}
