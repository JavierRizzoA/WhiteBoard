using System.Collections.Generic;
using System.ServiceModel;

namespace WhiteBoardImages
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IImageService" in both code and config file together.
    [ServiceContract]
    public interface IImageService
    {
        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here

        [OperationContract]
        List<string> SavedImages();

        //[OperationContract]
        //bool SaveImage(byte[] image);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
