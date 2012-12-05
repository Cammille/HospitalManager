using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace picard_bManageHospital.ViewModel
{
    class AllPatientViewModel : BaseViewModel
    {
        #region variables

        private ObservableCollection<Model.Patient> _listPatient = null;
        private DataAccess.Patient _dbPatient = new DataAccess.Patient();

        #endregion

        #region getter / setter

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

        #endregion

        /// <summary>
        /// Constructeur
        /// </summary>
        public AllPatientViewModel()
        {
            FillListPatient();
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
