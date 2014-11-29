using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace WhiteBoardImages
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ImageService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ImageService.svc or ImageService.svc.cs at the Solution Explorer and start debugging.
    public class ImageService : IImageService
    {
        public List<string> SavedImages()
        {
            var hostname = Environment.MachineName;
            var imagesFolder = HttpContext.Current.Request.MapPath("Images");

            var images = new List<string>();
            var imageNames = new DirectoryInfo(imagesFolder).GetFiles("*.jpg");

            foreach (var imageName in imageNames)
            {
                var imageURI = string.Format("http://{0}{1}{2}", hostname, "/WhiteBoardImages/Images/", imageName.Name);
                images.Add(imageURI);
            }

            return images;
        }
    }
}
