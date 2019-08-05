using System;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using InfraStructure.Storage;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Http;

namespace HelloChinaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpGet("Download")]
        public FileResult Download(string filename)
        {
            string fileExt = Path.GetExtension(filename);
            //获取文件的ContentType
            var provider = new FileExtensionContentTypeProvider();
            var memi = provider.Mappings[fileExt];
            var stream = MongoStorage.GetFile(filename, Config.FSDBName);
            stream.Position = 0;    //关键语句，将流的位置重置，不然结果为空
            return File(stream, memi, filename);
        }


        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="IFormFile"></param>
        /// <returns></returns>
        [HttpPost("Upload")]
        public ActionResult<String> Upload(IFormFile file)
        {
            MongoStorage.InsertStreamWithFixFileName(file.OpenReadStream(), file.FileName, Config.FSDBName);
            return file.FileName;
        }
    }
}
