using System.Collections.Generic;
using System.Linq;

namespace WhiteBoard.Models.Data
{
    public class Response<T>
    {
        public bool Succesfull { get { return !Errors.Any(); } }
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        public Response()
        {
            Errors = new List<string>();
        }
    }
}
