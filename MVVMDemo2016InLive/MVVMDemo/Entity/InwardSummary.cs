using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class InwardSummary : INotifyPropertyChanged
    {
        private Int64 inwardNo;
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
        public void Clear()
        {
            inwardNo = 0;
            
            OnPropertyChanged("InwardNo");
            
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
