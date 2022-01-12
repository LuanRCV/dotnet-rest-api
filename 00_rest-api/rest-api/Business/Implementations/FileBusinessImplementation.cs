using Microsoft.AspNetCore.Http;
using rest_api.Data.VO;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace rest_api.Business.Implementations
{
    public class FileBusinessImplementation : IFileBusiness
    {
        private readonly string _basePath;
        private readonly IHttpContextAccessor _context;

        public FileBusinessImplementation(IHttpContextAccessor context)
        {
            _context = context;
            _basePath = Directory.GetCurrentDirectory() + "\\UploadDir\\";
        }

        public byte[] GetFile(string filename)
        {
            var filePath = _basePath + filename;

            return File.ReadAllBytes(filePath);
        }
        public async Task<FileDetailVO> SaveFileToDisk(IFormFile file)
        {
            FileDetailVO fileDetail = new FileDetailVO();

            string fileType = Path.GetExtension(file.FileName).ToLower();
            HostString baseUrl = _context.HttpContext.Request.Host;

            if (fileType == ".pdf" || fileType == ".jpg" ||
                fileType == ".png" || fileType == ".jpeg")
            {
                string docName = Path.GetFileName(file.FileName);

                if (file != null && (file.Length > 0))
                {
                    string destination = Path.Combine(_basePath, "", docName);

                    fileDetail.DocumentName = docName;
                    fileDetail.DocumentType = fileType;
                    fileDetail.DocumentUrl = Path.Combine(baseUrl + "/api/file/v1/" + fileDetail.DocumentName);

                    using var stream = new FileStream(destination, FileMode.Create);
                    await file.CopyToAsync(stream);
                }
            }

            return fileDetail;
        }

        public async Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> files)
        {
            List<FileDetailVO> list = new List<FileDetailVO>();

            foreach (var file in files)
            {
                list.Add(await SaveFileToDisk(file));
            }

            return list;
        }
    }
}
