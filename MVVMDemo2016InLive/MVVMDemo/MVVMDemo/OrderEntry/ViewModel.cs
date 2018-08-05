using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Collections.Specialized;
using Repository;
using Entity;
using OPSSystem.Common;
using OPSSystem.Command;
using System.Windows.Documents;
using System.Windows.Media;
using System.Diagnostics;
using System.Windows.Shapes;
using Common;
using System.Net;
using System.Net.Mail;

namespace MVVMDemo
{
    public class ViewModel : ViewModelBase
    {

        private bool isBarCodeFocused;

        public bool IsBarCodeFocused
        {
            get
            { return isBarCodeFocused; }
            set
            {
                isBarCodeFocused = value;
                NotifyPropertyChanged("IsBarCodeFocused");
            }
        }


        private Customer _customer;

        private OrderSummary _orderSummary;
        private Product _product;
        private ObservableCollection<Product> _products;

        private ObservableCollection<PaymentMode> _paymentModes;
        private PaymentMode _selectedPaymentMode;

        private OrderSummary _reprintorder;

        private Order _order;
        private ObservableCollection<Order> _orders;
        private ICommand _reprintBillCommand;
        private ICommand _SubmitCommand;
        private ICommand _AddCommand;
        private ICommand _DelCommand;
        private ICommand _ResetCommand;
        private ICommand _searchBarCodeCommand;
        private ICommand _SaveBillCommand;
        private ICommand _SaveBillOnlyCommand;
        private ICommand _NewBillCommand;
        //Customer 
        private ICommand _searchCustomerByCustIdCommand;
        private ICommand _searchCustomerByPhoneCommand;
        private ICommand _searchCustomerByBarCodeCommand;

        public ICommand ReprintBillCommand
        {
            get
            {
                if (_reprintBillCommand == null)
                {
                    _reprintBillCommand = new RelayCommand(param => this.ReprintBill(),
                        null);
                }
                return _reprintBillCommand;
            }
        }

        private void ReprintBill()
        {

            MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure you want to Print Bill ?", "Warning Message", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                Utility.PrintBill(ReprintOrder.BillNo);
            }



        }

        public void PopulateOrder()
        {
            OrderRepository orderRepository = new OrderRepository();
            //orderRepository.Process();

        }
        public Order Order
        {
            get
            {
                return _order;
            }
            set
            {
                _order = value;
                if (_order != null && Products != null)
                {
                    Product = Products.Where(p => p.BarCodeId == Order.BarCodeId).SingleOrDefault();
                    Order.BillAmount = Orders.Sum(x => x.Total);
                    OrderSummary.BillAmount = Orders.Sum(x => x.Total);
                    OrderSummary.TotalQty = Orders.Sum(x => x.Quantity);
                    OrderSummary.TotalCostPrice = Orders.Sum(x => x.CostPrice);
                    OrderSummary.TotalProfit = Orders.Sum(x => x.Profit);
                }
                NotifyPropertyChanged("Order");
                NotifyPropertyChanged("OrderSummary");
            }
        }

        public ObservableCollection<PaymentMode> PaymentModes
        {
            get
            {
                return _paymentModes;
            }
            set
            {
                _paymentModes = value;

                NotifyPropertyChanged("PaymentModes");
            }
        }


