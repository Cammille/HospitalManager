﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace picard_bManageHospital.ViewModel
{
    class AllPatientViewModel : BaseViewModel
    {
        #region variables

        private ObservableCollection<ServicePatient.Patient> _listPatient = null;
        private DataAccess.Patient _dbPatient = new DataAccess.Patient();
        private ViewModel.BaseViewModel _currentViewModel;

        #endregion

        #region getter / setter

        /// <summary>
        /// Liste des patients
        /// </summary>
        public ObservableCollection<ServicePatient.Patient> ListPatient
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

        #endregion

        #region commands

        private ICommand _addCommand;
        private ICommand _deleteCommand;

        #endregion

        /// <summary>
        /// Constructeur
        /// </summary>
        public AllPatientViewModel()
        {
            FillListPatient();
            AddCommand = new RelayCommand(param => Add(), param => true);
            DeleteCommand = new RelayCommand(Delete);
        }

        /// <summary>
        /// Fill patient list
        /// </summary>
        private void FillListPatient()
        {
            // Transformation en Observable collection pour l'interface
            ListPatient = new ObservableCollection<ServicePatient.Patient>(_dbPatient.GetListPatient());
        }

        /// <summary>
        /// command pour ajouter un patient
        /// </summary>
        public ICommand AddCommand
        {
            get { return _addCommand; }
            set { _addCommand = value; }
        }

        /// <summary>
        /// command pour suppriemr un patient
        /// </summary>
        public ICommand DeleteCommand
        {
            get { return _deleteCommand; }
            set { _deleteCommand = value; }
        }

        private void Add()
        {
            CurrentViewModel = new NewPatientViewModel();
        }

        /// <summary>
        /// Supprimer un patient
        /// </summary>
        private void Delete(object parameter)
        {
            var dataGrd = parameter as DataGrid;
            ServicePatient.Patient p = _listPatient.ElementAt(dataGrd.SelectedIndex);
            _dbPatient.DeletePatient(p.Id);
        }
    }
}
