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



        public int AgencyID { get; set; }

        public Route Route { get; set; }

        internal object GetAllAgencies()
        {
            try
            {
                List<AgencySelect_Result> result = Context.AgencySelect().ToList();
                return new { Status = 1, Agencies = result };
            }
            catch (Exception ex)
            {
                return ExcptionHandler.OnModelMethodeException(ex);
            }
        }

        internal object GetAgencyByID()
        {
            try
            {
                IEnumerable<AgencySelect_Result> result = Context.AgencySelect().Where(a => a.ID == this.AgencyID);
                return new { Status = 1, Agency = result };
            }
            catch (Exception ex)
            {
                return ExcptionHandler.OnModelMethodeException(ex);
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

                return ExcptionHandler.OnModelMethodeException(ex);
            }
        }


        internal object GetAgencySoldTickets(Agency agency)
        {
            try
            {
                IEnumerable<TicketSelect_Result> result = Context.TicketSelect().Where(t => t.AgencyRoutID == agency.AgencyID);
                return new { Status = 1, Tickects = result };
            }
            catch (Exception ex)
            {

                return ExcptionHandler.OnModelMethodeException(ex);
            }
        }

        internal object GetUserAgencies()
        {
            try
            {
                var result = Context.AgencySelect().Where(a => a.UserID == this.UserID);
                return new { Status = 1, Agencies = result }; 
            }
            catch (Exception ex)
            {
                return ExcptionHandler.OnModelMethodeException(ex);
            }
        }
    }
}