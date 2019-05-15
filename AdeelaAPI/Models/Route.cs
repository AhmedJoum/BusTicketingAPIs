using AdeelaAPI.Services;
using AdeelaAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdeelaAPI.Models
{
    public class Route
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


        public int AgencyRouteID { get; set; }
        public int? AgencyID { get; set; }
        public int? RouteID { get; set; }
        public DateTime? Date { get; set; }
        public string TravilTime { get; set; } = "";
        public int AvailableTickets { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string FromCityCode { get; set; } = "";
        public string FromCityName { get; set; } = "";
        public string FromCityNameArabic { get; set; } = "";
        public string ToCityCode { get; set; } = "";
        public string ToCityName { get; set; } = "";
        public string ToCityNameArabic { get; set; } = "";
        public int IssuedTickets { get; set; }

       


        internal object GetBusRoutesByFilter()
        {
            try
            {
               List<AgencyRoutSelect_Result> FilterResult = Context.AgencyRoutSelect().ToList();

                FilterResult = FilterRoutesByFromCityCode(FilterResult);
                FilterResult = FilterRouteByToCityCode(FilterResult);
                FilterResult = FilterRoutesByAgencyID(FilterResult);
                FilterResult = FilterRouteByDate(FilterResult);

                return new { Status = 1, Routes = FilterResult };

            }
            catch (Exception ex)
            {

                return ExcptionHandler.OnModelMethodeException(ex);
            }
        }

        #region Routes Filter
        private List<AgencyRoutSelect_Result> FilterRoutesByFromCityCode(List<AgencyRoutSelect_Result> result)
        {
            if (this.FromCityCode != "")
            {
                result = result.Where(r => r.FromCityCode == this.FromCityCode).ToList();
            }

            return result;
        }

        private List<AgencyRoutSelect_Result> FilterRouteByToCityCode(List<AgencyRoutSelect_Result> result)
        {
            if (this.ToCityCode != "")
            {
                result = result.Where(r => r.ToCityCode == this.ToCityCode).ToList();
            }

            return result;
        }


        private List<AgencyRoutSelect_Result> FilterRoutesByAgencyID(List<AgencyRoutSelect_Result> result)
        {
            if (this.AgencyID != null)
            {
                result = result.Where(r => r.AgencyID == this.AgencyID).ToList();
            }

            return result;
        }

        private List<AgencyRoutSelect_Result> FilterRouteByDate(List<AgencyRoutSelect_Result> result)
        {
            if (this.Date != null)
            {
                result = result.Where(r => r.Date == this.Date).ToList();
            }

            return result;
        }

        #endregion

        internal object AddAgencyRoute()
        {
            try
            {
                System.Data.Objects.ObjectResult<decimal?> result = Context.AgencyRouteInsert(this.AgencyID,
                    this.RouteID,
                    this.Date,
                    this.TravilTime,
                    this.AvailableTickets,
                    this.Price,
                    this.Description);

                return new { Status = 1, RouteID = result };
            }
            catch (Exception ex)
            {

                return ExcptionHandler.OnModelMethodeException(ex);
            }
        }
    }
}