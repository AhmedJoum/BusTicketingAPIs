using AdeelaAPI.Filters;
using AdeelaAPI.Models;
using AdeelaAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdeelaAPI.Controllers
{
    [UserAuthorize]
    public class PassengerController : ApiController
    {

        private ResponseFactory respFactory = new ResponseFactory();

       public Passenger Model { get
            {
                Passenger obj = new Passenger();
                return obj;
            } }


        [ActionName("AllRoutes")]
        [HttpGet]
        public HttpResponseMessage GetAllRoutes ()
        {
            object result = Model.GetAllRoutes();
            HttpResponseMessage msg = respFactory.GetResponseMsg(Request, result);
            return msg;
        }

        [ActionName("RouteFilter")]
        [HttpPost]
        public HttpResponseMessage GetRoutesByFilter([FromBody]Passenger passenger)
        {
            object result = passenger.GetRoutesByFilter();
            HttpResponseMessage msg = respFactory.GetResponseMsg(Request, result);
            return msg;
        }

        [ActionName("IssueTicket")]
        [HttpPost] 
        public HttpResponseMessage PostIssuedTicket([FromBody]Passenger passenger)
        {
            object result = passenger.IssueTicket();
            HttpResponseMessage msg = respFactory.GetResponseMsg(Request, result);
            return msg;
        }

    }
}
