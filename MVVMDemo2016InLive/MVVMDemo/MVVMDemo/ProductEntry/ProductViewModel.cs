using Entity;
using OPSSystem.Command;
using OPSSystem.Common;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace OPSMain.ProductEntry
{
    public class ProductViewModel : ViewModelBase
    {
        private ObservableCollection<Treatment> _treatments;
        private Treatment _selectedTreatment;

        private ObservableCollection<ProductTreatmentLink> _productTreatementList;

        private CollectionViewSource _productsDataView;
        private string _sortColumn;
        private ListSortDirection _sortDirection;

        private string _productSearchCriteria;
        private Product _product;
        private ObservableCollection<Product> _selectedProduct;
        private List<Product> _preViewProducts;

        private ProductCategory _selectedProductCategory;
        private ObservableCollection<ProductCategory> _productCategory;

        private Supplier _selectedSupplier;
        private ObservableCollection<Supplier> _suppliers;

        private ObservableCollection<Supplier> _suppliersFilterList;
        private Supplier _selectedSupplierFilterList;


        private ActiveType _selectedActiveType;
        private ObservableCollection<ActiveType> _activeTypes;

        private ProductOffers _selectedProductOffer;
        private ObservableCollection<ProductOffers> _productOffer;

        private ICommand _SortCommand;
        private ICommand _AddCommand;
        private ICommand _SubmitCommand;
        private ICommand _SearchProductCommand;

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
            SelectedProduct = new Product();
            SelectedProduct.ProductId = -1;

        }

        public ICommand SearchProductCommand
        {
            get
            {
                if (_SearchProductCommand == null)
                {
                    _SearchProductCommand = new RelayCommand(param => this.SearchProduct(),
                        null);
                }
                return _SearchProductCommand;
            }
        }

        private void SearchProduct()
        {

            try
            {
                OrderRepository orderRepository = new OrderRepository();
                SelectedProduct = new Product();
                //Products = new ObservableCollection<Product>();
                Products = new ObservableCollection<Product>(orderRepository.getProductLike(ProductSearchCriteria, SelectedSupplierFilterList.SupplierId));
                ProductTreatementList = new ObservableCollection<ProductTreatmentLink>(orderRepository.getProductTreatementList());


                ProductCategory = new ObservableCollection<ProductCategory>(orderRepository.getProductCategory());


                ActiveTypes = new ObservableCollection<ActiveType>(orderRepository.getActiveTypes());
                ProductOffer = new ObservableCollection<ProductOffers>(orderRepository.getProductOffers());



                NotifyPropertyChanged("Products");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured: " + ex.Message + " " + ex.Source + " " + ex.StackTrace);

            }

        }

        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                {
                    _SortCommand = new RelayCommand(Sort);
                    //_SortCommand = new RelayCommand(param => this.Sort(),
                    //    null);
                }
                return _SortCommand;
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
        private bool Submit()
        {
            try
            {
                bool retValue;
                retValue = IsValidProduct();
                if (!retValue)
                {

                    return false;

                }
                OrderRepository ordRepo = new OrderRepository();
                if (SelectedProduct != null)
                {
                    string selectedTreatementValues = "";
                    foreach (var item in Treatments)
                    {
                        if (item.IsSelected)
                        {
                            selectedTreatementValues = selectedTreatementValues + item.TreatmentId.ToString() + ",";
                        }

                    }
                    if (selectedTreatementValues.Trim().Length > 0)
                        selectedTreatementValues = selectedTreatementValues.Remove(selectedTreatementValues.Length - 1, 1);

                    if (SelectedProduct.ProductId == -1)
                    {
                        int productId = ordRepo.saveProduct(SelectedProduct, selectedTreatementValues, "I");
                        SelectedProduct.ProductId = productId;
                        Products.Add(SelectedProduct);
                        MessageBox.Show("Product added successfully", "OPS", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    else
                    {

                        int productId = ordRepo.saveProduct(SelectedProduct, selectedTreatementValues, "U");
                        MessageBox.Show("Product updated successfully", "OPS", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    //if (Product. == -1)
                    //{
                    //var ord = Orders.Where(p => p.BarCodeId == Order.BarCodeId).FirstOrDefault();
                    //if (ord != null)
                    //{
                    //    ord.Quantity = ord.Quantity + Order.Quantity;
                    //    //ord.Total = ord.Quantity * ord.Price;


                    //}
                    //else
                    //{
                    //Order.OrderDetailId = Orders.Count + 1;





                    //Order.Total = Order.Quantity * Order.Price;
                    EnrichControls();
                }

                NotifyPropertyChanged("Product");
                NotifyPropertyChanged("Products");
                Add();
                //OrderSummary.RefreshBillTotals();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured: " + ex.Message + " " + ex.Source + " " + ex.StackTrace);
                return false;
            }

        }

        private bool IsValidProduct()
        {
            if (SelectedProduct.BarCodeId.Trim().Length == 0)
            {
                MessageBox.Show("Barcode Id cannot be empty!");
                return false;
            }
            if (SelectedProduct.ProductName.Trim().Length == 0)
            {
                MessageBox.Show("Product Name cannot be empty!");
                return false;
            }
            if (SelectedProduct.MRP <= 0)
            {
                MessageBox.Show("Product MRP should be greater than zero!");
                return false;
            }
            if (SelectedProduct.ProductPrice <= 0)
            {
                MessageBox.Show("Product Selling Price should be greater than zero!");
                return false;
            }
            if (SelectedProduct.ProductCostPrice <= 0)
            {
                MessageBox.Show("Product Cost Price should be greater than zero!");
                return false;
            }

            if (SelectedProduct.ProductVatCategoryId == 0)
            {
                MessageBox.Show("Please select Vat Category for product!");
                return false;
            }
            if (SelectedProduct.IsActive)
            {

                OrderRepository ordRepo = new OrderRepository();
                bool bFlag = ordRepo.ValidateProduct(SelectedProduct);
                if (!bFlag)
                {
                    MessageBox.Show("Cannot set, duplicate Barcode for the Active product!");
                    return false;
                }
            }
            return true;

        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductViewModel()
        {
            ProductSearchCriteria = String.Empty;
            EnrichControls();
            Add();
        }

        private void EnrichControls()
        {
            OrderRepository orderRepository = new OrderRepository();
            SelectedProduct = new Product();
            //Products = new ObservableCollection<Product>();
            Products = new ObservableCollection<Product>(orderRepository.getProductLike("", 0));

            ProductCategory = new ObservableCollection<ProductCategory>(orderRepository.getProductCategory());
            Suppliers = new ObservableCollection<Supplier>(orderRepository.getSuppliers());
            SuppliersFilterList = new ObservableCollection<Supplier>(orderRepository.getSuppliers());
            SelectedSupplierFilterList = new Supplier();
            ActiveTypes = new ObservableCollection<ActiveType>(orderRepository.getActiveTypes());
            ProductOffer = new ObservableCollection<ProductOffers>(orderRepository.getProductOffers());
            Treatments = new ObservableCollection<Treatment>(orderRepository.getTreatmentList());
            ProductTreatementList = new ObservableCollection<ProductTreatmentLink>(orderRepository.getProductTreatementList());

            //Treatments = new Dictionary<string, object>();
            //foreach (var item in treatmentList)
            //{

            //       Treatments.Add(item.TreatmentName,item.TreatmentId);
            //}

            //Treatments.Add("Chennai", "MAS");
            //Treatments.Add("Trichy", "TPJ");
            //Treatments.Add("Bangalore", "SBC");
            //Treatments.Add("Coimbatore", "CBE");

            //SelectedTreatments = new Dictionary<string, object>();
            //SelectedTreatments.Add("Chennai", "MAS");
            //SelectedTreatments.Add("Trichy", "TPJ");

            NotifyPropertyChanged("Treatments");
            NotifyPropertyChanged("SelectedTreatments");
            NotifyPropertyChanged("Products");
        }

        public Product SelectedProduct
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
                    if (SelectedProduct != null && ProductCategory != null)
                    {
                        SelectedProductCategory = ProductCategory.Where(p => p.CategoryId == SelectedProduct.ProductVatCategoryId).SingleOrDefault();

                    }
                    if (SelectedProduct != null && ActiveTypes != null)
                    {
                        SelectedActiveType = ActiveTypes.Where(a => a.ActiveCategory == SelectedProduct.IsActive.ToString()).SingleOrDefault();
                    }

                    if (SelectedProduct != null && Suppliers != null)
                    {
                        SelectedSupplier = Suppliers.Where(a => a.SupplierId == SelectedProduct.SupplierId).SingleOrDefault();
                    }

                    if (SelectedProduct != null && ProductOffer != null)
                    {
                        SelectedProductOffer = ProductOffer.Where(a => a.OfferId == SelectedProduct.OfferOption).SingleOrDefault();
                    }

                    if (SelectedProduct != null && ProductTreatementList != null)
                    {
                        var result = ProductTreatementList.Where(x => x.ProductId == SelectedProduct.ProductId).ToList();

                        //SelectedTreatments.Add("Chennai", "MAS");
                        //SelectedTreatments.Add("Trichy", "TPJ");
                        Treatments.ToList().ForEach(x => x.IsSelected = false);
                        foreach (var item in result)
                        {
                            Treatments.FirstOrDefault(x => x.TreatmentId == item.TreatmentId).IsSelected = true;
                        }

                    }

                    //InwardDetail.ProductId = _product.ProductId;
                    //InwardDetail.ProductName = _product.ProductName;
                    //InwardDetail.BarCodeId = _product.BarCodeId;
                }
                NotifyPropertyChanged("SelectedProductCategory");
                NotifyPropertyChanged("SelectedActiveType");
                NotifyPropertyChanged("SelectedProductOffer");
                NotifyPropertyChanged("SelectedSupplier");
                NotifyPropertyChanged("SelectedProduct");
                NotifyPropertyChanged("SelectedTreatments");
            }
        }

        public ObservableCollection<ProductCategory> ProductCategory
        {
            get
            {
                return _productCategory;
            }

            set
            {
                _productCategory = value;
                NotifyPropertyChanged("ProductCategory");
            }
        }
        public void Sort(object parameter)
        {
            string column = parameter as string;
            if (_sortColumn == column)
            {
                // Toggle sorting direction 
                _sortDirection = _sortDirection == ListSortDirection.Ascending ?
                                                   ListSortDirection.Descending :
                                                   ListSortDirection.Ascending;
            }
            else
            {
                _sortColumn = column;
                _sortDirection = ListSortDirection.Ascending;
            }

            _productsDataView.SortDescriptions.Clear();
            _productsDataView.SortDescriptions.Add(
                                     new SortDescription(_sortColumn, _sortDirection));

        }
        public ListCollectionView ProductsDataView
        {
            get
            {
                return (ListCollectionView)_productsDataView.View;
            }

        }

        public ObservableCollection<Product> Products
        {
            get
            {
                return _selectedProduct;
            }
            set
            {


                _selectedProduct = value;
                _productsDataView = new CollectionViewSource();
                _productsDataView.Source = Products;

                NotifyPropertyChanged("Products");
                NotifyPropertyChanged("ProductsDataView");
            }
        }

        public ProductCategory SelectedProductCategory
        {
            get
            {
                return _selectedProductCategory;
            }

            set
            {
                _selectedProductCategory = value;
                if (value != null)
                {

                    SelectedProduct.ProductVatCategoryId = SelectedProductCategory.CategoryId;
                    SelectedProduct.ProductVatCategory = SelectedProductCategory.CategoryName;
                    SelectedProduct.VatRate = SelectedProductCategory.VatRate;
                }
                NotifyPropertyChanged("SelectedProductCategory");
            }
        }

        public List<Product> PreViewProducts
        {
            get
            {
                return _preViewProducts;
            }

            set
            {
                _preViewProducts = value;
            }
        }



        public ActiveType SelectedActiveType
        {
            get
            {
                return _selectedActiveType;
            }

            set
            {


                _selectedActiveType = value;
                if (value != null)
                {

                    SelectedProduct.IsActive = _selectedActiveType.ActiveCategory == "True" ? true : false;

                }
                NotifyPropertyChanged("SelectedActiveType");
            }
        }

        public ObservableCollection<ActiveType> ActiveTypes
        {
            get
            {
                return _activeTypes;
            }

            set
            {
                _activeTypes = value;
                NotifyPropertyChanged("ActiveTypes");
            }
        }

        public string ProductSearchCriteria
        {
            get
            {
                return _productSearchCriteria;
            }

            set
            {
                _productSearchCriteria = value;


                NotifyPropertyChanged("ProductSearchCriteria");
            }
        }

        public Supplier SelectedSupplier
        {
            get
            {
                return _selectedSupplier;
            }

            set
            {
                _selectedSupplier = value;

                if (value != null)
                {

                    SelectedProduct.SupplierId = SelectedSupplier.SupplierId;
                    SelectedProduct.SupplierName = SelectedSupplier.SupplierName;
                }

                NotifyPropertyChanged("SelectedSupplier");
            }
        }

        public ObservableCollection<Supplier> Suppliers
        {
            get
            {
                return _suppliers;
            }

            set
            {
                _suppliers = value;
                NotifyPropertyChanged("Suppliers");
            }
        }

        public ProductOffers SelectedProductOffer
        {
            get
            {
                return _selectedProductOffer;
            }

            set
            {
                _selectedProductOffer = value;
                if (value != null)
                {

                    SelectedProduct.OfferOption = _selectedProductOffer.OfferId;

                }
                NotifyPropertyChanged("SelectedProductOffer");
            }
        }

        public ObservableCollection<ProductOffers> ProductOffer
        {
            get
            {
                return _productOffer;
            }

            set
            {
                _productOffer = value;
                NotifyPropertyChanged("ProductOffer");
            }
        }

        public ObservableCollection<Treatment> Treatments
        {
            get
            {
                return _treatments;
            }

            set
            {
                _treatments = value;
                NotifyPropertyChanged("Treatments");
            }
        }

        public Treatment SelectedTreatment
        {
            get
            {
                return _selectedTreatment;
            }

            set
            {
                _selectedTreatment = value;
                NotifyPropertyChanged("SelectedTreatment");
            }
        }

        public ObservableCollection<ProductTreatmentLink> ProductTreatementList
        {
            get
            {
                return _productTreatementList;
            }

            set
            {
                _productTreatementList = value;
            }
        }

        public ObservableCollection<Supplier> SuppliersFilterList
        {
            get
            {
                return _suppliersFilterList;
            }

            set
            {
                _suppliersFilterList = value;
                NotifyPropertyChanged("SuppliersFilterList");
            }
        }

        public Supplier SelectedSupplierFilterList
        {
            get
            {
                return _selectedSupplierFilterList;
            }

            set
            {
                _selectedSupplierFilterList = value;
                NotifyPropertyChanged("SelectedSupplierFilterList");
            }
        }
    }
}
