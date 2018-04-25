using DotNetCore2.Data;
using DotNetCore2.Interfaces;
using DotNetCore2.Models;
using DotNetCore2.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2.Services
{
    public class ColorService : IColorService
    {
        private EFCore2Context _dbContext;
        public ColorService(EFCore2Context dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ColorViewModel> GetColorsByDrawingID(int drawingID)
        {
            return _dbContext.Drawings.Include(p => p.colors).Where(p => p.DrawingID == drawingID).SelectMany(p=> p.colors).ToList().Select(p => new ColorViewModel { ColorID = p.ColorID, color = p.color, category = p.category, type = p.type}).ToList();
        }
    }
}
