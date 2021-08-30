using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Image.Service
{
    public class ManageImage : IManageImage
    {
        public async Task<string> ReturnImage(string path)
        {
            //using (var client = new HttpClient())
            //{
            //    var request = await client.PostAsJsonAsync<string>($"http://localhost:27907/api/FindImage", path);
            //    var response = await request.Content.ReadAsByteArrayAsync();
            //    string img = Convert.ToBase64String(response);
            //    return img;
            //}
            return "ok";
        }

        public async Task <bool> SaveImage(IFormFile img)
        {
            using (var client =  new HttpClient())
            {

               //var ImageSerialize = JsonConvert.SerializeObject(img);
                var request = await client.PostAsJsonAsync<IFormFile>($"http://localhost:27907/api/AddImage",img);
                if (request.IsSuccessStatusCode)
                    return true;
                else
                    return false;

            }
        }
    }
}
