using AdeelaAPI.Services;
using AdeelaAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdeelaAPI.Models
{
    public class City
    {

        private readonly AdeelaEntities Context = new AdeelaEntities();
        private UserIdentityService UserIDService = new UserIdentityService();

        private int  UserID
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
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameArabic { get; set; }

        internal object GetAllCities()
        {
            try
            {
                List<CitySelect_Result> result = Context.CitySelect().ToList();
                return new { Status = 1, Cities = result};
            }
            catch (Exception ex)
            {
                return ExcptionHandler.OnException(ex);
            }
        }

        internal object CreateNewCity()
        {
            try
            {
                var result = Context.CityInsert(this.Code, this.Name, this.NameArabic).FirstOrDefault();
                return new { Status = 1, CityID = result };
            }
            catch (Exception ex)
            {

                return ExcptionHandler.OnException(ex);
            }
        }
    }
}