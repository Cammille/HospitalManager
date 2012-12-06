using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;

namespace picard_bManageHospital.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        #region variables

        private DataAccess.User _dataAccessUser;
        private bool _closeSignal;
        private string _login;
        private string _password;

        #endregion

        #region commands

        private ICommand _loginCommand;

        #endregion

        #region getter / setter

        /// <summary>
        /// mot de passe de la personne
        /// </summary>
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        /// <summary>
        /// login de la personne
        /// </summary>
        public string Login
        {
            get { return _login; }
            set
            {
                if (_login != value)
                {
                    _login = value;
                    OnPropertyChanged("Login");
                }

            }
        }

        /// <summary>
        /// indique si on doit fermer la fenêtre ou non
        /// </summary>
        public bool CloseSignal
        {
            get { return _closeSignal; }
            set
            {
                if (_closeSignal != value)
                {
                    _closeSignal = value;
                    OnPropertyChanged("CloseSignal");
                }
            }
        }

        /// <summary>
        /// command pour s'authentifier
        /// </summary>
        public ICommand LoginCommand
        {
            get { return _loginCommand; }
            set { _loginCommand = value; }
        }

        #endregion

        /// <summary>
        /// Constructeur
        /// </summary>
        public LoginViewModel()
        {
            _login = "";
            _password = "";
            _dataAccessUser = new DataAccess.User();

            LoginCommand = new RelayCommand(param => Connect(), param => true);
        }

        /// <summary>
        /// Authentification
        /// </summary>
        private void Connect()
        {
            if (_dataAccessUser.Connect(Login, Password))
            {
                View.HomeView window = new View.HomeView();
                ViewModel.HomeViewModel vm = new HomeViewModel();
                vm.User = _dataAccessUser.GetUser(Login);
                window.DataContext = vm;
                window.Show();
                CloseSignal = true;
            }
        }
    }
}
