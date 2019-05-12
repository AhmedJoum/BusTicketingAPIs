using AdeelaAPI.Filters;
using AdeelaAPI.Models;
using AdeelaAPI.Utils;
using System.Net.Http;
using System.Web.Http;


namespace AdeelaAPI.Controllers
{
    [UserAuthorize]
    public class UserController : ApiController
    {
        private ResponseFactory respFactory = new ResponseFactory();
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
            object result = user.UserLogin();
            HttpResponseMessage msg = respFactory.GetResponseMsg(Request, result);
            return msg;
        }
    }
}
