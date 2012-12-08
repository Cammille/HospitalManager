using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace picard_bManageHospital.ViewModel
{
    class PatientManagementViewModel : BaseViewModel
    {
         #region variables

        private ViewModel.BaseViewModel _currentViewModel;
        private ServicePatient.Patient _patient;
        
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

        public ServicePatient.Patient Patient
        {
            get { return _patient; }
            set
            {
                if (_patient != value)
                {
                    _patient = value;
                    OnPropertyChanged("Patient");
                }
            }
        }

        #endregion

        #region commands

        public ICommand CreatePatientCommand { get; set; }
        public ICommand AllPatientCommand { get; set; }

        #endregion

        /// <summary>
        /// Constructeur
        /// </summary>
        public PatientManagementViewModel()
        {
            // Set-up commands
            CreatePatientCommand = new RelayCommand(param => CreatePatient(), param => true);
            AllPatientCommand = new RelayCommand(param => AllPatient(), param => true);

            // Loading default viewmodel
            CurrentViewModel = new AllPatientViewModel();
        }

        /// <summary>
        /// liste patients
        /// </summary>
        private void AllPatient()
        {
            CurrentViewModel = new AllPatientViewModel();
        }

        /// <summary>
        /// Gestion patients
        /// </summary>
        private void CreatePatient()
        {
            CurrentViewModel = new NewPatientViewModel();
        }
    }
}
