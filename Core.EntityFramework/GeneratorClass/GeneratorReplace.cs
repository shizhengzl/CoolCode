using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EntityFramework.GeneratorClass
{
    public class GeneratorReplace
    {
        [Key]
        public string ReplaceName { get; set; }

        public string ReplaceDeclare { get; set; }

        public string Operation { get; set; }

        public bool UserDeclare { get; set; }

        public ReplaceType ReplaceType { get; set; }
    }

    public enum ReplaceType
    {
        Snippet,
        Tag,
        Brackets
    }
}
