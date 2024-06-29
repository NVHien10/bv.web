using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Utilities
{
    public class ImageOperrations
    {
        IWebHostEnvironment _env;
        public ImageOperrations(IWebHostEnvironment env)
        {
            _env = env;
        }
        public string ImageUpload(IFormFile file)
        {
            string filename = null;
            if(file != null)
            {
                string fileDirectory = Path.Combine(_env.WebRootPath, "Images");
                filename = Guid.NewGuid() + "-" + file.FileName;
                string filepath  = Path.Combine(fileDirectory, filename);
                using (FileStream fs = new FileStream(filepath, FileMode.Create))
                {
                    file.CopyToAsync(fs);
                }
                
            }
            return filename;
        }
    }
}
