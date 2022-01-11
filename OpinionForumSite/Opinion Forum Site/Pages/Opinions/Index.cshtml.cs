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
    public class IndexModel : PageModel
    {
        private readonly Opinion_Forum_Site.Data.Opinion_Forum_SiteContext _context;

        public IndexModel(Opinion_Forum_Site.Data.Opinion_Forum_SiteContext context)
        {
            _context = context;
        }

        public IList<Opinion> Opinion { get;set; }

        public async Task OnGetAsync()
        {
            Opinion = await _context.Opinion.ToListAsync();
        }
    }
}
