using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace picard_bManageHospital.ViewModel
{
    class AllPatientView : INotifyPropertyChanged
    {
        public ICommand DeconnexionCommand { get; set; }
        private bool _closeSignal;
        private ObservableCollection<Model.Patient> _listPatient = null;
        public event PropertyChangedEventHandler PropertyChanged;
        private DataAccess.Patient _dbPatient = new DataAccess.Patient();

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
        /// Liste des patients
        /// </summary>
        public ObservableCollection<Model.Patient> ListPatient
        {
            get { return _listPatient; }
            set
            {

                if (_listPatient != value)
                {
                    _listPatient = value;
                    OnPropertyChanged("ListPatient");
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
        public AllPatientView()
        {
            FillListPatient();

            DeconnexionCommand = new RelayCommand(param => Deconnexion(), param => true);
        }
        /// <summary>
        /// Deconnexion
        /// </summary>
        private void Deconnexion()
        {
            View.LoginView window = new View.LoginView();
            ViewModel.LoginViewModel vm = new LoginViewModel();
            window.DataContext = vm;
            window.Show();
            CloseSignal = true;
        }
        
        /// <summary>
        /// Fill patient list
        /// </summary>
        private void FillListPatient()
        {
            List<Model.Patient> tmpList = _dbPatient.GetListPatient();

            //transformation en Observable collection pour l'interface
            ListPatient = new ObservableCollection<Model.Patient>(tmpList);

        }
    }
}
