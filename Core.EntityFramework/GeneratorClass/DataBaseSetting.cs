using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EntityFramework
{
    public class DataBaseSetting
    {
        [Key]
        public string Address { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public AuthenticationType AuthenticationType { get; set; }

        public bool IsRemeber { get; set; }

    } 

    public enum AuthenticationType
    {
        AccountPassword = 0 ,
        Windows = 1
    }

}
