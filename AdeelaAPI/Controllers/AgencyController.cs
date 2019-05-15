using AdeelaAPI.Filters;
using AdeelaAPI.Models;
using AdeelaAPI.Utils;
using System;
using System.Net.Http;
using System.Web.Http;

namespace AdeelaAPI.Controllers
{

    [UserAuthorize]
    public class AgencyController : ApiController
    {
        private readonly ResponseFactory responceFactory = new ResponseFactory();
        public Agency Model
        {
            get
            {
                Agency obj = new Agency();
                return obj;
            }
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var result = Model.GetAllAgencies();
                HttpResponseMessage msg = responceFactory.GetResponseMsg(Request, result);
                return msg;
            }
            catch (Exception ex)
            {
                return ExcptionHandler.OnActionException(Request, ex);
            }
        }

        [ActionName("Details")]
        [HttpPost]
        public HttpResponseMessage GetAgencyDetails([FromBody] Agency agency)
        {
            try
            {
                var result = agency.GetAgencyByID();
                HttpResponseMessage msg = responceFactory.GetResponseMsg(Request, result);
                return msg;
            }
            catch (Exception ex)
            {
                return ExcptionHandler.OnActionException(Request, ex);
            }
        }

        [ActionName("AvilableRoutes")]
        [HttpGet]
        public HttpResponseMessage GetAvailableRoutes()
        {
            try
            {
                object result = Model.GetAvailableRoutes();
                HttpResponseMessage msg = responceFactory.GetResponseMsg(Request, result);
                return msg;
            }
            catch (Exception ex)
            {
                return ExcptionHandler.OnActionException(Request, ex);
            }

        }



        [ActionName("AddBusRoute")]
        [HttpPost]
        public HttpResponseMessage PostAgencyRout([FromBody] Route route)
        {
            try
            {
                var result = route.AddAgencyRoute();
                HttpResponseMessage msg = responceFactory.GetResponseMsg(Request, result);
                return msg;
            }
            catch (Exception ex)
            {
                return ExcptionHandler.OnActionException(Request, ex);
            }

        }

        [ActionName("MyBusRoutes")]
        [HttpPost]
        public HttpResponseMessage GetAgencyRoutes([FromBody] Route agencyRoute)
        {
            try
            {
                var result = agencyRoute.GetBusRoutesByFilter();
                HttpResponseMessage msg = responceFactory.GetResponseMsg(Request, result);
                return msg;
            }
            catch (Exception ex)
            {
                return ExcptionHandler.OnActionException(Request, ex);
            }

        }

        [ActionName("MySoldTickets")]
        [HttpPost]
        public HttpResponseMessage GetAgencySoldTickets([FromBody] Agency agency)
        {
            try
            {
                var result = Model.GetAgencySoldTickets(agency);
                HttpResponseMessage msg = responceFactory.GetResponseMsg(Request, result);
                return msg;
            }
            catch (Exception ex)
            {
                return ExcptionHandler.OnActionException(Request, ex);
            }
        }

        [ActionName("MyAgencies")]
        [HttpGet]
        public HttpResponseMessage GetUserAgencies()
        {
            try
            {
                var result = Model.GetUserAgencies();
                HttpResponseMessage msg = responceFactory.GetResponseMsg(Request, result);
                return msg;
            }
            catch (Exception ex)
            {
                return ExcptionHandler.OnActionException(Request, ex);
            }
        }


    }
}
