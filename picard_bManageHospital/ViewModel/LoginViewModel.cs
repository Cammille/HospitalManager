using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace picard_bManageHospital.ViewModel
{
    class LoginViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        private DataAccess.User _userData;

        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get { return _loginCommand; }
            set { _loginCommand = value; }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        public LoginViewModel()
        {
            Login = "";
            Password = "";
            _userData = new DataAccess.User();

            //commandes
            _loginCommand = new RelayCommand(param => LoginAccess(), param => true);
        }
        /// <summary>
        /// Authentification
        /// </summary>
        private void LoginAccess()
        {
            if (_userData.TestUser(Login, Password))
            {
                View.Connect window = new View.Connect();
                ViewModel.Connect vm = new Connect();
                window.DataContext = vm;
            }
        }
    }
}
