using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Controls;

namespace picard_bManageHospital.ViewModel
{
    class AllUserViewModel : BaseViewModel
    {
        #region variables

        private ObservableCollection<ServiceUser.User> _listUser = null;
        private ServiceUser.User _selectedUser = null;
        private DataAccess.User _dbUser = new DataAccess.User();

        #endregion

        #region getter / setter

        /// <summary>
        /// Liste des utilisateurs
        /// </summary>
        public ObservableCollection<ServiceUser.User> ListUser
        {
            get { return _listUser; }
            set
            {

                if (_listUser != value)
                {
                    _listUser = value;
                    OnPropertyChanged("ListUser");
                }
            }
        }

        /// <summary>
        /// Utilisateur selectionne
        /// </summary>
        public ServiceUser.User SelectedUser
        {
            get { return _selectedUser; }
            set
            {

                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    OnPropertyChanged("SelectedUser");
                }
            }
        }

        #endregion

        /// <summary>
        /// Constructeur
        /// </summary>
        public AllUserViewModel()
        {
            FillListUser();
        }

        /// <summary>
        /// Fill patient list
        /// </summary>
        private void FillListUser()
        {
            // Transformation en Observable collection pour l'interface
            ListUser = new ObservableCollection<ServiceUser.User>(_dbUser.GetListUser());
        }
    }
}
