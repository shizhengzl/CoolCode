using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work.EntityFramework
{
    public partial class meta
    {
        [Key]
        public string key { get; set; }
        public string value { get; set; }
    }
}
