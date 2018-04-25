using DotNetCore2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2.Interfaces
{
    public interface IColorService
    {
        List<ColorViewModel> GetColorsByDrawingID(int drawingID);
    }
}
