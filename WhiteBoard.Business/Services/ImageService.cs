

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WhiteBoard.Models.Data;

namespace WhiteBoard.Business.Services
{
    public class ImageService
    {
        private readonly ServiceImage.ImageService _imgSVC;
        public ImageService()
        {
            _imgSVC = new ServiceImage.ImageService();
        }

        public ResponseResult<IEnumerable<Dataimage>> ObatainSavedimages()
        {
            var response = new ResponseResult<IEnumerable<Dataimage>>();
            try
            {
                response.Data = _imgSVC.SavedImages().Select(x => new Dataimage { ImageUri = new Uri(x) });
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
            }

            return response;
        }

        public Response SaveImage(byte[] bytes, string fileName)
        {
            var response = new Response();
            try
            {

                _imgSVC.SaveImage(bytes, fileName);
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
            }

            return response;
        }
    }
}
