using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore2.Interfaces;
using DotNetCore2.Models.Domain;
using DotNetCore2.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNetCore2.Controllers
{
    public class S3FileDisplayController : Controller
    {
        private IS3Storage s3Storage;
        private IDrawingService drawingService;
        private IColorService colorService;
        public S3FileDisplayController(IS3Storage s3Storage, IDrawingService drawingService, IColorService colorService)
        {
            this.s3Storage = s3Storage;
            this.drawingService = drawingService;
            this.colorService = colorService;
        }

        public async Task<IActionResult> Index()
        {
            string s3Key = "UPLOAD/colors.json";
            var body = await s3Storage.DownloadTextFile(s3Key);

            var drawing = JsonConvert.DeserializeObject<Drawing>(body);
            drawingService.SaveDrawing(drawing);

            var colorList = colorService.GetColorsByDrawingID(drawing.DrawingID);


            return View(colorList);
        }
    }
}