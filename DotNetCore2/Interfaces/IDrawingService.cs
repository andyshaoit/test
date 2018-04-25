using DotNetCore2.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2.Interfaces
{
    public interface IDrawingService
    {
        void SaveDrawing(Drawing drawing);
    }
}
