using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductTreatmentLink:INotifyPropertyChanged
    {
        int _productId;
        int _treatmentId;
        string _treatmentName;
        public int ProductId
        {
            get
            {
                return _productId;
            }
            set
            {
                _productId = value;
                OnPropertyChanged("ProductId");
            }
        }
        public int TreatmentId
        {
            get
            {
                return _treatmentId;
            }

            set
            {
                _treatmentId = value;
                OnPropertyChanged("TreatmentId");
            }
        }

        public string TreatmentName
        {
            get
            {
                return _treatmentName;
            }

            set
            {
                _treatmentName = value;
                OnPropertyChanged("TreatmentName");
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
