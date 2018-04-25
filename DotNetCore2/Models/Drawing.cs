using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2.Models.Domain
{
    public class Drawing
    {
        public int DrawingID { get; set; }
        public List<Color> colors { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
