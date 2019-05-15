using AdeelaAPI.Filters;
using AdeelaAPI.Models;
using AdeelaAPI.Utils;
using System;
using System.Net.Http;
using System.Web.Http;

namespace AdeelaAPI.Controllers
{
    [UserAuthorize]
    public class PassengerController : ApiController
    {

        private ResponseFactory respFactory = new ResponseFactory();

        public Passenger PassengerModel
        {
            get
            {
                Passenger obj = new Passenger();
                return obj;
            }
        }

        public Route RouteModel
        {
            get
            {
                Route obj = new Route();
                return obj;
            }
        }


        [ActionName("AllBusRoutes")]
        [HttpGet]
        public HttpResponseMessage GetAllRoutes()
        {
            try
            {
                object result = RouteModel.GetBusRoutesByFilter();
                HttpResponseMessage msg = respFactory.GetResponseMsg(Request, result);
                return msg;
            }
            catch (Exception ex)
            {
                return ExcptionHandler.OnActionException(Request, ex);
            }

        }

        [ActionName("BusRouteFilter")]
        [HttpPost]
        public HttpResponseMessage GetRoutesByFilter([FromBody]Route route)
        {
            try
            {
                object result = route.GetBusRoutesByFilter();
                HttpResponseMessage msg = respFactory.GetResponseMsg(Request, result);
                return msg;
            }
            catch (Exception ex)
            {
                return ExcptionHandler.OnActionException(Request, ex);
            }
           
        }

        [ActionName("IssueTicket")]
        [HttpPost]
        public HttpResponseMessage PostIssuedTicket([FromBody]Passenger passenger)
        {
            try
            {
                object result = passenger.IssueTicket();
                HttpResponseMessage msg = respFactory.GetResponseMsg(Request, result);
                return msg;
            }
            catch (Exception ex)
            {
                return ExcptionHandler.OnActionException(Request, ex);
            }
           
        }

    }
}
