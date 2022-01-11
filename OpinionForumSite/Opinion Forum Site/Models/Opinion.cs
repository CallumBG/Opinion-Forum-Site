using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opinion_Forum_Site.Models
{
    public class Opinion
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public string OpinionText { get; set; }

    }
}