        public PaymentMode SelectedPaymentMode
        {
            get
            {
                return _selectedPaymentMode;
            }
            set
            {
                _selectedPaymentMode = value;
                if (value != null)
                {
                    OrderSummary.PaymentModeId = _selectedPaymentMode.PaymentModeId;
                }
                NotifyPropertyChanged("SelectedPaymentMode");
                NotifyPropertyChanged("OrderSummary");
            }
        }
        public Product Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
                if (value != null)
                {

                    Order.Price = _product.ProductPrice;
                    Order.MRP = _product.MRP;
                    Order.CostPrice = _product.CPWithVAT;
                    Order.Profit = OrderSummary.DiscountAuto ? _product.ProfitOnMRP : _product.Profit;
                    Order.ProductId = _product.ProductId;
                    Order.ProductName = _product.ProductName;
                    Order.BarCodeId = _product.BarCodeId;
                }
                NotifyPropertyChanged("Product");
            }
        }

        public OrderSummary OrderSummary
        {
            get
            {
                return _orderSummary;
            }
            set
            {
                _orderSummary = value;
                if (value != null)
                {
                    //Order.Price = _product.ProductPrice;
                    //Order.ProductId = _product.ProductId;
                    //Order.ProductName = _product.ProductName;
                    //Order.BarCodeId = _product.BarCodeId;
                }
                NotifyPropertyChanged("OrderSummary");
            }
        }
        public ObservableCollection<Product> Products
        {
            get
            {
                return _products;
            }
            set
            {


                _products = value;

                NotifyPropertyChanged("Products");
            }
        }
        public ObservableCollection<Order> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                _orders = value;
                if (Orders.Count > 0)
                {
                    Order.BillAmount = Orders.Sum(x => x.Total);
                    _orderSummary.BillAmount = Orders.Sum(x => x.Total);
                    OrderSummary.TotalQty = Orders.Sum(x => x.Quantity);
                    OrderSummary.TotalCostPrice = Orders.Sum(x => x.CostPrice);
                    OrderSummary.TotalProfit = Orders.Sum(x => x.Profit);
                }
                NotifyPropertyChanged("Orders");
                NotifyPropertyChanged("OrderSummary");
            }
        }

        public ICommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new RelayCommand(param => this.Submit(),
                        null);
                }
                return _SubmitCommand;
            }
        }

        //Save and Print Bill
        public ICommand SaveBillCommand
        {
            get
            {
                if (_SaveBillCommand == null)
                {
                    _SaveBillCommand = new RelayCommand(param => this.SaveBill(),
                        null);
                }
                return _SaveBillCommand;
            }
        }

        public ICommand NewBillCommand
        {
            get
            {
                if (_NewBillCommand == null)
                {
                    _NewBillCommand = new RelayCommand(param => this.NewBill(),
                        null);
                }
                return _NewBillCommand;
            }
        }

        private void NewBill()
        {
            try
            {


                if (Orders.Count > 0 && OrderSummary.BillNo == 0)
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure you want to create New Bill?", "Warning Message", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.No);
                    if (result == MessageBoxResult.No || result == MessageBoxResult.Cancel)
                    {
                        return;
                    }
                }
                Orders.Clear();
                SelectedPaymentMode = null;
                SelectedPaymentMode = new PaymentMode();
                SelectedPaymentMode = PaymentModes.Where(x => x.PaymentModeId == 1).FirstOrDefault();

                NotifyPropertyChanged("SelectedPaymentMode");
                OrderSummary.Clear();
                Customer.Clear();
                Add();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured: " + ex.Message + " " + ex.Source + " " + ex.StackTrace);
            }
        }
        //Save and Print Bill
        private void SaveBill()
        {
            try
            {
                if (Orders.Count == 0 || Orders == null)
                {
                    System.Windows.MessageBox.Show("No records available to save!", "OPS System", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                if (Orders.Count > 0) Reset();

                if (OrderSummary.BillNo > 0)
                {
                    System.Windows.MessageBox.Show("Bill already generated, to generate fresh bill click on New Bill button", "OPS System", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;

                }
                //var result = printDlg.ShowDialog();
                //if (result.HasValue && result.Value)
                //{
                //    var queue = printDlg.PrintQueue;

                //    // Contains extents and offsets
                //    var area = queue.GetPrintCapabilities(printDlg.PrintTicket)
                //                    .PageImageableArea;

                //    // scale = area.ExtentWidth and area.ExtentHeight and your UIElement's bounds
                //    // margin = area.OriginWidth and area.OriginHeight
                //    // 1. Use the scale in your ScaleTransform
                //    // 2. Use the margin and extent information to Measure and Arrange
                //    // 3. Print the visual
                //}
                MessageBoxResult result;
                if (OrderSummary.IsBillReturn)
                {
                    result = System.Windows.MessageBox.Show("Return Bill?", "Return - Warning Message", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.No);
                }
                else
                {
                    result = System.Windows.MessageBox.Show("Generate Final Bill?", "Bill Generate - Warning Message", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.No);
                }
                if (result == MessageBoxResult.No || result == MessageBoxResult.Cancel) return;

                if (result == MessageBoxResult.Yes)
                {
                    OrderRepository orderRepository = new OrderRepository();
                    Int64 BillNo = orderRepository.saveBill(Orders, OrderSummary);

                    //foreach (var ord in Orders)
                    //{
                    OrderSummary.BillNo = BillNo;
                    try
                    {
                        if (OrderSummary.BillAmount > 1000)
                        {
                            Utility.SendMail(OrderSummary);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Unable to send mail!");

                    }
                    //Products = new ObservableCollection<Product>(orderRepository.getProductList());
                    //}
                    //NotifyPropertyChanged("Order");
                    NotifyPropertyChanged("OrderSummary");
                    Reset();
                }
                //Utility.PrintBill(Orders, OrderSummary);
                Utility.PrintBill(OrderSummary.BillNo);


                //Graphics graphic = e.Graphics;
                //Font regularFont = new Font("Courier New", 8);
                //Font titleFont = new Font("Courier New", 14);
                //SolidBrush drawBrush = new SolidBrush(Color.Black);
                //float fontHeight = regularFont.GetHeight();
                //float startX = 10.0F;
                //float startY = 5.0F;
                //int offset = 40;
                //graphic.DrawString("----------------------------------------", regularFont, drawBrush, new PointF(startX, startY + offset), StringFormat.GenericTypographic);
                //offset = offset + (int)fontHeight + 5;
                //string header = "Item Name".PadRight(30) + "Price";
                //graphic.DrawString(header, regularFont, drawBrush, , new PointF(startX, startY + offset), StringFormat.GenericTypographic);
                //offset = offset + (int)fontHeight;
                //graphic.DrawString("----------------------------------------", regularFont, drawBrush, new PointF(startX, startY + offset), StringFormat.GenericTypographic);
                // Create a PrintDialog


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured: " + ex.Message + " " + ex.Source + " " + ex.StackTrace);
            }
        }



        private void SaveBill1()
        {
            //MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure you want to generate final bill?", "Warning Message", MessageBoxButton.YesNoCancel,MessageBoxImage.Question,MessageBoxResult.No);
            //if (result == MessageBoxResult.Yes)
            //{
            //    OrderRepository orderRepository = new OrderRepository();
            //    Int64 BillNo = orderRepository.saveBill(Orders);
            //    foreach (var ord in Orders)
            //    {
            //        ord.BillNo = BillNo;
            //    }
            //    NotifyPropertyChanged("Order");
            //    Reset();
            //}
            //Graphics graphic = e.Graphics;
            //Font regularFont = new Font("Courier New", 8);
            //Font titleFont = new Font("Courier New", 14);
            //SolidBrush drawBrush = new SolidBrush(Color.Black);
            //float fontHeight = regularFont.GetHeight();
            //float startX = 10.0F;
            //float startY = 5.0F;
            //int offset = 40;
            //graphic.DrawString("----------------------------------------", regularFont, drawBrush, new PointF(startX, startY + offset), StringFormat.GenericTypographic);
            //offset = offset + (int)fontHeight + 5;
            //string header = "Item Name".PadRight(30) + "Price";
            //graphic.DrawString(header, regularFont, drawBrush, , new PointF(startX, startY + offset), StringFormat.GenericTypographic);
            //offset = offset + (int)fontHeight;
            //graphic.DrawString("----------------------------------------", regularFont, drawBrush, new PointF(startX, startY + offset), StringFormat.GenericTypographic);
            // Create a PrintDialog
            PrintDialog printDlg = new PrintDialog();

            // Create a FlowDocument dynamically.
            String str;

            str = "Shree Dashama Stores";
            Section sec = new Section();

            Paragraph para = new Paragraph(new Run(str));
            para.TextAlignment = TextAlignment.Center;

            FlowDocument doc = new FlowDocument(para);
            Table table = new Table();

            doc.Blocks.Add(table);
            table.CellSpacing = 10;
            table.Background = Brushes.White;
            int numberOfColumns = 6;
            for (int x = 0; x < numberOfColumns; x++)
            {
                table.Columns.Add(new TableColumn());

                // Set alternating background colors for the middle colums.
                if (x % 2 == 0)
                    table.Columns[x].Background = Brushes.Beige;
                else
                    table.Columns[x].Background = Brushes.LightSteelBlue;
            }
            table.RowGroups.Add(new TableRowGroup());

            // Add the first (title) row.
            table.RowGroups[0].Rows.Add(new TableRow());

            // Alias the current working row for easy reference.
            TableRow currentRow = table.RowGroups[0].Rows[0];

            // Global formatting for the title row.
            currentRow.Background = Brushes.Silver;
            currentRow.FontSize = 40;
            currentRow.FontWeight = System.Windows.FontWeights.Bold;

            // Add the header row with content, 
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("2004 Sales Project"))));
            // and set the row to span all 6 columns.
            currentRow.Cells[0].ColumnSpan = 6;


            // Add the second (header) row.
            table.RowGroups[0].Rows.Add(new TableRow());
            currentRow = table.RowGroups[0].Rows[1];

            // Global formatting for the header row.
            currentRow.FontSize = 18;
            currentRow.FontWeight = FontWeights.Bold;

            // Add cells with content to the second row.
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Product"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Quarter 1"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Quarter 2"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Quarter 3"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Quarter 4"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("TOTAL"))));

            // Add the third row.
            table.RowGroups[0].Rows.Add(new TableRow());
            currentRow = table.RowGroups[0].Rows[2];

            // Global formatting for the row.
            currentRow.FontSize = 12;
            currentRow.FontWeight = FontWeights.Normal;

            // Add cells with content to the third row.
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Widgets"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$50,000"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$55,000"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$60,000"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$65,000"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$230,000"))));

            // Bold the first cell.
            currentRow.Cells[0].FontWeight = FontWeights.Bold;

            table.RowGroups[0].Rows.Add(new TableRow());
            currentRow = table.RowGroups[0].Rows[3];

            // Global formatting for the footer row.
            currentRow.Background = Brushes.LightGray;
            currentRow.FontSize = 18;
            currentRow.FontWeight = System.Windows.FontWeights.Normal;

            // Add the header row with content, 
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Projected 2004 Revenue: $810,000"))));
            // and set the row to span all 6 columns.
            currentRow.Cells[0].ColumnSpan = 6;

            //doc.FontSize = 10;
            //doc.FontFamily = new FontFamily("Fixedsys"); 
            //doc.PageHeight = printDlg.PrintableAreaHeight;
            //doc.PageWidth = printDlg.PrintableAreaWidth;
            //doc.FontStretch = FontStretches.UltraExpanded;
            //doc.LineHeight=1;
            //doc.PagePadding = new Thickness(20.0, 20.0, 20.0, 20.0);
            //doc.IsOptimalParagraphEnabled = true;
            //doc.IsHyphenationEnabled = true;
            //doc.IsColumnWidthFlexible = true;

            ////doc.Blocks.Add(new Paragraph(new LineBreak()));
            //str = "---- Cash Memo ----";
            //doc.Blocks.Add(new Paragraph(new Run(str)));

            //str = "Product Name".PadRight(50 - "Product Name".Length);
            //str += "Qty@Price".PadLeft(15);
            //str += "Total".PadLeft(10);
            //Debug.WriteLine(str);

            //doc.Blocks.Add(new Paragraph(new Run(str)));
            ////doc.Blocks.Add(new Paragraph(new LineBreak()));
            //string strcon;
            //foreach(var ord in Orders)
            //{
            //    strcon = ord.ProductName.ToString().PadRight(50- ord.ProductName.ToString().Length);
            //    //strcon += new string(' ', 8);
            //    //strcon += new string(' ', 8);
            //    strcon += (ord.Quantity.ToString() +'@' + ord.Price.ToString()).PadLeft(15);
            //    //strcon += new string(' ', 8);
            //    strcon += ord.Total.ToString().PadLeft(10);
            //    Debug.WriteLine(strcon);
            //    doc.Blocks.Add(new Paragraph(new Run(strcon)));
            //}

            doc.Name = "FlowDoc";

            // Create IDocumentPaginatorSource from FlowDocument
            IDocumentPaginatorSource idpSource = doc;
            // Call PrintDocument method to send document to printer
            printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");

        }

        public ICommand SearchBarCodeCommand
        {
            get
            {
                if (_searchBarCodeCommand == null)
                {
                    _searchBarCodeCommand = new RelayCommand(param => this.SearchProductbyBarCode(),
                        null);
                }
                return _searchBarCodeCommand;
            }
        }
        private void SearchCustomerbyBarCode()
        {

            try
            {
                OrderRepository orderRepository = new OrderRepository();
                Customer cust = orderRepository.SearchCustomerByCustomerBarCode(Customer.Customer_barcode);
                if (cust != null)
                {
                    Customer = cust;
                    OrderSummary.AvailableLoyaltyPoints = Customer.LeftRewardsPoints;
                    OrderSummary.CustomerId = Customer.CustID;
                }


            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void SearchProductbyBarCode()
        {

            try
            {

                if (Order == null)
                    Order = new Order();
                IsBarCodeFocused = false;
                NotifyPropertyChanged("IsBarCodeFocused");

                if (Order.BarCodeId == null) return;
                if (Order.BarCodeId.Length == 0) return;

                if (Order.Quantity != 0 && Order.ProductId != 0) return;

                Product = Products.FirstOrDefault(p => p.BarCodeId == Order.BarCodeId);
                if (Product != null)
                {
                    Order.BarCodeId = Product.BarCodeId;
                    Order.MRP = Product.MRP;
                    Order.Price = Product.ProductPrice;
                    Order.CostPrice = Product.CPWithVAT;
                    Order.Profit = OrderSummary.DiscountAuto ? Product.ProfitOnMRP : Product.Profit;
                    Order.Quantity = 1.0;
                    Order.ProductName = Product.ProductName;
                    Order.ProductId = Product.ProductId;
                    NotifyPropertyChanged("Order");
                    bool retValue = Submit();
                    if (retValue)
                    {
                        IsBarCodeFocused = true;
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Invalid Barcode!");

                    IsBarCodeFocused = false;
                    NotifyPropertyChanged("IsBarCodeFocused");
                }

            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new RelayCommand(param => this.Add(),
                        null);
                }
                return _AddCommand;
            }
        }

        public ICommand DelCommand
        {
            get
            {
                if (_DelCommand == null)
                {
                    _DelCommand = new RelayCommand(param => this.Delete(),
                        null);
                }
                return _DelCommand;
            }
        }


        public ICommand ResetCommand
        {
            get
            {
                if (_ResetCommand == null)
                {
                    _ResetCommand = new RelayCommand(param => this.Reset(),
                        null);
                }
                return _ResetCommand;
            }
        }

        public OrderSummary ReprintOrder
        {
            get
            {
                return _reprintorder;
            }

            set
            {
                _reprintorder = value;
            }
        }

        public Customer Customer
        {
            get
            {
                return _customer;
            }

            set
            {
                _customer = value;
                NotifyPropertyChanged("Customer");
            }
        }

        public ICommand SearchCustomerByCustIdCommand
        {
            get
            {

                if (_searchCustomerByCustIdCommand == null)
                {
                    _searchCustomerByCustIdCommand = new RelayCommand(param => this.SearchCustomerByCustId(),
                        null);
                }
                return _searchCustomerByCustIdCommand;
            }


        }

        private void SearchCustomerByCustId()
        {
            OrderRepository orderRepository = new OrderRepository();
            Customer cust = orderRepository.SearchCustomerByCustId(Customer.CustID);
            if (cust != null)
            {
                Customer = cust;
                OrderSummary.AvailableLoyaltyPoints = Customer.LeftRewardsPoints;
                OrderSummary.CustomerId = Customer.CustID;
            }
        }

        private void SearchCustomerByPhone()
        {
            OrderRepository orderRepository = new OrderRepository();
            Customer cust = orderRepository.SearchCustomerByPhone(Customer.Phone);
            if (cust != null)
            {
                Customer = cust;
                OrderSummary.AvailableLoyaltyPoints = Customer.LeftRewardsPoints;
                OrderSummary.CustomerId = Customer.CustID;
            }
        }

        public ICommand SearchCustomerByPhoneCommand
        {
            get
            {
                if (_searchCustomerByPhoneCommand == null)
                {
                    _searchCustomerByPhoneCommand = new RelayCommand(param => this.SearchCustomerByPhone(),
                        null);
                }
                return _searchCustomerByPhoneCommand;
            }


        }

        public ICommand SaveBillOnlyCommand
        {
            get
            {
                if (_SaveBillOnlyCommand == null)
                {
                    _SaveBillOnlyCommand = new RelayCommand(param => this.SaveBillOnly(),
                        null);
                }
                return _SaveBillOnlyCommand;
            }


        }

        public ICommand SearchCustomerByBarCodeCommand
        {
            get
            {
                if (_searchCustomerByBarCodeCommand == null)
                {
                    _searchCustomerByBarCodeCommand = new RelayCommand(param => this.SearchCustomerbyBarCode(),
                        null);
                }
                return _searchCustomerByBarCodeCommand;
            }

        }

        private void SaveBillOnly()
        {
            try
            {


                if (Orders.Count == 0 || Orders == null)
                {
                    System.Windows.MessageBox.Show("No records available to save!", "OPS System", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                if (Orders.Count > 0) Reset();

                if (OrderSummary.BillNo > 0)
                {
                    System.Windows.MessageBox.Show("Bill already generated, to generate fresh bill click on New Bill button", "OPS System", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;

                }
                //var result = printDlg.ShowDialog();
                //if (result.HasValue && result.Value)
                //{
                //    var queue = printDlg.PrintQueue;

                //    // Contains extents and offsets
                //    var area = queue.GetPrintCapabilities(printDlg.PrintTicket)
                //                    .PageImageableArea;

                //    // scale = area.ExtentWidth and area.ExtentHeight and your UIElement's bounds
                //    // margin = area.OriginWidth and area.OriginHeight
                //    // 1. Use the scale in your ScaleTransform
                //    // 2. Use the margin and extent information to Measure and Arrange
                //    // 3. Print the visual
                //}
                MessageBoxResult result;
                if (OrderSummary.IsBillReturn)
                {
                    result = System.Windows.MessageBox.Show("Return Bill?", "Return - Warning Message", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.No);
                }
                else
                {
                    result = System.Windows.MessageBox.Show("Generate Final Bill?", "Bill Generate - Warning Message", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.No);
                }
                if (result == MessageBoxResult.No || result == MessageBoxResult.Cancel) return;
                if (result == MessageBoxResult.Yes)
                {
                    OrderRepository orderRepository = new OrderRepository();
                    Int64 BillNo = orderRepository.saveBill(Orders, OrderSummary);

                    //foreach (var ord in Orders)
                    //{
                    OrderSummary.BillNo = BillNo;

                    try
                    {
                        if (OrderSummary.BillAmount > 1000)
                        {
                            Utility.SendMail(OrderSummary);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Unable to send mail!");
                    }
                    //}
                    //Products = new ObservableCollection<Product>(orderRepository.getProductList());
                    //NotifyPropertyChanged("Order");
                    NotifyPropertyChanged("OrderSummary");
                    Reset();
                    MessageBox.Show("Bill Saved Succesfully");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured: " + ex.Message + " " + ex.Source + " " + ex.StackTrace);
            }
        }


        //Constructor
        public ViewModel()
        {
            OrderRepository orderRepository = new OrderRepository();

            Customer = new Customer();

            OrderSummary = new OrderSummary();
            ReprintOrder = new OrderSummary();
            Order = new Order();

            Orders = new ObservableCollection<Order>();
            //Orders = new ObservableCollection<Order>(orderRepository.getOrderDetail());
            Orders.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Orders_CollectionChanged);



            Product = new Product();
            //Products = new ObservableCollection<Product>();
            Products = new ObservableCollection<Product>(orderRepository.getProductList());


            PaymentModes = new ObservableCollection<PaymentMode>(orderRepository.getPaymentModes());

            SelectedPaymentMode = new PaymentMode();
            SelectedPaymentMode = PaymentModes.Where(x => x.PaymentModeId == 1).FirstOrDefault();


            Products.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Products_CollectionChanged);
            //Products.Add(new Product { BarCodeId = 8904109450426, ProductId = 1, ProductName = "Patanjali Saundarya Face Wash 60ml", ProductPrice = 50.0 });
            //Products.Add(new Product { BarCodeId = 8904109450020, ProductId = 2, ProductName = "Patanjali Kesh Kanti Hair Cleanser", ProductPrice = 70.00 });

            //Products.Add(new Product { BarCodeId = 8904109470868, ProductId = 3, ProductName = "Patanjali Amla Hair Oil 100ml", ProductPrice = 40.00 });
            //Products.Add(new Product { BarCodeId = 8906038782760, ProductId = 4, ProductName = "Anti Danadruff Shampoo Sri Sri", ProductPrice = 142 });

            //Products.Add(new Product { BarCodeId = 8906038781596, ProductId = 5, ProductName = "Aloe Vera Triphala Juice Sri Sri", ProductPrice = 142.0 });
            //Products.Add(new Product { BarCodeId = 8906038781039, ProductId = 6, ProductName = "Madhukari Herbal Tea Sri Sri", ProductPrice = 120.00 });

            Add();
            IsBarCodeFocused = true;
        }

        void Orders_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Object item in e.NewItems)
                {
                    (item as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(orderItem_PropertyChanged);
                }
            }
            if (e.OldItems != null)
            {
                foreach (Object item in e.OldItems)
                {
                    (item as INotifyPropertyChanged).PropertyChanged -= new PropertyChangedEventHandler(orderItem_PropertyChanged);
                }
            }
            NotifyPropertyChanged("Orders");

        }
        void orderItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //NotifyCollectionChangedEventArgs a = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
            //Orders_CollectionChanged(a);
        }
        void Products_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

            NotifyPropertyChanged("Products");

        }

        private bool Submit()
        {
            try
            {
                bool retValue;
                retValue = IsValidOrder();
                if (!retValue)
                {

                    return false;

                }
                if (Order != null)
                {
                    if (Order.OrderDetailId == -1)
                    {
                        var ord = Orders.Where(p => p.BarCodeId == Order.BarCodeId).FirstOrDefault();
                        if (ord != null)
                        {
                            ord.Quantity = ord.Quantity + Order.Quantity;
                            //ord.Total = ord.Quantity * ord.Price;


                        }
                        else
                        {
                            Order.OrderDetailId = Orders.Count + 1;

                            Orders.Add(Order);
                        }

                    }
                    if (OrderSummary.DiscountAuto)
                        Order.Total = Order.Quantity * Order.Price;
                    else
                        Order.Total = Order.Quantity * Order.MRP;
                }

                NotifyPropertyChanged("Order");
                NotifyPropertyChanged("Orders");
                Add();
                OrderSummary.RefreshBillTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured: " + ex.Message + " " + ex.Source + " " + ex.StackTrace);
            }
            return true;
        }

        private bool IsValidOrder()
        {

            if (Order.Quantity == 0)
            {
                MessageBox.Show("Quantity cannot be zero, please enter valid quantity", "OPS System", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            var duplicates = Orders.OrderByDescending(e => e.ProductName)
                    .GroupBy(e => e.ProductName)
                    .Where(e => e.Count() > 1)
                    .Select(g => new
                    {
                        MostRecent = g.FirstOrDefault(),
                        Others = g.Skip(1).ToList()
                    });

            StringBuilder strBuilder = new StringBuilder();
            foreach (var item in duplicates)
            {
                Order mostRecent = item.MostRecent;
                strBuilder.Append(mostRecent.ProductName + "\n");
                Order = mostRecent;
                List<Order> others = item.Others;

                //do stuff with others
            }

            if (strBuilder.Length > 0)
            {
                MessageBox.Show("Duplicate Products entered " + "\n" + strBuilder, "OPS System", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            return true;
        }

        private void Add()
        {
            try
            {

                Order = new Order();
                Order.OrderDetailId = -1;

                Product = null;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured: " + ex.Message + " " + ex.Source + " " + ex.StackTrace);
            }
        }

        private void Reset()
        {


            if (Orders.Count >= 1)
            {
                Order = Orders[0];
                Product = Products.Where(p => p.BarCodeId == Order.BarCodeId).SingleOrDefault();
                //Product = Products.FirstOrDefault(p => p.BarCodeId == Order.BarCodeId);
            }
            OrderSummary.RefreshBillTotals();
            NotifyPropertyChanged("Order");

        }


        private void Delete()
        {
            if (Orders.Count == 1)
                Reset();

            if (Orders == null || Orders.Count == 0 || Order.OrderDetailId == -1)
            {
                System.Windows.MessageBox.Show("No record selected!");
            }
            else
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Would you like to delete selected record ?", "Warning Message", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    Product = null;
                    Orders.Remove(Order);
                    Reset();
                    if (Orders.Count == 0) Add();
                    OrderSummary.RefreshBillTotals();
                }
            }

        }
    }
}
