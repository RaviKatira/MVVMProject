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

namespace OPSMain.SupplierEntry
{
    /// <summary>
    /// Interaction logic for SupplierMaster.xaml
    /// </summary>
    public partial class SupplierMaster : Window
    {
        private static SupplierMaster instance = null;
        public static SupplierMaster Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SupplierMaster();
                }
                return instance;
            }
        }

        public SupplierMaster()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            instance = null;
        }
    }
}
