using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPI.Infrastructure.Core;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class BlobStorageController : ApiController
    {
        BlobStorageService _service = new BlobStorageService();

        // GET: BlobStorage
        //public HttpRequestMessage Index()
        //{
        //    List<BlobItemViewModel> items = new List<BlobItemViewModel>();

        //    // Retrieve a reference to a container.
        //    CloudBlobContainer container = _service.GetCloudBlogContainer();

        //    // Loop over items within the container and output the length and URI.
        //    foreach (IListBlobItem item in container.ListBlobs(null, false))
        //    {
        //        if (item.GetType() == typeof(CloudBlockBlob))
        //        {
        //            CloudBlockBlob blob = (CloudBlockBlob)item;
        //            items.Add(new BlobItemViewModel { Length = blob.Properties.Length, Uri = blob.Uri.ToString(), Type = Models.BlobType.BlobBlock });
        //        }
        //        else if (item.GetType() == typeof(CloudPageBlob))
        //        {
        //            CloudPageBlob pageBlob = (CloudPageBlob)item;
        //            items.Add(new BlobItemViewModel { Length = pageBlob.Properties.Length, Uri = pageBlob.Uri.ToString(), Type = Models.BlobType.BlobPage });
        //        }
        //        else if (item.GetType() == typeof(CloudBlobDirectory))
        //        {
        //            CloudBlobDirectory directory = (CloudBlobDirectory)item;
        //            items.Add(new BlobItemViewModel { Length = 0, Uri = directory.Uri.ToString(), Type = Models.BlobType.BlobDirectory });
        //        }
        //    }

        //    return null;
        //}


        [Route("upload")]
        [HttpPost]
        public async System.Threading.Tasks.Task<HttpResponseMessage > Upload(HttpRequestMessage request)
        {
            try
            {
                var provider = new MultipartMemoryStreamProvider();
                //CloudBlobContainer container = _service.GetCloudBlogContainer();
                //container.getblo
                //var request = HttpContext.Current.Request.f
                //if(request.)
                
                //CloudBlockBlob blod = container.GetBlobReference(request);


                //Stream blobStream = blockBlob.OpenRead();

                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {

                return request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }

        //public FileResult Download(string blobName)
        //{
        //    CloudBlobContainer container = _service.GetCloudBlogContainer();

        //    // Retrieve reference to a blob named "photo1.jpg".
        //    CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);

        //    Stream blobStream = blockBlob.OpenRead();
        //    return File(blobStream, blockBlob.Properties.ContentType, blobName);
        //}

        //public ActionResult Delete(string blobName)
        //{
        //    CloudBlobContainer container = _service.GetCloudBlogContainer();

        //    // Retrieve reference to a blob named "myblob.txt".
        //    CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);

        //    // Delete the blob.
        //    blockBlob.Delete();

        //    return RedirectToAction("Index");
        //}
    }
}