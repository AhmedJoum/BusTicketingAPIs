using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace AdeelaAPI.Services
{
    public class UserIdentityService
    {
        public string UserID
        {
            get
            {
                return Thread.CurrentPrincipal.Identity.Name;
            }
        }
    }
}