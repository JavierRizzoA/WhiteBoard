

using System;
using System.Collections.Generic;
using System.Linq;
using WhiteBoard.Models.Data;

namespace WhiteBoard.Business.Services
{
    public class ImageService
    {
        private readonly ServiceImage.ImageService imgSVC;
        public ImageService()
        {
            imgSVC = new ServiceImage.ImageService();
        }

        public Response<IEnumerable<Dataimage>> ObatainSavedimages()
        {
            var response = new Response<IEnumerable<Dataimage>>();
            try
            {
                response.Data = imgSVC.SavedImages().Select(x=>new Dataimage{ImageUri = new Uri(x)});
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
            }

            return response;
        }
    }
}
