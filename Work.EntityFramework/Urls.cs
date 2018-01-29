using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work.EntityFramework
{
    public class Urls
    {
        
        public string Url { get; set; }
        [Key]
        public UrlEnum Name { get; set; }
    }


    public enum UrlEnum
    {
        BaseAddress = 1 ,

        BaiJiaLe = 2,

        SeearchResult = 3 
    }

}
