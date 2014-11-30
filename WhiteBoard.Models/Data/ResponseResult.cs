using System.Collections.Generic;
using System.Linq;

namespace WhiteBoard.Models.Data
{
    public class ResponseResult<T> : Response
    {

        public T Data { get; set; }

    }
}
