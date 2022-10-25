using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbb_ges.EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string mail { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public bool status { get; set; }
        public DateTime sendDate { get; set; }
        
    }
}
