using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OPSMain.CustomerEntry
{
    /// <summary>
    /// Interaction logic for CustomerMaster.xaml
    /// </summary>
    public partial class CustomerMaster : Window
    {
        private static CustomerMaster instance = null;
        public static CustomerMaster Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerMaster();
                }
                return instance;
            }
        }
        public CustomerMaster()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            instance = null;
        }
    }
}
