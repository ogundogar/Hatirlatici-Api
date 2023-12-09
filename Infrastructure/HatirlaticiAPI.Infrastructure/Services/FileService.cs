using HatirlaticiAPI.Application.Repositories.UsersRepository;
using HatirlaticiAPI.Application.Services;
using HatirlaticiAPI.Infrastructure.Operations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatirlaticiAPI.Infrastructure.Services
{
    public class FileService : IFileService
    {
        readonly private IWebHostEnvironment _webHostEnvironment;
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
            
            List<(string fileName, string path)> datas = new();
            List<bool> results = new();
            foreach (IFormFile item in files)
            {
                string newFileName = await FileRenameAsync(uploadPath,item.Name);
                bool result= await CopyFileAsync($"{uploadPath}\\{newFileName}",item);
                datas.Add((newFileName, $"{path}\\{newFileName}"));
                results.Add(result);
            }
            if (results.TrueForAll(r => r.Equals(true)))
                return datas;
            return null;
        }

        public async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
            await using FileStream fileStream=new(
                path,FileMode.Create,
                FileAccess.Write,
                FileShare.None,
                1024*1024,
                useAsync:false);

            await file.CopyToAsync(fileStream);
            await fileStream.FlushAsync();

            return true;
            }
            catch 
            {
            return false;
            }
           
        }

        private async Task<string> FileRenameAsync(string path,string fileName, bool first =true)
        {
            string newFileName= await Task.Run<string>(async () =>
            {
              
                string extension = Path.GetExtension(fileName);
                string oldName = Path.GetFileNameWithoutExtension(fileName);
                string newFileName = $"{NameOperation.CharacterRegulatory(oldName)}{extension}";
                if (File.Exists($"{path}\\{newFileName}"))
                {
                    string name= Path.GetFileNameWithoutExtension(newFileName);
                    if (name.IndexOf("-")==-1)
                    {
                        return await FileRenameAsync(path, $"{name}-1{extension}", false);
                    }
                    else
                    {
                        string[] number = name.Split('-');
                        name = name.Replace($"-{number[1].Trim()}",$"-{((int.Parse(number[1].Trim()) + 1).ToString())}");
                        return await FileRenameAsync(path, $"{name}{extension}", false);
                    }
                }
                else
                    return newFileName;
            });
            return newFileName;
        }

    }
}
