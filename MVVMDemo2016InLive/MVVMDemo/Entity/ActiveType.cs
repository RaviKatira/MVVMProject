using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ActiveType : INotifyPropertyChanged
    {
        int _activeId;
        string _activeCategory;

        public int ActiveId
        {
            get
            {
                return _activeId;
            }

            set
            {
                _activeId = value;
                OnPropertyChanged("ActiveId");
            }
        }

        public string ActiveCategory
        {
            get
            {
                return _activeCategory;
            }

            set
            {
                _activeCategory = value;
                OnPropertyChanged("ActiveCategory");
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
