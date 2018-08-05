using Entity;
using OPSSystem.Command;
using OPSSystem.Common;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OPSMain
{
    public class InwardViewModel : ViewModelBase
    {

        private InwardSummary _InwardSummary;

        private InwardDetail _InwardDetail;
        private ObservableCollection<InwardDetail> _InwardDetails;
        private Product _product;
        private ObservableCollection<Product> _products;
        //command
        private ICommand _AddCommand;
        private ICommand _SubmitCommand;
        private ICommand _DelCommand;
        private ICommand _ResetCommand;
        private ICommand _saveInwardCommand;
        private ICommand _searchBarCodeCommand;
        private ICommand _newInwardCommand;
        private object result;

        public InwardViewModel()
        {
            InwardSummary = new InwardSummary();
            InwardDetails = new ObservableCollection<InwardDetail>();
            //InwardDetails.Add(new InwardEntity{ BarCodeId ="1",ProductId=1,Dated=DateTime.Now,ProductName="xyz",Quantity=10});
            //InwardDetails.Add(new InwardEntity { BarCodeId = "2", ProductId = 3, Dated = DateTime.Now.AddDays(1), ProductName = "lmn", Quantity = 101 });

            OrderRepository orderRepository = new OrderRepository();
            InwardDetail = new InwardDetail();
            Product = new Product();
            //Products = new ObservableCollection<Product>();
            Products = new ObservableCollection<Product>(orderRepository.getProductList());

            Products.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Products_CollectionChanged);

            Add();
        }

        public InwardSummary InwardSummary
        {
            get
            {
                return _InwardSummary;
            }
            set
            {
                _InwardSummary = value;
                //if (_InwardSummary != null && Products != null)
                //{
                //    //Product = Products.Where(p => p.BarCodeId == InwardDetail.BarCodeId).SingleOrDefault();
                //    //InwardDetail.BillAmount = InwardDetails.Sum(x => x.Total);
                //    //OrderSummary.BillAmount = Orders.Sum(x => x.Total);
                //}
                NotifyPropertyChanged("InwardSummary");
            }
        }

        public InwardDetail InwardDetail
        {
            get
            {
                return _InwardDetail;
            }
            set
            {
                _InwardDetail = value;
                if (_InwardDetail != null && Products != null)
                {
                    Product = Products.Where(p => p.BarCodeId == InwardDetail.BarCodeId).SingleOrDefault();
                    //InwardDetail.BillAmount = InwardDetails.Sum(x => x.Total);
                    //OrderSummary.BillAmount = Orders.Sum(x => x.Total);
                }
                NotifyPropertyChanged("InwardDetail");
            }
        }
        public ObservableCollection<InwardDetail> InwardDetails
        {
            get
            {
                return _InwardDetails;
            }
            set
            {


                _InwardDetails = value;

                NotifyPropertyChanged("InwardDetails");
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

                    InwardDetail.ProductId = _product.ProductId;
                    InwardDetail.ProductName = _product.ProductName;
                    InwardDetail.BarCodeId = _product.BarCodeId;
                }
                NotifyPropertyChanged("Product");
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

        void Products_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

            NotifyPropertyChanged("Products");

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

        private void Add()
        {
            DateTime lDate = new DateTime();
            lDate = DateTime.Now;
            if (InwardDetail != null)
            {
                if (InwardDetail.Dated.Year != 1)
                {
                    lDate = InwardDetail.Dated;
                    if (lDate.Year == 1)
                    {
                        lDate = DateTime.Now;

                    }
                }
                else
                {
                    lDate = DateTime.Now;
                }

            }
            InwardDetail = new InwardDetail();
            InwardDetail.InwardDetailId = -1;

            InwardDetail.Dated = lDate;


            Product = null;

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

        private void Submit()
        {

            /**bool retValue;
            retValue = IsValidOrder();
            if (!retValue)
            {

                return false;

            }
            **/
            if (InwardDetail != null)
            {
                if (InwardDetail.InwardDetailId == -1)
                {
                    var inwDet = InwardDetails.Where(p => p.BarCodeId == InwardDetail.BarCodeId).FirstOrDefault();
                    if (inwDet != null)
                    {
                        inwDet.Quantity = inwDet.Quantity + InwardDetail.Quantity;
                        //ord.Total = ord.Quantity * ord.Price;


                    }
                    else
                    {
                        InwardDetail.InwardDetailId = InwardDetails.Count + 1;

                        InwardDetails.Add(InwardDetail);
                    }

                }
                //Order.Total = Order.Quantity * Order.Price;

            }

            NotifyPropertyChanged("InwardDetail");
            NotifyPropertyChanged("InwardDetails");
            Add();
            //OrderSummary.RefreshBillTotals();
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
        private void Delete()
        {
            if (InwardDetails == null || InwardDetails.Count == 0 || InwardDetail.InwardDetailId == -1)
            {
                System.Windows.MessageBox.Show("No record selected!");
            }
            else
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Would you like to delete selected record ?", "Warning Message", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    Product = null;
                    InwardDetails.Remove(InwardDetail);
                    Reset();
                    if (InwardDetails.Count == 0) Add();
                    //OrderSummary.RefreshBillTotals();
                }
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
        private void Reset()
        {
            if (InwardDetails.Count >= 1)
            {
                InwardDetail = InwardDetails[0];
                Product = Products.Where(p => p.BarCodeId == InwardDetail.BarCodeId).SingleOrDefault();
                //Product = Products.FirstOrDefault(p => p.BarCodeId == Order.BarCodeId);
            }
            //OrderSummary.RefreshBillTotals();
            NotifyPropertyChanged("InwardDetail");

        }
        public ICommand SaveInwardCommand
        {
            get
            {
                if (_saveInwardCommand == null)
                {
                    _saveInwardCommand = new RelayCommand(param => this.SaveInward(),
                        null);
                }
                return _saveInwardCommand;
            }


        }

        private void SaveInward()
        {
            if (InwardDetails.Count == 0 || InwardDetails == null)
            {
                System.Windows.MessageBox.Show("No records available to save!", "OPS System", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (InwardDetails.Count > 0) Reset();


            if (InwardSummary.InwardNo > 0)
            {
                System.Windows.MessageBox.Show("Inward already generated, to generate fresh Inward click on New Inward button", "OPS System", MessageBoxButton.OK, MessageBoxImage.Information);
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
            result = System.Windows.MessageBox.Show("Generate Inward?", "Inward - Warning Message", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.No);

            if (result == MessageBoxResult.No || result == MessageBoxResult.Cancel) return;
            if (result == MessageBoxResult.Yes)
            {
                InwardRepository inwardRepository = new InwardRepository();
                Int64 InwardNo = inwardRepository.saveInward(InwardDetails);
                InwardSummary.InwardNo = InwardNo;
                //}
                //NotifyPropertyChanged("Order");
                NotifyPropertyChanged("InwardSummary");
                //foreach (var ord in Orders)
                //{
                //OrderSummary.BillNo = BillNo;
                //}
                //NotifyPropertyChanged("Order");
                //NotifyPropertyChanged("OrderSummary");
                Reset();
                MessageBox.Show("Inward done Succesfully");
            }
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

        public ICommand NewInwardCommand
        {
            get
            {
                if (_newInwardCommand == null)
                {
                    _newInwardCommand = new RelayCommand(param => this.NewInwardEntry(),
                        null);
                }
                return _newInwardCommand;
            }

        }

        private void NewInwardEntry()
        {

            if (InwardDetails.Count > 0 && InwardSummary.InwardNo == 0)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure you want to create New Inward?", "Warning Message", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning, MessageBoxResult.No);
                if (result == MessageBoxResult.No || result == MessageBoxResult.Cancel)
                {
                    return;
                }
            }
            InwardDetails.Clear();
            InwardSummary.Clear();
            Add();
        }

        private void SearchProductbyBarCode()
        {

            try
            {

                if (InwardDetail == null)
                    InwardDetail = new InwardDetail();

                NotifyPropertyChanged("IsBarCodeFocused");

                if (InwardDetail.BarCodeId == null) return;
                if (InwardDetail.BarCodeId.Length == 0) return;

                if (InwardDetail.Quantity != 0 && InwardDetail.ProductId != 0) return;

                Product = Products.FirstOrDefault(p => p.BarCodeId == InwardDetail.BarCodeId);
                if (Product != null)
                {
                    InwardDetail.BarCodeId = Product.BarCodeId;
                    //InwardDetail.Price = Product.ProductPrice;
                    //InwardDetail.Quantity = 1.0;
                    InwardDetail.ProductName = Product.ProductName;
                    InwardDetail.ProductId = Product.ProductId;
                    NotifyPropertyChanged("InwardDetail");
                    //bool retValue = Submit();
                    //if (retValue)
                    //{
                    //    IsBarCodeFocused = true;
                    //}
                }
                else
                {
                    System.Windows.MessageBox.Show("Invalid Barcode!");

                    //IsBarCodeFocused = false;
                    NotifyPropertyChanged("IsBarCodeFocused");
                }

            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

}
