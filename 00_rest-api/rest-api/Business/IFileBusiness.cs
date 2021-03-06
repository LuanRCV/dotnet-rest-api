using Microsoft.AspNetCore.Http;
using rest_api.Data.VO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rest_api.Business
{
    public interface IFileBusiness
    {
        public byte[] GetFile(string filename);
        public Task<FileDetailVO> SaveFileToDisk(IFormFile file);
        public Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> files);
    }
}
