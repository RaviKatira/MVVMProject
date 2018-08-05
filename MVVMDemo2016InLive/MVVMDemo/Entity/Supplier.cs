using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Supplier : INotifyPropertyChanged
    {
        int _supplierId;
        string _supplierName;
        bool isActive;
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
