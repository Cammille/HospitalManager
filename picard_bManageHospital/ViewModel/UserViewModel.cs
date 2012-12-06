using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace picard_bManageHospital.ViewModel
{
    class UserViewModel : BaseViewModel
    {

        private bool _closeSignal;
        private ServiceUser.User _user;

        /// <summary>
        /// indique si on doit fermer la fenêtre ou non
        /// </summary>
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
        /// utilisateur courant
        /// </summary>
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

        public UserViewModel(ServiceUser.User user)
        {
            User = user;
        }
    }
}
