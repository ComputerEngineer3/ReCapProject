using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helper
{
    public class FileHelper
    {
        static string directory = Environment.CurrentDirectory + @"\wwwroot\";
        static string folderName = "\\Images\\";

        public static string Add(IFormFile file)
        {
            var sourcePath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            var result = newPath(file);
            File.Move(sourcePath, result);
            return result;
        }


        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
                return new SuccessResult();
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }
         
        }


        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            File.Delete(sourcePath);
            return result;
        }


        public static string newPath(IFormFile file)
        {
            string fileExtension = (new FileInfo(file.FileName)).Extension;

            string path = Environment.CurrentDirectory + @"\Images";
            var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;
            string result = $@"{path}/{newPath}";

            return result;
        }

    }
}
