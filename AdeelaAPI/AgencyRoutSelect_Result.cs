//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdeelaAPI
{
    using System;
    
    public partial class AgencyRoutSelect_Result
    {
        public int ID { get; set; }
        public int AgencyID { get; set; }
        public int RouteID { get; set; }
        public System.DateTime Date { get; set; }
        public string TravelTime { get; set; }
        public int AvailableTickets { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int IssuedTickets { get; set; }
        public string FromCityCode { get; set; }
        public string FromCityName { get; set; }
        public string FromCityNameArabic { get; set; }
        public string ToCityCode { get; set; }
        public string ToCityName { get; set; }
        public string ToCityNameArabic { get; set; }
    }
}
