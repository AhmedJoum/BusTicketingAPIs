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
        

        public Route Route { set; get; }
     
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


        internal object IssueTicket()
        {
            try
            {
                var result = Context.TicketInsert(this.UserID,
                    this.Route.AgencyRouteID,
                    this.Route.Price,
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