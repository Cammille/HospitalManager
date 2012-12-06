using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

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

        public List<ServiceUser.User> GetListUser()
        {
            List<ServiceUser.User> serviceListUser = new List<ServiceUser.User>();
            try
            {
                serviceListUser = new ServiceUser.ServiceUserClient().GetListUser().ToList();
            }
            catch (Exception ex)
            {
                //traitement exception ...
                Debug.WriteLine(ex.Message);
            }
            return serviceListUser;
        }
    }
}
