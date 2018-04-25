using DotNetCore2.Data;
using DotNetCore2.Interfaces;
using DotNetCore2.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2.Services
{
    public class DrawingService : IDrawingService
    {
        private EFCore2Context _dbContext;
        public DrawingService(EFCore2Context dbContext)
        {
            _dbContext = dbContext;
        }

        public Drawing GetLatestDrawing()
        {
            return _dbContext.Drawings.OrderByDescending(p => p.DrawingID).FirstOrDefault();
        }

        public void SaveDrawing(Drawing drawing)
        {
            //if (_dbContext.Drawings.Any())
            //{
            //    foreach(var item in _dbContext.Drawings)
            //    {
            //        _dbContext.Colors.Remove()
            //        _dbContext.Drawings.Remove(item);
            //    }
            //}
            drawing.CreationDate = DateTime.Now;
            _dbContext.Drawings.Add(drawing);

            _dbContext.SaveChanges();
        }
    }
}
