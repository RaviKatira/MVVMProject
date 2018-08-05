using MVVMDemo;
using OPSMain.CustomerEntry;
using OPSMain.Email;
using OPSMain.OrderEntry;
using OPSMain.ProductEntry;
using OPSMain.SupplierEntry;
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
    /// Interaction logic for mainWindow.xaml
    /// </summary>
    public partial class mainWindow : Window
    {
        OrderEntryView orderEntryView;
        RePrintBill reprintBill;
        Inward inwardEntry;
        ProductMaster productMaster;
        CustomerMaster customerMaster;
        SupplierMaster supplierMaster;
        SendEmail sendEmail;
        public mainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
        }



        private void mnuOrderEntryScreen_Click(object sender, RoutedEventArgs e)
        {
            orderEntryView = OrderEntryView.Instance;
            //if (orderEntryView == null)
            //{

            orderEntryView.Show();
            //}

            orderEntryView.Focus();


        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CloseAllOpenInstance();

        }


        private void mnuRePrintBill_Click(object sender, RoutedEventArgs e)
        {

            reprintBill = RePrintBill.Instance;
            //if (orderEntryView == null)
            //{

            reprintBill.Show();
            //}

            reprintBill.Focus();
        }

        private void mnuInWardEntry_Click(object sender, RoutedEventArgs e)
        {
            inwardEntry = Inward.Instance;

            inwardEntry.Show();

            inwardEntry.Focus();



        }

        private void mnuProductMaster_Click(object sender, RoutedEventArgs e)
        {
            productMaster = ProductMaster.Instance;

            productMaster.Show();

            productMaster.Focus();
        }

        private void mnuCustomerMaster_Click(object sender, RoutedEventArgs e)
        {
            customerMaster = CustomerMaster.Instance;

            customerMaster.Show();

            customerMaster.Focus();


        }
        private void mnuEmailDailyReport_Click(object sender, RoutedEventArgs e)
        {
            sendEmail = SendEmail.Instance;

            sendEmail.Show();

            sendEmail.Focus();



        }

        private void mnuSupplierMaster_Click(object sender, RoutedEventArgs e)
        {
            supplierMaster = SupplierMaster.Instance;

            supplierMaster.Show();

            supplierMaster.Focus();

        }

        private void CloseAllOpenInstance()
        {
            if (orderEntryView != null)
                orderEntryView.Close();

            if (reprintBill != null)
                reprintBill.Close();

            if (inwardEntry != null)
                inwardEntry.Close();

            if (productMaster != null)
                productMaster.Close();

            if (customerMaster != null)
                customerMaster.Close();

            if (supplierMaster != null)
                supplierMaster.Close();

            if (sendEmail != null)
            {
                sendEmail.Close();
            }

        }

        private void MenuExitItem_Click(object sender, RoutedEventArgs e)
        {
            CloseAllOpenInstance();
            Application.Current.Shutdown();
        }
    }
}
