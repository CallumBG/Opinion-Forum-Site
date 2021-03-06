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
    public class ViewUserPostsModel : PageModel
    {
        private readonly Opinion_Forum_Site.Data.Opinion_Forum_SiteContext _context;

        public ViewUserPostsModel(Opinion_Forum_Site.Data.Opinion_Forum_SiteContext context)
        {
            _context = context;
        }

        public IList<Opinion> Opinion { get;set; }

        public async Task OnGetAsync()
        {
            Opinion = await _context.Opinion.ToListAsync();
        }

        // POST: Opinion/ShowSearchResults

        public async Task<IActionResult> OnPostAsync(string SearchPhrase)
        {
            Opinion = await _context.Opinion.Where(j => j.Title.Contains(SearchPhrase)).ToListAsync();
            return Page();
        }
    }
}
