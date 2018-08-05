using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Order : INotifyPropertyChanged, IDataErrorInfo
    {
        private string barCodeId;
        private int orderDetailId;
        private int productId;
        private string productName;
        private double quantity;
        private double mrp;
        private double price;
        private double costPrice;
        private double profit;
        private double total;
        private double billAmount;
        private bool isDirty;

        public bool IsDirty
        {
            get
            {
                return isDirty;
            }
            set
            {
                isDirty = value;
                OnPropertyChanged("IsDirty");
            }
        }


        public String ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                productName = value;
                OnPropertyChanged("ProductName");
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

        public string BarCodeId
        {
            get
            {
                return barCodeId;
            }
            set
            {
                barCodeId = value;
                OnPropertyChanged("BarCodeId");
            }
        }

        public double BillAmount
        {
            get
            {
                return billAmount;
            }
            set
            {
                billAmount = value;
                OnPropertyChanged("BillAmount");
            }
        }



        public int OrderDetailId
        {
            get
            {
                return orderDetailId;
            }
            set
            {
                orderDetailId = value;
                OnPropertyChanged("OrderDetailId");
            }
        }
        public double Quantity
        {

            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
                OnPropertyChanged("Quantity");
                OnPropertyChanged("Total");
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
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public double Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
                OnPropertyChanged("Total");
            }
        }


        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double CostPrice
        {
            get
            {
                return costPrice;
            }

            set
            {
                costPrice = value;
                OnPropertyChanged("CostPrice");
            }
        }

        public double Profit
        {
            get
            {
                return profit;
            }

            set
            {
                profit = value;
                OnPropertyChanged("Profit");
            }
        }

        public string this[string propertyName]
        {
            get
            {
                string errorMsg = String.Empty;
                //if (propertyName.Equals("Quantity"))
                //{
                //    if (this != null)
                //    {
                //        if (quantity == 0)
                //        {
                //            errorMsg = "Quantity cannot be zero!";
                //        }
                //    }
                //}
                //throw new NotImplementedException();
                return errorMsg;
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
        #endregion
    }
}
