using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdeelaAPI.Utils
{
    public class ResponseFactory
    {
        /// <summary>
        /// generate response message with result object. 
        /// all results with HttpStatusCode.OK
        /// if there is an error [status] parameter in the [Result] object will not be 1.
        /// [status] = -1 => user with invalid token key.
        /// [status] = 0 =>  invalid input or database error.
        /// </summary>
        /// <param name="Request"></param>
        /// <param name="Result"></param>
        /// <returns>
        /// object with status parameters and result requested object/list of objects. 
        /// [status] = -1 => user with invalid token key.
        /// [status] = 0 =>  invalid input or database error.
        /// </returns>
        public HttpResponseMessage GetResponseMsg(HttpRequestMessage Request, object Result)
        {
            HttpResponseMessage ResponseMessage = null;
            int Status = Convert.ToInt32(Result.GetType().GetProperty("Status").GetValue(Result, null).ToString());
            if (Status == 1)
            {
                ResponseMessage = Request.CreateResponse(HttpStatusCode.OK, Result);
                return ResponseMessage;
            }
            else if (Status == -1)
            {
                ResponseMessage = Request.CreateResponse(HttpStatusCode.Unauthorized, Result);
                return ResponseMessage;
            }
            else
            {
                ResponseMessage = Request.CreateResponse(HttpStatusCode.InternalServerError, Result);
                return ResponseMessage;
            }
        }
    }
}