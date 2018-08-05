using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Treatment:INotifyPropertyChanged
    {
        bool _isSelected;
        int _treatmentId;
        string _treatmentName;

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }

            set
            {
                _isSelected = value;
                OnPropertyChanged("IsSelected");
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
                _treatmentName= value;
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
