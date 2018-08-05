using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductOffers: INotifyPropertyChanged
    {

        int _offerId;
        string _offerOption;

        public int OfferId
        {
            get
            {
                return _offerId;
            }

            set
            {
                _offerId = value;
                OnPropertyChanged("OfferId");
            }
        }

        public string OfferOption
        {
            get
            {
                return _offerOption;
            }

            set
            {
                _offerOption = value;
                OnPropertyChanged("OfferOption");
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
