using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbb_ges.EntityLayer.Concrete
{
    public class MainPage
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string image { get; set; }
        public int CategoryID { get; set; }
    }
}
