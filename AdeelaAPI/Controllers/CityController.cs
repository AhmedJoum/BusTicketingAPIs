using AdeelaAPI.Filters;
using AdeelaAPI.Models;
using AdeelaAPI.Utils;
using System;
using System.Net.Http;
using System.Web.Http;

namespace AdeelaAPI.Controllers
{
    [UserAuthorize]

    public class CityController : ApiController
    {
        private ResponseFactory respFactory = new ResponseFactory();
        public City Model
        {
            get
            {
                City city = new City();
                return city;
            }
        }


        public HttpResponseMessage Get()
        {
            try
            {
                object result = Model.GetAllCities();
                HttpResponseMessage msg = respFactory.GetResponseMsg(Request, result);
                return msg;
            }
            catch (Exception ex)
            {
                return ExcptionHandler.OnActionException(Request, ex);
            }

        }


        [ActionName("New")]
        [HttpPost]
        public HttpResponseMessage PostNewCityDetails([FromBody] City city)
        {
            try
            {
                object result = city.CreateNewCity();
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
