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

        public string IsMergin { get; set; }

        public string IsEnabled { get; set; }

        public bool AutoFind { get; set; }

        public bool SnippetLanguageType { get; set; }

        public bool IsAppend { get; set; }

        public string AppendLocation { get; set; }

        public string SnippetPath { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; } 
        public long FatherId { get; set; }
    }
}
