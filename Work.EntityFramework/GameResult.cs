using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work.EntityFramework
{ 
     public partial class GameResult
    {
        public Nullable<System.DateTime> InvestTime { get; set; }

        [Key]
        public string OrderNumber { get; set; }
        public string JuHao { get; set; }
        public string ChangCi { get; set; }
        public string GameType { get; set; }
        public string Result { get; set; }
        public Nullable<decimal> InvestMoney { get; set; }
        public Nullable<decimal> ValidMoney { get; set; }
        public decimal WinMoney { get; set; }
        public string Remark { get; set; }
    }
}
