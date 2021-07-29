using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaV3.Api.Response
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }

        public ApiResponse(T data)
        {
            Data = data;
        }
    }
}
