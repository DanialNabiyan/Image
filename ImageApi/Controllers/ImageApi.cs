using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageApi.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class ImageApi : ControllerBase
    {
        private readonly IWebHostEnvironment host;
        public ImageApi(IWebHostEnvironment host)
        {
            this.host = host;
        }
        [HttpPost]
        public async Task<IActionResult> AddImage(IFormFile file)
        {
           //var img = JsonConvert.DeserializeObject<IFormFile>(ImageSerialize); 
            if (file.Length > 0)
            {
                string path = $"{host.WebRootPath}\\img";

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string guid = Guid.NewGuid().ToString();

                using (FileStream fileStream = System.IO.File.Create(path + $"\\{guid}.{Path.GetExtension(file.FileName)}"))
                {
                    await file.CopyToAsync(fileStream);                    
                    await fileStream.FlushAsync();
                }
                return Ok();
            }
            return BadRequest();
        }
    }
}
