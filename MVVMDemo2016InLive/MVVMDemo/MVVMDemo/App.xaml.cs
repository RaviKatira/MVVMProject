using OPSMain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace MVVMDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                mainWindow mainWdw = new mainWindow();
                mainWdw.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured: " + ex.Message + " " + ex.Source + " " + ex.StackTrace);
            }

        }
    }
}
