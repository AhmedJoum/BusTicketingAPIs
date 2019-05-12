using AdeelaAPI.Filters;
using AdeelaAPI.Models;
using AdeelaAPI.Utils;
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
            object result = Model.GetAllCities();
            HttpResponseMessage msg = respFactory.GetResponseMsg(Request, result);
            return msg;
        }


        [ActionName("New")]
        [HttpPost]
        public HttpResponseMessage PostNewCityDetails([FromBody] City city)
        {
            object result = city.CreateNewCity();
            HttpResponseMessage msg = respFactory.GetResponseMsg(Request, result);
            return msg;
        }
    }
}
