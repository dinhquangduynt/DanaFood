using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    //[RoutePrefix("uploadfile")]
    public class UploadFileController : ApiController
    {

        [HttpPost]
        [Route("uploadfile")]
        public async Task<string> UploadFile()
        {
            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/App_Data");
            var provider = new MultipartFileStreamProvider(root);
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                foreach (var file in provider.FileData)
                {
                    var name = file.Headers.ContentDisposition.FileName;

                    name = name.Trim('"');
                   // name = name.Replace("'\\'", "'\'");
                    var localfilename = file.LocalFileName;
                    var filePath = Path.Combine(root, name);
                    File.Move(localfilename, filePath);
                    return filePath.Replace("\\","/");
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

            return "upload fail";
        }
    }
}
