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

namespace OPSMain
{
    /// <summary>
    /// Interaction logic for Inward.xaml
    /// </summary>
    public partial class Inward : Window
    {
        public Inward()
        {
            InitializeComponent();
        }

        private static Inward instance = null;
        public static Inward Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Inward();
                }
                return instance;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            instance = null;
        }

        private void txtQty_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            txtQty.SelectAll();
        }

        private void txtQty_GotMouseCapture(object sender, MouseEventArgs e)
        {
            txtQty.SelectAll();
        }
    }
}
