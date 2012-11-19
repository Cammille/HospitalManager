using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace picard_bManageHospital.Model
{
    class User
    {
        #region getter/setter
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Login { get; set; }
        public bool Connected { get; set; }
        public string Pwd { get; set; }
        public string Role { get; set; }
        #endregion

        public User()
        {
            
        }
    }
}
