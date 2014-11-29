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

            var apPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
            var imagesFolder = string.Format("{0}{1}", apPath, "Images");

            var images = new List<string>();
            var imageNames = new DirectoryInfo(imagesFolder).GetFiles("*.jpg");

            foreach (var imageName in imageNames)
            {
                var imageURI = string.Format("http://{0}{1}{2}", hostname, "/WhiteBoardImages/Images/", imageName.Name);
                images.Add(imageURI);
            }

            return images;
        }
        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
    }
}
