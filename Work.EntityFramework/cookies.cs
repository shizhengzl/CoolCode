using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work.EntityFramework
{
    public partial class cookies
    {
        public long creation_utc { get; set; }
        public string host_key { get; set; }

        [Key]
        public string name { get; set; }
        public string value { get; set; }
        public string path { get; set; }
        public long expires_utc { get; set; }
        public long secure { get; set; }
        public long httponly { get; set; }
        public long last_access_utc { get; set; }
        public long has_expires { get; set; }
        public long persistent { get; set; }
    }
}
