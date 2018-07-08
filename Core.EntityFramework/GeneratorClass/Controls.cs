using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EntityFramework.GeneratorClass
{
    public class Controls
    {
        [Key]
        public string Name { get; set; }

        public string ControlString { get; set; }
    }
}
