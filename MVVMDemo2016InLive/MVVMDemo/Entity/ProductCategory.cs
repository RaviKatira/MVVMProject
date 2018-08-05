using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductCategory: INotifyPropertyChanged
    {
        int categoryId;
        string categoryName;
        double vatRate;

        public int CategoryId
        {
            get
            {
                return categoryId;
            }

            set
            {
                categoryId = value;
                OnPropertyChanged("CategoryId");
            }
        }

        public string CategoryName
        {
            get
            {
                return categoryName;

            }

            set
            {
                categoryName = value;
                OnPropertyChanged("CategoryName");
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
