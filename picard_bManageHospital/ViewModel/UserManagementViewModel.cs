using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace picard_bManageHospital.ViewModel
{
    class UserManagementViewModel : BaseViewModel
    {

        #region variables

        private ViewModel.BaseViewModel _currentViewModel;
        private ServiceUser.User _user;
        
        #endregion

        #region getter / setter

        public ViewModel.BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    OnPropertyChanged("CurrentViewModel");
                }
            }
        }

        public ServiceUser.User User
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged("User");
                }
            }
        }

        #endregion

        #region commands

        public ICommand CreateUserCommand { get; set; }
        public ICommand AllUserCommand { get; set; }

        #endregion

        /// <summary>
        /// Constructeur
        /// </summary>
        public UserManagementViewModel()
        {
            // Set-up commands
            CreateUserCommand = new RelayCommand(param => CreateUser(), param => true);
            AllUserCommand = new RelayCommand(param => AllUser(), param => true);

            // Loading default viewmodel
            CurrentViewModel = new AllUserViewModel();
        }

        /// <summary>
        /// liste utilisateurs
        /// </summary>
        private void AllUser()
        {
            CurrentViewModel = new AllUserViewModel();
        }

        /// <summary>
        /// Gestion utilisateurs
        /// </summary>
        private void CreateUser()
        {
            CurrentViewModel = new CreateUserViewModel();
        }
    }
}
