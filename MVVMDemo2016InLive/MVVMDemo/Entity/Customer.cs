using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Customer: INotifyPropertyChanged
    {
        int _custID;
        string _phone;
        string _name;
        string _address;
        Int64? _customer_barcode;
        double _leftRewardsPoints;
        double _totalRewardsPoints;
        double _consumedRewardsPoints;
        DateTime _createdOn;



        public int CustID
        {
            get
            {
                return _custID;
            }

            set
            {
                _custID = value;
                OnPropertyChanged("CustID");
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }

            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public Int64? Customer_barcode
        {
            get
            {
                return _customer_barcode;
            }

            set
            {
                _customer_barcode = value;
                OnPropertyChanged("Customer_barcode");
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }

            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }

        public double LeftRewardsPoints
        {
            get
            {
                return _leftRewardsPoints;
            }

            set
            {
                _leftRewardsPoints = value;
                OnPropertyChanged("LeftRewardsPoints");
            }
        }

        public double TotalRewardsPoints
        {
            get
            {
                return _totalRewardsPoints;
            }

            set
            {
                _totalRewardsPoints = value;
                OnPropertyChanged("TotalRewardsPoints");
            }
        }

        public double ConsumedRewardsPoints
        {
            get
            {
                return _consumedRewardsPoints;
            }

            set
            {
                _consumedRewardsPoints = value;
                OnPropertyChanged("ConsumedRewardsPoints");
            }
        }

        public DateTime CreatedOn
        {
            get
            {
                return _createdOn;
            }

            set
            {
                _createdOn = value;
                OnPropertyChanged("CreatedOn");
            }
        }

        public void Clear()
        {

            CustID=0;
            _phone=string.Empty;
            _name= string.Empty;
            _address= string.Empty;
            _customer_barcode= 0;
            _leftRewardsPoints = 0;
            OnPropertyChanged("CustID");
            OnPropertyChanged("Phone");
            OnPropertyChanged("Name");
            OnPropertyChanged("Address");
            OnPropertyChanged("Customer_barcode");
            OnPropertyChanged("LeftRewardsPoints");
            OnPropertyChanged("ConsumedRewardsPoints");
            OnPropertyChanged("CreatedOn");
            OnPropertyChanged("TotalRewardsPoints");
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
