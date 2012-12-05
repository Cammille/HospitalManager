using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace picard_bManageHospital.ViewModel
{
    class HomeViewModel : BaseViewModel
    {

        #region variables

        public ICommand DisconnectCommand { get; set; }
        private bool _closeSignal;
        private ViewModel.AllPatientViewModel _allPatientVM;

        #endregion

        #region getter / setter

        public ViewModel.AllPatientViewModel AllPatientVM
        {
            get { return _allPatientVM; }
            set
            {
                if (_allPatientVM != value)
                {
                    _allPatientVM = value;
                    OnPropertyChanged("AllPatientVM");
                }
            }
        }

        #endregion

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
        /// Constructeur
        /// </summary>
        public HomeViewModel()
        {
            DisconnectCommand = new RelayCommand(param => Disconnect(), param => true);

            AllPatientVM = new AllPatientViewModel();
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
    }
}
