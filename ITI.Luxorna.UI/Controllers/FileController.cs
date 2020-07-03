using ITI.Luxorna.UI.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ITI.Luxorna.UI
{
    public class FileController : ApiController
    {
        [HttpPost]
        public async Task<ResultViewModels<List<UploadedFile>>> Upload()
        {
            ResultViewModels<List<UploadedFile>> resultViewModel = new ResultViewModels<List<UploadedFile>>();
            List<UploadedFile> uploadedFiles = new List<UploadedFile>();
            try
            {
                ////if (Request.Content.IsMimeMultipartContent())
                ////{
                    string root = HttpContext.Current.Server.MapPath("~/Upload/");
                    if (!Directory.Exists(root))
                        Directory.CreateDirectory(root);

                    CustomMultipartFormDataStreamProvider provider = new CustomMultipartFormDataStreamProvider(root);
                    await Request.Content.ReadAsMultipartAsync(provider);
                    foreach (MultipartFileData file in provider.FileData)
                        uploadedFiles.Add(new UploadedFile
                        {
                            Name = file.LocalFileName.Split('\\').Last().Split('.').First().Split('_').First(),
                            Path = file.LocalFileName.Split('\\').Last(),
                            Extension = file.LocalFileName.Split('\\').Last().Split('.').Last()
                        });
                    resultViewModel.Successed = true;
                    resultViewModel.Data = uploadedFiles;

                //}
                //else
                //{
                //    resultViewModel.Successed = false;
                //    resultViewModel.Message = "Error";
                //}
            }
            catch (Exception ex)
            {
                resultViewModel.Successed = false;
                resultViewModel.Message = "Resource.ErrorOccurred";
            }
            return resultViewModel;
        }
    }
}
