using AdeelaAPI.Filters;
using AdeelaAPI.Models;
using AdeelaAPI.Utils;
using System;
using System.Net.Http;
using System.Web.Http;


namespace AdeelaAPI.Controllers
{
    [UserAuthorize]
    public class UserController : ApiController
    {
        private ResponseFactory responseFactory = new ResponseFactory();
        public User Model
        {
            get
            {
                User obj = new User();
                return obj;
            }
        }

        [ActionName("Login")]
        [HttpPost]
        public HttpResponseMessage PostUserLogin([FromBody] User user)
        {
            try
            {
                object result = user.UserLogin();
                HttpResponseMessage msg = responseFactory.GetResponseMsg(Request, result);
                return msg;
            }
            catch (Exception ex)
            {
                return ExcptionHandler.OnActionException(Request, ex);
            }
        }

        [ActionName("SignUp")]
        [HttpPost]
        public HttpResponseMessage PostSignUpUserInfo([FromBody] User user)
        {
            try
            {
                object result = user.UserSignUp();
                HttpResponseMessage msg = responseFactory.GetResponseMsg(Request, result);
                return msg;
            }
            catch (Exception ex)
            {
                return ExcptionHandler.OnActionException(Request, ex);
            }
           
        }
    }
}
