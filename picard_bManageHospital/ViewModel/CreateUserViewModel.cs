using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows.Controls;

namespace picard_bManageHospital.ViewModel
{
    class CreateUserViewModel : BaseViewModel
    {
        #region variables

        private DataAccess.User _dataAccessUser;
        private string _firstname;
        private string _name;
        private string _login;
        private string _password;
        private string _selectedRole;
        private string _status;

        #endregion

        #region commands

        private ICommand _addCommand;

        #endregion

        #region getter / setter

        /// <summary>
        /// prenom du user
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
        /// nom du user
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
        /// login du user
        /// </summary>
        public string Login
        {
            get { return _login; }
            set
            {
                if (_login != value)
                {
                    _login = value;
                    OnPropertyChanged("Login");
                }

            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public string SelectedRole
        {
            get { return _selectedRole; }
            set
            {
                if (_selectedRole != value)
                {
                    _selectedRole = value;
                    OnPropertyChanged("SelectedRole");
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
        /// command pour ajouter un user
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
        public CreateUserViewModel()
        {
            _firstname = "";
            _name = "";
            _login = "";
            _password = "";
            _selectedRole = "";
            _dataAccessUser = new DataAccess.User();
            _status = "Hidden";
            AddCommand = new RelayCommand(Add);
        }

        /// <summary>
        /// Ajout du user
        /// </summary>
        private void Add(object parameter)
        {
            var txtPwd = parameter as PasswordBox;

            if (SelectedRole == "0")
                SelectedRole = "Medecin";
            else if (SelectedRole == "1")
                SelectedRole = "Chirurgien";
            else if (SelectedRole == "2")
                SelectedRole = "Infirmière";
            else if (SelectedRole == "3")
                SelectedRole = "Radiologue";

            if (_dataAccessUser.AddUser(Firstname, Name, Login, txtPwd.Password, SelectedRole))
            {
                Status = "Visible";
            }
        }
    }
}
