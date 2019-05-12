using AdeelaAPI.Filters;
using AdeelaAPI.Models;
using AdeelaAPI.Utils;
using System.Net.Http;
using System.Web.Http;

namespace AdeelaAPI.Controllers
{

    [UserAuthorize]
    public class AgencyController : ApiController
    {
        private readonly ResponseFactory respFactory = new ResponseFactory();
        public Agency Model
        {
            get
            {
                Agency obj = new Agency();
                return obj;
            }
        }
        // get all avilable routes 

        [ActionName("AvilableRoutes")]
        [HttpGet]
        public HttpResponseMessage GetAvailableRoutes()
        {
            var result = Model.GetAvailableRoutes();
            HttpResponseMessage msg = respFactory.GetResponseMsg(Request, result);
            return msg; 
        }
        //add a agency route

        // get all agency routes by Agency ID 

        // get all tickets with basic user info the Agency route by its ID.


    }
}
