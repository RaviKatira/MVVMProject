using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Entity
{
    public class OrderSummary :   INotifyPropertyChanged
    {
        private Int64 billNo;
        private double billAmount;
        private double cashTendered;
        private double balance;
        private string billDate;
        private double netBillAmt;
        private double consumedLoyaltyPoints;
        private double availableLoyaltyPoints;
        private double customerId;
        private bool isBillReturn;
        private double totalQty;
        private double totalCostPrice;
        private double totalProfit;
        private double discount;
        private double finalTotal;
        private Int32 paymentModeId;
        private bool discountAuto;
        


        public Int64 BillNo
        {
            get
            {
                return billNo;
            }
            set
            {
                billNo = value;
                OnPropertyChanged("BillNo");
            }
        }

        public bool DiscountAuto
        {
            get
            {
                return discountAuto;
            }
            set
            {
                discountAuto = value;
                OnPropertyChanged("DiscountAuto");
            }
        }
        public double BillAmount
        {
            get
            {
                return billAmount;
            }
            set
            {
                billAmount = value;
                OnPropertyChanged("BillAmount");
            }
        }
        
        public void Clear()
        {
            billNo = 0;
            billAmount = balance = cashTendered =  netBillAmt = consumedLoyaltyPoints= availableLoyaltyPoints= discount = finalTotal = 0  ;
            //PaymentModeId = 1;
            customerId = 0;
            isBillReturn = false;
            totalQty = 0;
            DiscountAuto = false;
            OnPropertyChanged("CashTendered");
            OnPropertyChanged("BillAmount");
            OnPropertyChanged("Balance");
            OnPropertyChanged("BillNo");
            OnPropertyChanged("NetBillAmt");
            OnPropertyChanged("ConsumedLoyaltyPoints");
            OnPropertyChanged("AvailableLoyaltyPoints");
            OnPropertyChanged("IsBillReturn");
            OnPropertyChanged("TotalQty");
            OnPropertyChanged("Discount");
            OnPropertyChanged("FinalTotal");
            OnPropertyChanged("PaymentModeId");

        }

        public double Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
                OnPropertyChanged("Balance");
            }
        }

        public string BillDate
        {
            get
            {
                return billDate;
            }

            set
            {
                billDate = value;
                OnPropertyChanged("BillDate");
            }
        }

        public double CashTendered
        {
            get
            {
                return cashTendered;
            }
            set
            {
                cashTendered = value;
                RefreshBillTotals();
            }
        }

        public double NetBillAmt
        {
            get
            {
                return netBillAmt;
            }

            set
            {
                
                netBillAmt = billAmount - consumedLoyaltyPoints;
                
                OnPropertyChanged("NetBillAmt");
            }
        }

        public double CustomerId
        {
            get
            {
                return customerId;
            }

            set
            {
                customerId = value;
                OnPropertyChanged("CustomerId");
            }
        }

        public double ConsumedLoyaltyPoints
        {
            get
            {
                return consumedLoyaltyPoints;
            }

            set
            {
                consumedLoyaltyPoints = value;
                if (consumedLoyaltyPoints > AvailableLoyaltyPoints)
                {
                    MessageBox.Show("Consume LP cannot be greater than Available LP", "OPS System", MessageBoxButton.OK, MessageBoxImage.Error);
                    consumedLoyaltyPoints = 0;
                }

                RefreshBillTotals();
            }
        }

        public void RefreshBillTotals()
        {
            netBillAmt = billAmount - consumedLoyaltyPoints;
                
            //balance = cashTendered - netBillAmt;
            finalTotal = netBillAmt - discount;
            balance = (cashTendered - finalTotal ) > 0 ? cashTendered - finalTotal : 0;



            OnPropertyChanged("BillAmount");
            OnPropertyChanged("ConsumedLoyaltyPoints");
            OnPropertyChanged("NetBillAmt");
            OnPropertyChanged("Balance");
            OnPropertyChanged("CashTendered");
            OnPropertyChanged("Discount");
            OnPropertyChanged("FinalTotal");
        }

        public double AvailableLoyaltyPoints
        {
            get
            {
                return availableLoyaltyPoints;
            }

            set
            {
                availableLoyaltyPoints = value;
                OnPropertyChanged("AvailableLoyaltyPoints");
            }
        }

        public bool IsBillReturn
        {
            get
            {
                return isBillReturn;
            }

            set
            {
                isBillReturn = value;
                OnPropertyChanged("IsBillReturn");
            }
        }

        public double TotalQty
        {
            get
            {
                return totalQty;
            }

            set
            {
                totalQty = value;
                OnPropertyChanged("TotalQty");
            }
        }

        public double Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
                RefreshBillTotals();
                OnPropertyChanged("Discount");
            }
        }

        public double FinalTotal
        {
            get
            {
                return finalTotal;
            }

            set
            {
                finalTotal = value;
                OnPropertyChanged("FinalTotal");
            }
        }

        public Int32 PaymentModeId
        {
            get
            {
                return paymentModeId;
            }
            set
            {
                paymentModeId = value;
                OnPropertyChanged("PaymentModeId");
            }
        }

        public double TotalCostPrice
        {
            get
            {
                return totalCostPrice;
            }

            set
            {
                totalCostPrice = value;
                OnPropertyChanged("TotalCostPrice");
            }
        }

        public double TotalProfit
        {
            get
            {
                return totalProfit;
            }

            set
            {
                totalProfit = value;
                OnPropertyChanged("TotalProfit");
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
