using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairShop.Application.Common
{
    public class BaseResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
