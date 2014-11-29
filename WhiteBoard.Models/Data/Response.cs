using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhiteBoard.Models.Data
{
    public class Response
    {
        public bool Succesfull { get { return !Errors.Any(); } }
        public List<string> Errors { get; set; }

        public Response()
        {
            Errors = new List<string>();
        }
    }
}
