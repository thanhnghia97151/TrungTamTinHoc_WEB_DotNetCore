using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.ViewModels
{
    public class ChangeModel
    {
        public string MemberId { get; set; }
        public string  OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
