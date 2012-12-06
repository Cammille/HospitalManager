using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace picard_bManageHospital.DataAccess
{
    class User
    {
        public bool Connect(string login, string pwd)
        {
            return new ServiceUser.ServiceUserClient().Connect(login, pwd);
        }

        public ServiceUser.User GetUser(string login)
        {
            return new ServiceUser.ServiceUserClient().GetUser(login);
        }
    }
}
