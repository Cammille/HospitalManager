using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace picard_bManageHospital
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            View.LoginView window = new View.LoginView();

            ViewModel.LoginViewModel vm = new ViewModel.LoginViewModel();
            window.DataContext = vm;

            window.Show();
        }
    }
}
