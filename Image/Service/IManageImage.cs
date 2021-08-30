using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Image.Service
{
   public interface IManageImage
    {
        public Task<bool> SaveImage(IFormFile img);
        public Task <string> ReturnImage(string path);
    }
}
