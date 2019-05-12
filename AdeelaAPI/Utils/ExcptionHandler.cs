using System;

namespace AdeelaAPI.Utils
{
    public class ExcptionHandler
    {
        public static object OnException(Exception ex)
        {
#if DEBUG
            throw ex;
#endif
            return new { Status = 0, ErrorMsg = ex.Message };
        }
    }
}