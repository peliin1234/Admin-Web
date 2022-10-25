using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbb_ges.EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        public string AboutTitle { get; set; }
        public string AboutDetails { get; set; }
        public string AboutImage { get; set; }
        public bool AboutStatus { get; set; }
        public int CategoryID { get; set; }
    }
}
