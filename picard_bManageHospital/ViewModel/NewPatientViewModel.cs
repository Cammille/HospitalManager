using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace picard_bManageHospital.ViewModel
{
    class NewPatientViewModel : BaseViewModel
    {
        #region variables

        private DataAccess.Patient _dataAccessPatient;
        private string _firstname;
        private string _name;
        private DateTime _birthday;
        private string _status;

        #endregion

        #region commands

        private ICommand _addCommand;

        #endregion

        #region getter / setter

        /// <summary>
        /// prenom du patient
        /// </summary>
        public string Firstname
        {
            get { return _firstname; }
            set
            {
                if (_firstname != value)
                {
                    _firstname = value;
                    OnPropertyChanged("Firstname");
                }
            }
        }

        /// <summary>
        /// nom du patient
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }

            }
        }

        /// <summary>
        /// date de naissance du patient
        /// </summary>
        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                if (_birthday != value)
                {
                    _birthday = value;
                    OnPropertyChanged("Birthday");
                }

            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged("Status");
                }
            }
        }

        /// <summary>
        /// command pour ajouter un patient
        /// </summary>
        public ICommand AddCommand
        {
            get { return _addCommand; }
            set { _addCommand = value; }
        }

        #endregion

        /// <summary>
        /// Constructeur
        /// </summary>
        public NewPatientViewModel()
        {
            _firstname = "";
            _name = "";
            _birthday = DateTime.Now;
            _dataAccessPatient = new DataAccess.Patient();
            _status = "Hidden";
            AddCommand = new RelayCommand(param => Add(), param => true);
        }

        /// <summary>
        /// Ajout du patient
        /// </summary>
        private void Add()
        {
            if (_dataAccessPatient.AddPatient(Firstname, Name, Birthday))
            {
                Status = "Visible";
            }
        }
    }
}
