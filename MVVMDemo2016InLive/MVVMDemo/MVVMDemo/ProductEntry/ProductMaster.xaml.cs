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

namespace OPSMain.ProductEntry
{
    /// <summary>
    /// Interaction logic for ProductMaster.xaml
    /// </summary>
    public partial class ProductMaster : Window
    {
        public ProductMaster()
        {
            InitializeComponent();
        }
        private static ProductMaster instance = null;
        public static ProductMaster Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductMaster();
                }
                return instance;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            instance = null;
        }
        private void txtMRP_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            txtMRP.SelectAll();
        }

        private void txtMRP_GotMouseCapture(object sender, MouseEventArgs e)
        {
            txtMRP.SelectAll();
        }

        private void txtSellingPrice_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            txtSellingPrice.SelectAll();
        }

        private void txtSellingPrice_GotMouseCapture(object sender, MouseEventArgs e)
        {
            txtSellingPrice.SelectAll();
        }

        private void txtCostPrice_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            txtCostPrice.SelectAll();
        }

        private void txtCostPrice_GotMouseCapture(object sender, MouseEventArgs e)
        {
            txtCostPrice.SelectAll();
        }
    }


}
