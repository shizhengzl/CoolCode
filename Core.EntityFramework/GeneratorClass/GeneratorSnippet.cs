using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EntityFramework.GeneratorClass
{
    public class GeneratorSnippet
    {
        public string Name { get; set; }

        public bool IsFloder { get; set; }

        public string GeneratorFileName { get; set; }

        public string GeneratorPath { get; set; }

        public bool IsMergin { get; set; }

        public bool IsEnabled { get; set; }

        public bool AutoFind { get; set; }

        public bool IsAppend { get; set; }

        public string AppendLocation { get; set; }

        public bool IsSelectColumn { get; set; }

        public string Context { get; set; }

        public string ProjectName { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long FatherId { get; set; }
    }
}
