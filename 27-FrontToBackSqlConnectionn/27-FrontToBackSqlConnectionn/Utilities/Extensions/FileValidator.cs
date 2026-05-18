using _27_FrontToBackSqlConnectionn.Models;
using _27_FrontToBackSqlConnectionn.Utilities.Enums;
using NuGet.Protocol.Plugins;

namespace _27_FrontToBackSqlConnectionn.Utilities.Extensions
{
    public static class FileValidator
    {
        public static bool CheckFileType(this IFormFile file, string type)
        {
            if (file.ContentType.Contains(type))
            {
                return true;
            }
            return false;
        }
        public static bool CheckFileSize(this IFormFile file, FileSize fileSize, decimal size)
        {
            switch (fileSize)
            {
                case FileSize.KB:
                    return file.Length <= size * 1024;

                case FileSize.MB:
                    return file.Length <= size * 1024 * 1024;

                case FileSize.GB:
                    return file.Length <= size * 1024 * (1024 * 1024);



            }
            return false;
        }
        public static async Task<string> CreateFile(this IFormFile file, params string[] roots)
        {
            string fileName = string.Concat(Guid.NewGuid().ToString(), file.FileName);


            string path = string.Empty;
            for (int i = 0; i < roots.Length; i++)
            {
                path = Path.Combine(path, roots[i]);
            }
            path = Path.Combine(path, fileName);


            using (FileStream fileStream = new(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);

            }
            return fileName;




        }
    }
}
