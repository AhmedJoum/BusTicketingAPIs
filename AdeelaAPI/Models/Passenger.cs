using AdeelaAPI.Services;
using AdeelaAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdeelaAPI.Models
{
    public class Passenger
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
        //Ticket Issuing properties
        public string PaymentBy { get; set; }
        public string PayTransactionNo { get; set; }
        public string Bank { get; set; }
        public string AccountNo { get; set; }



        internal object GetAllRoutes()
        {
            try
            {
                List<AgencyRoutSelect_Result> result = Context.AgencyRoutSelect().ToList();
                return new { Status = 0, Routes = result };
            }
            catch (Exception ex)
            {

                return ExcptionHandler.OnException(ex);
            }
        }


        internal object GetRoutesByFilter()
        {
            try
            {
                List<AgencyRoutSelect_Result> result = Context.AgencyRoutSelect().ToList();

                result = FilterRoutesByFromCityCode(result);
                result = FilterRouteByToCityCode(result);
                result = FilterRoutesByAgencyID(result);
                result = FilterRouteByDate(result);

                return new { Status = 1, Routes = result };

            }
            catch (Exception ex)
            {

                return ExcptionHandler.OnException(ex);
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


        internal object IssueTicket()
        {
            try
            {
                var result = Context.TicketInsert(this.UserID,
                    this.AgencyRouteID,
                    this.Price,
                    DateTime.Now,
                    this.PaymentBy,
                    this.PayTransactionNo,
                    this.Bank,
                    this.AccountNo).FirstOrDefault();

                return new { status = 1, result.TicketNo };
            }
            catch (Exception ex)
            {
                return ExcptionHandler.OnException(ex);
            }
        }

    }
}