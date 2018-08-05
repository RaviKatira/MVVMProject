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

namespace OPSMain.OrderEntry
{
    /// <summary>
    /// Interaction logic for RePrintBill.xaml
    /// </summary>
    public partial class RePrintBill : Window
    {
        public RePrintBill()
        {
            InitializeComponent();
        }
        private static RePrintBill instance = null;
        public static RePrintBill Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RePrintBill();
                }
                return instance;
            }
        }
       

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            instance = null;
        }

        private void txtRePrintBillNo_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            txtRePrintBillNo.SelectAll();
        }

        private void txtRePrintBillNo_GotMouseCapture(object sender, MouseEventArgs e)
        {
            txtRePrintBillNo.SelectAll();
        }
    }
}
