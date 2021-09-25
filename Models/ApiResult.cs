using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Captcha.Models
{
    public class ApiResult<TResult>
    {
        public bool Succeeded { get; set; }
        public TResult Result { get; set; }
 
        public static ApiResult<TResult> StandardOk(TResult result)
        {
            return new ApiResult<TResult>
            {
                Succeeded = true,
                Result = result, 
            };
        }

       
    }

}
