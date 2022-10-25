using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbb_ges.EntityLayer.Concrete
{
    public class Contact
    {
        //deneme
        [Key]
        public int ContactID { get; set; }
        public string ContactTitle { get; set; }
        public string ContactDescription { get; set; }
        public string Map { get; set; }
        public int CategoryID { get; set; }

    }
}
