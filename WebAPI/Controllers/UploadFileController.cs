using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebAPI.Infrastructure.Core;

namespace WebAPI.Controllers
{
    [RoutePrefix("uploadfile")]
    public class UploadFileController : ApiController
    {

        BlobStorageService _blobService;
        public UploadFileController(BlobStorageService blobService) :base()
        {
            _blobService = blobService;
        }

        public UploadFileController()
        {
            
        }
        [HttpPost]
        [Route("uploadfile")]
        public async Task<string> UploadFile()
        {
            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("https:\\danafoodapp.blob.core.windows.net\\images");
            var provider = new MultipartFileStreamProvider(root);
            string filePath = "";
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                foreach (var file in provider.FileData)
                {
                    var name = file.Headers.ContentDisposition.FileName;

                    name = name.Trim('"');
                    var localfilename = file.LocalFileName;
                    filePath += Path.Combine(root, name);
                    //blockBlob.UploadFromStream();
                    File.Move(localfilename, filePath);
                    
                }
            }
            catch (Exception ex)
            {

                return "Upload fail";
            }

            return filePath;
        }


        //[HttpPost]
        //[Route("uploadfile")]
        //public async Task<string> UploadFile()
        //{
        //    var ctx = HttpContext.Current;
        //    var root = ctx.Server.MapPath("~/Images");
        //    var provider = new MultipartFileStreamProvider(root);
        //    string filePath = "";
        //    try
        //    {
        //        await Request.Content.ReadAsMultipartAsync(provider);

        //        foreach (var file in provider.FileData)
        //        {
        //            var name = file.Headers.ContentDisposition.FileName;

        //            name = name.Trim('"');
        //            var localfilename = file.LocalFileName;
        //            filePath += Path.Combine(root, name);
        //            File.Move(localfilename, filePath);

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        return "Upload fail";
        //    }

        //    return filePath;
        //}
    }
}
