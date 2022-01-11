using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Opinion_Forum_Site.Models;

namespace Opinion_Forum_Site.Data
{
    public class Opinion_Forum_SiteContext : DbContext
    {
        public Opinion_Forum_SiteContext (DbContextOptions<Opinion_Forum_SiteContext> options)
            : base(options)
        {
        }

        public DbSet<Opinion_Forum_Site.Models.Opinion> Opinion { get; set; }
    }
}
