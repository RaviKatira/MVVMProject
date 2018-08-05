using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductInwardDetail : INotifyPropertyChanged
    {
        Int64 inwardNo;
        Int64 lotBarCodeId;
        int productId;
        string batchNo;
        string productName;
        int totalInwardLots;
        public Int64 InwardNo
        {
            get
            {
                return inwardNo;
            }
            set
            {
                inwardNo = value;
                OnPropertyChanged("InwardNo");
            }
        }

        public Int64 LotBarCodeId
        {
            get
            {
                return lotBarCodeId;
            }
            set
            {
                lotBarCodeId = value;
                OnPropertyChanged("LotBarCodeId");
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

        public string BatchNo
        {
            get
            {
                return batchNo;
            }
            set
            {
                batchNo = value;
                OnPropertyChanged("BatchNo");
            }
        }


        public int TotalInwardLots
        {
            get
            {
                return totalInwardLots;
            }
            set
            {
                totalInwardLots = value;
                OnPropertyChanged("TotalInwardLots");
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
