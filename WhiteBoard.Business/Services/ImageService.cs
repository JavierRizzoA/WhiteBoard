

using System;
using System.Collections.Generic;
using System.Security.Permissions;
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

        public Response<IEnumerable<string>> ObatainSavedimages()
        {
            var response = new Response<IEnumerable<string>>();
            try
            {
                response.Data = imgSVC.SavedImages();
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
            }

            return response;
        }
    }
}
