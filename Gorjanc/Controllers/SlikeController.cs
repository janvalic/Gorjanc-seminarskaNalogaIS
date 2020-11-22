using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using Gorjanc.Models;
using Gorjanc.Data;

namespace Gorjanc.Controllers
{
    public class DemoController : Controller
    {
        private readonly GorjancContext _context;
        public DemoController(GorjancContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile files)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(files.FileName);

                    var objfiles = new Slika()
                    {
                        SlikaId = 0,
                        Ime= fileName,
                        DatumSlike = DateTime.Now
                    };
                    
                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        objfiles.Img = target.ToArray();
                    }

                    _context.Slike.Add(objfiles);
                    _context.SaveChanges();

                }
            }
            return View();
        }
    }
}