using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;

namespace picard_bManageHospital.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        #region variables

        private DataAccess.User _dataAccessUser;
        private bool _closeSignal;
        private string _login;
        private string _message;

        #endregion

        #region commands

        private ICommand _loginCommand;

        #endregion

        #region getter / setter

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

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
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
            _dataAccessUser = new DataAccess.User();

            Login = "laura";
            Message = string.Empty;

            LoginCommand = new RelayCommand(Connect);
        }

        /// <summary>
        /// Authentification, ne respecte pas MVVM mais ne stocke pas le password en memoire
        /// </summary>
        private void Connect(object parameter)
        {
            var passwordBox = parameter as PasswordBox;

            if (_dataAccessUser.Connect(Login, passwordBox.Password))
            {
                View.HomeView window = new View.HomeView();
                ViewModel.HomeViewModel vm = new HomeViewModel();
                vm.User = _dataAccessUser.GetUser(Login);
                window.DataContext = vm;
                window.Show();
                CloseSignal = true;
            }
            else
            {
                Message = "Login/Mot de passe incorrect";
            }
        }
    }
}
