using AdeelaAPI.Services;
using AdeelaAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdeelaAPI.Models
{
    public class Agency
    {
        private readonly AdeelaEntities Context = new AdeelaEntities();
        private UserIdentityService UserIDService = new UserIdentityService();


        public int UserID
        {
            get
            {
                try
                {
                    return Convert.ToInt32(UserIDService.UserID);
                }
                catch
                {
                    return 0;
                }
            }
        }

        internal object GetAvailableRoutes()
        {
            try
            {
                List<RouteSelect_Result> result = Context.RouteSelect().ToList();
                return new { Status = 1, Routes = result };
            }
            catch (Exception ex)
            {

                return ExcptionHandler.OnException(ex);
            }
        }
    }
}