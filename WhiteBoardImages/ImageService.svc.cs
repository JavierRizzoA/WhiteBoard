﻿using System;

namespace WhiteBoardImages
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ImageService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ImageService.svc or ImageService.svc.cs at the Solution Explorer and start debugging.
    public class ImageService : IImageService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
