using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;

namespace picard_bManageHospital.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public string Login { get; set; }
        public string Password { get; set; }
        private DataAccess.User _userData;
        public ICommand LoginCommand { get; set; }
        private bool _closeSignal;
        public event PropertyChangedEventHandler PropertyChanged;

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

        private void OnPropertyChanged(string property)
        {

            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(property);
                handler(this, e);
            }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        public LoginViewModel()
        {
            Login = "";
            Password = "";
            _userData = new DataAccess.User();

            LoginCommand = new RelayCommand(param => Connect(), param => true);
        }
        /// <summary>
        /// Authentification
        /// </summary>
        private void Connect()
        {
            if (_userData.Connect(Login, Password))
            {
                View.AllPersonView window = new View.AllPersonView();
                ViewModel.AllPersonView vm = new AllPersonView();
                window.DataContext = vm;
                window.Show();
                CloseSignal = true;
            }
        }
    }
}
