using System;
using System.Net.Http;

namespace AdeelaAPI.Utils
{
    public class ExcptionHandler
    {
        private const string ACTION_ERROR_SOLUTION = "Check if the Body Object is written correctly ...";
        private static readonly ResponseFactory responceFactory = new ResponseFactory();

        public static object OnModelMethodeException(Exception ex)
        {
#if DEBUG
            throw ex;
#endif
            return new { Status = 0, ErrorMsg = ex.Message };
        }


        public static HttpResponseMessage OnActionException(HttpRequestMessage Request, Exception ex)
        {

            var ErrorObj = new { Status = 0, Solution = ACTION_ERROR_SOLUTION, ErrorMsg = ex.Message };
            HttpResponseMessage msg = responceFactory.GetResponseMsg(Request, ErrorObj);
            return msg;
        }
    }
}