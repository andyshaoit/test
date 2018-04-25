using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2.Models.Domain
{
    public class Color
    {
        public int ColorID { get; set; }
        public string color { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public Code code { get; set; }
    }
}
