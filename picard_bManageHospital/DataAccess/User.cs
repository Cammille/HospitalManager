using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace picard_bManageHospital.DataAccess
{
    class User
    {
        private ServiceUser.User[] _listUser = null;

        public User()
        {
            // Load client list
            _listUser = new ServiceUser.ServiceUserClient().GetListUser();
        }

        public bool TestUser(string name, string pwd)
        {
            return _listUser.Where(x => x.Name == name && x.Pwd == pwd).Any();
        }
    }
}
