using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Opinion_Forum_Site.Data;
using Opinion_Forum_Site.Models;

namespace Opinion_Forum_Site.Pages.Opinions
{
    public class DeleteModel : PageModel
    {
        private readonly Opinion_Forum_Site.Data.Opinion_Forum_SiteContext _context;

        public DeleteModel(Opinion_Forum_Site.Data.Opinion_Forum_SiteContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Opinion = await _context.Opinion.FindAsync(id);

            if (Opinion != null)
            {
                _context.Opinion.Remove(Opinion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
