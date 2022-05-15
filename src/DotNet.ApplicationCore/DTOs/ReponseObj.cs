using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet.ApplicationCore.DTOs
{
    public class ReponseObj
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}
