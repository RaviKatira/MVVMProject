using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Product : INotifyPropertyChanged, IEquatable<Product>
    {
        string barCodeId;
        int productId;
        string productName;
        double mrp;
        double productPrice;
        double productCostPrice;
        string productVatCategory;
        int productVatCategoryId;
        double vatRate;
        bool isActive;
        string productwithPrice;
        double _CPWithVAT;
        double _Profit;
        double _profitOnMRP;
        int _totalAvailQty;
        DateTime? _lastInwardDate;
        int _supplierId;
        string _supplierName;
        int _offerOption;
        string _offerOptionStr;



        public string BarCodeId
        {
            get
            {
                return barCodeId;
            }
            set
            {
                barCodeId= value;
                OnPropertyChanged("BarCodeId");
            }
        }
        public int ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
                OnPropertyChanged("ProductId");
            }
        }
        public string ProductName
        {
            get {
                return productName;
            }
            set
            {
                productName = value;
                OnPropertyChanged("ProductName");
            }
        }

        public double MRP
        {
            get
            {
                return mrp;
            }
            set
            {
                mrp = value;
                OnPropertyChanged("MRP");
            }
        }
        public double ProductPrice 
        {
            get
            {
                return productPrice;
            }
            set
            {
                productPrice = value;
                OnPropertyChanged("ProductPrice");
            }
        }

        public double ProductCostPrice
        {
            get
            {
                return productCostPrice;
            }

            set
            {
                productCostPrice = value;
                OnPropertyChanged("ProductCostPrice");
            }
        }

        public string ProductVatCategory
        {
            get
            {
                return productVatCategory;
            }

            set
            {
                productVatCategory = value;
                OnPropertyChanged("ProductVatCategory");
            }
        }

        

        public int ProductVatCategoryId
        {
            get
            {
                return productVatCategoryId;
            }

            set
            {
                productVatCategoryId = value;
                OnPropertyChanged("ProductVatCategoryId");
            }
        }

        public bool IsActive
        {
            get
            {
                return isActive;
            }

            set
            {
                isActive = value;
                OnPropertyChanged("IsActive");
            }
        }

        public double VatRate
        {
            get
            {
                return vatRate;
            }

            set
            {
                vatRate = value;
                OnPropertyChanged("VatRate");
            }
        }

        public string ProductwithPrice
        {
            get
            {
                return productwithPrice;
            }

            set
            {
                productwithPrice = value;
                OnPropertyChanged("ProductwithPrice");
            }
        }

        public double CPWithVAT
        {
            get
            {
                return _CPWithVAT;
            }

            set
            {
                _CPWithVAT = value;
                OnPropertyChanged("CPWithVAT");
            }
        }
        public double ProfitOnMRP
        {
            get
            {
                return _profitOnMRP;
            }

            set
            {
                _profitOnMRP = value;
                OnPropertyChanged("ProfitOnMRP");
            }
        }

        public double Profit
        {
            get
            {
                return _Profit;
            }

            set
            {
                _Profit = value;
                OnPropertyChanged("Profit");
            }
        }

        public int TotalAvailQty
        {
            get
            {
                return _totalAvailQty;
            }

            set
            {
                _totalAvailQty = value;
                OnPropertyChanged("TotalAvailQty");
            }
        }

        public DateTime? LastInwardDate
        {
            get
            {
                return _lastInwardDate;
            }

            set
            {
                _lastInwardDate = value;
                OnPropertyChanged("LastInwardDate");
            }
        }

        public int SupplierId
        {
            get
            {
                return _supplierId;
            }

            set
            {
                _supplierId = value;
                OnPropertyChanged("SupplierId");
            }
        }

        public string SupplierName
        {
            get
            {
                return _supplierName;
            }

            set
            {
                _supplierName = value;
                OnPropertyChanged("SupplierName");
            }
        }

        public int OfferOption
        {
            get
            {
                return _offerOption;
            }

            set
            {
                _offerOption = value;
                OnPropertyChanged("OfferOption");
            }
        }

        public string OfferOptionStr
        {
            get
            {
                return _offerOptionStr;
            }

            set
            {
                _offerOptionStr = value;
                OnPropertyChanged("OfferOptionStr");
            }
        }


        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool Equals(Product other)
        {
            return true;
           
        }
        #endregion
    }
}
