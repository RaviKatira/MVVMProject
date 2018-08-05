using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Entity
{
    public class PaymentMode : INotifyPropertyChanged
    {
        int _paymentModeId;
        string _mode;

        public int PaymentModeId
        {
            get
            {
                return _paymentModeId;
            }

            set
            {
                _paymentModeId = value;
                OnPropertyChanged("PaymentModeId");
            }
        }
        public string Mode
        {
            get
            {
                return _mode;
            }

            set
            {
                _mode = value;
                OnPropertyChanged("Mode");
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
