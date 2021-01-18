using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace HumanResource.Infrastructure.Services
{
    class FileUploadService
    {
        private readonly IWebHostEnvironment env;
        public FileUploadService(IWebHostEnvironment env)
        {
            this.env = env;
        }
        public string Upload(IFormFile file, string uploadDirectory, bool newFileName = true)
        {
            var uploadPath = Path.Combine(env.WebRootPath, uploadDirectory);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var fileName = newFileName ? Guid.NewGuid() + Path.GetExtension(file.FileName) : file.FileName;
            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = File.Create(filePath))
            {
                file.CopyTo(stream);
            }
            return fileName;
        }
        public bool Upload(List<IFormFile> files, string uploadDirectory)
        {
            try
            {
                var uploadPath = Path.Combine(env.WebRootPath, uploadDirectory);

                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                foreach (var file in files)
                {
                    var filePath = Path.Combine(uploadPath, file.FileName);

                    using (var stream = File.Create(filePath))
                    {
                        file.CopyTo(stream);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                //Log exception
                return false;
            }

        }
        public string Download(string fileName, string directory)
        {
            var fullPath = Path.Combine(env.WebRootPath, directory) + fileName;
            if (File.Exists(fullPath))
            {
                return fullPath;
            }
            return "";
        }
        public bool Delete(string fileName, string directory)
        {
            var fullPath = Path.Combine(env.WebRootPath, directory) + fileName;
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return true;
            }
            return false;
        }
    }
}
