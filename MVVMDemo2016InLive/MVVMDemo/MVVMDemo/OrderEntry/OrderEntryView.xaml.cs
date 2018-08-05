//using Microsoft.PointOfService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class OrderEntryView : Window
    {
        //private PosExplorer explorer;
        //private DeviceCollection scannerList;
        //private DeviceCollection scannerList1;
        //private Scanner activeScanner;

        bool mLeftCtrlDown = false;
        bool mScanShiftDown = false;
        bool mScanning = false;
        //StringBuilder mScanData = new StringBuilder();
        //KeyConverter mScanKeyConverter = new KeyConverter();
        private static OrderEntryView instance = null;
        public static OrderEntryView Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderEntryView();
                }
                return instance;
            }
        }
        public OrderEntryView()
        {
            InitializeComponent();
            //this.PreviewKeyDown += new KeyEventHandler(OrderEntryView_PreviewKeyDown);
            //this.PreviewKeyUp += new KeyEventHandler(OrderEntryView_PreviewKeyUp);


        }

        private void OrderEntryView_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl)
            {
                mLeftCtrlDown = false;
            }
            else if (mScanning)
            {
                // Handle all Keyups while scanning to preven other events from catching them
                e.Handled = true;
                if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
                {
                    // Note - We dont track shift keys separately. It is possible for us to get
                    // wrong data if the user were to press 2 shift keys and then let up only 1 but we only track
                    // this when scanning and a bar code scanner should be consistent.
                    mScanShiftDown = false;

                }
                if (e.Key == Key.Return)
                {
                    Debug.WriteLine("Up" + e.Key.ToString());
                    //txtBarCode.Focus();
                    // return;

                }
            }
        }

        private void OrderEntryView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl)
            {
                mLeftCtrlDown = false;
            }
            else if (mScanning)
            {
                // Handle all Keyups while scanning to preven other events from catching them
                e.Handled = true;
                if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
                {
                    // Note - We dont track shift keys separately. It is possible for us to get
                    // wrong data if the user were to press 2 shift keys and then let up only 1 but we only track
                    // this when scanning and a bar code scanner should be consistent.
                    mScanShiftDown = false;
                }
            }
            if (e.Key == Key.Return)
            {

                Debug.WriteLine("Down" + e.Key.ToString());
                //txtBarCode.Focus();
                // return;


            }
        }

        private void btnNewBill_Click(object sender, RoutedEventArgs e)
        {

            txtBarCode.Focus();
            txtBarCode.SelectAll();
        }



        private void txtBarCode_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBarCode.Text.Length > 0 && txtQty.Text == "0" && cmbProductName.SelectedIndex == -1)
            {
                var retvalue = Task.Run(() => ExecuteLongProc(this));
            }
        }

        private void ExecuteLongProc(OrderEntryView gui)
        {
            gui.UpdateWindow();

        }

        private void UpdateWindow()
        {
            Dispatcher.Invoke(() =>
            {
                txtBarCode.Focus();
            });
        }




        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            txtBarCode.Focus();
            txtBarCode.SelectAll();
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


        private void txtCashTendered_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            txtCashTendered.SelectAll();
        }

        private void txtCashTendered_GotMouseCapture(object sender, MouseEventArgs e)
        {
            txtCashTendered.SelectAll();
        }

        private void txtDiscount_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            txtDiscount.SelectAll();
        }

        private void txtDiscount_GotMouseCapture(object sender, MouseEventArgs e)
        {
            txtDiscount.SelectAll();
        }
    }
}
