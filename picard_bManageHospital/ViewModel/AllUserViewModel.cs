using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace picard_bManageHospital.ViewModel
{
    class AllUserViewModel : BaseViewModel
    {
        #region variables

        private ObservableCollection<ServiceUser.User> _listUser = null;
        private DataAccess.User _dbUser = new DataAccess.User();

        #endregion

        #region getter / setter

        /// <summary>
        /// Liste des patients
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
