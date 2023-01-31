using Microsoft.AspNetCore.Mvc;
using System;

namespace Biblioteka_project_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IWebHostEnvironment environment;
        public ToDoController(IWebHostEnvironment hostEnvironment)
        {
            environment = hostEnvironment;
        }
        [HttpGet("downloadfile")]
        public IActionResult DownloadFile()
        {
            var filepath = Path.Combine(environment.WebRootPath, "files", "toc0.txt");
            return File(System.IO.File.ReadAllBytes(filepath), "file/txt", System.IO.Path.GetFileName(filepath));
        }
        [HttpGet("downloadimage")]
        public IActionResult DownloadImage()
        {
            var filepath = Path.Combine(environment.WebRootPath, "images/covers", "cover0.png");
            return File(System.IO.File.ReadAllBytes(filepath), "image/png", System.IO.Path.GetFileName(filepath));
        }
    }
}
