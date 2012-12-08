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
            try
            {
                return new ServiceUser.ServiceUserClient().Connect(login, pwd);
            }
            catch
            {
                return false;
            }
        }

        public ServiceUser.User GetUser(string login)
        {
            return new ServiceUser.ServiceUserClient().GetUser(login);
        }

        public bool AddUser(String Firstname, String Name, String Login, String Password, String Role)
        {
            try
            {
                ServiceUser.User user = new ServiceUser.User();
                user.Firstname = Firstname;
                user.Name = Name;
                user.Login = Login;
                user.Pwd = Password;
                user.Role = Role;
                if (new ServiceUser.ServiceUserClient().AddUser(user))
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                //traitement exception ...
                Debug.WriteLine(ex.Message);
                return false;
            }
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
