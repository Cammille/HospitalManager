using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading;
using System.Windows;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using System.Windows.Threading;
using System.ServiceModel;

namespace picard_bManageHospital.ViewModel
{
    class HomeViewModel : BaseViewModel
    {

        #region variables

        private bool _closeSignal;
        private ViewModel.BaseViewModel _currentViewModel;
        private ServiceUser.User _user;

        public ObservableDataSource<Point> SourceTemp { get; set; }
        public ObservableDataSource<Point> SourceHeart { get; set; }
        
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

        public ICommand UserProfileCommand { get; set; }
        public ICommand DisconnectCommand { get; set; }
        public ICommand AllPatientCommand { get; set; }
        public ICommand AllUserCommand { get; set; }

        #endregion

        /// <summary>
        /// Constructeur
        /// </summary>
        public HomeViewModel()
        {
            // Set-up commands
            DisconnectCommand = new RelayCommand(param => Disconnect(), param => true);
            UserProfileCommand = new RelayCommand(param => UserProfile(), param => true);
            AllPatientCommand = new RelayCommand(param => AllPatient(), param => true);
            AllUserCommand = new RelayCommand(param => AllUser(), param => true);

            // Loading default viewmodel
            CurrentViewModel = new PatientManagementViewModel();

            SourceTemp = new ObservableDataSource<Point>();
            SourceTemp.SetXYMapping(p => p);

            SourceHeart = new ObservableDataSource<Point>();
            SourceHeart.SetXYMapping(p => p);

            /*
            ServiceLive.ServiceLiveClient serviceClient = new ServiceLive.ServiceLiveClient();
            serviceClient.Subscribe();
             */
        }

        /// <summary>
        /// Deconnexion
        /// </summary>
        private void Disconnect()
        {
            View.LoginView window = new View.LoginView();
            ViewModel.LoginViewModel vm = new LoginViewModel();
            window.DataContext = vm;
            window.Show();
            CloseSignal = true;
        }

        /// <summary>
        /// Ouverture du profil
        /// </summary>
        private void UserProfile()
        {
            CurrentViewModel = new UserManagementViewModel(User);
        }

        /// <summary>
        /// Gestion patients
        /// </summary>
        private void AllPatient()
        {
            CurrentViewModel = new PatientManagementViewModel();
        }

        /// <summary>
        /// Gestion utilisateurs
        /// </summary>
        private void AllUser()
        {
            CurrentViewModel = new UserManagementViewModel();
        }

        /*
            internal void PushDataHeart(double d)
            {

            }
        */
    }
}
