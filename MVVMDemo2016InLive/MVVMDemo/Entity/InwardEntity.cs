using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class InwardEntity: INotifyPropertyChanged
    {
        private bool isDirty;
        private string barCodeId;
        private int inwardDetailId;
        private int productId;
        private string productName;
        private double quantity;
        private DateTime dated;

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

        public int InwardDetailId
        {
            get
            {
                return inwardDetailId;
            }

            set
            {
                inwardDetailId = value;
                OnPropertyChanged("InwardDetailId");
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
            }
        }

        public DateTime Dated
        {
            get
            {
                return dated;
            }

            set
            {
                dated = value;
                OnPropertyChanged("Dated");
            }
        }

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
