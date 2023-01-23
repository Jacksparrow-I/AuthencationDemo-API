using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthencationDemo.Model
{
    public class common
    {
        public class BaseResponse
        {
            public Int64 ID { get; set; }
            public Boolean TransStatus { get; set; }
            public string status { get; set; }
            public int statusCode { get; set; }
            public string statusText { get; set; }

            public dynamic responseContent { get; set; }
        }

    }
}
