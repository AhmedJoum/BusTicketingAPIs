

using AdeelaAPI.Utils;
using System;
using System.Linq;

namespace AdeelaAPI.Models

{
    public class User
    {
        private const string LOGIN_MSG = "Wrong Phone Number or password";
        private const string LOGIN_MSG_ARABIC = "رقم الهاتف او كلمة المرور المدخلة غير صحيحة";
        private AdeelaEntities Context = new AdeelaEntities();

        public int? ID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int? TypeID { get; set; }
        public string TypeName { get; set; }
        public string DeviceID { get; set; }
        public Guid? Token { get; set; }


        internal object UserLogin()
        {
            try
            {

                if (CheckIsUserCredintialsRight())
                {
                    if (!CheckIsUserHasToken())
                    {
                        CeateUserToken();
                    }

                    return new { Status = 1, this.Token };
                }
                else
                {
                    return new { Status = 0, Msg = LOGIN_MSG, MsgArabic = LOGIN_MSG_ARABIC };
                }
            }
            catch (Exception ex)
            {

                return ExcptionHandler.OnException(ex);
            }
        }

        private bool CheckIsUserCredintialsRight()
        {
            try
            {
                this.ID = Context.UserLogin(this.Phone, this.Password).FirstOrDefault();
                return this.ID > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool CheckIsUserHasToken()
        {
            try
            {
                TokenManagerCheckUserValidToken_Result UserHasTokenResult =
                        Context.TokenManagerCheckUserValidToken(this.ID).FirstOrDefault();

                this.Token = UserHasTokenResult.Token;
                return UserHasTokenResult.result > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CeateUserToken()
        {
            try
            {
                Guid? UserTokenCreateResult = Context.TokenMangerInsert(this.ID, this.DeviceID).FirstOrDefault();
                this.Token = UserTokenCreateResult;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}