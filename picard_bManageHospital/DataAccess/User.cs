using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace picard_bManageHospital.DataAccess
{
    class User
    {
        public User()
        {
           
        }

        public bool Connect(string name, string pwd)
        {
            return new ServiceUser.ServiceUserClient().Connect(name, pwd);
        }
    }
}
