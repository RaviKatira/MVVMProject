using Entity;
using OPSSystem.Command;
using OPSSystem.Common;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OPSMain.CustomerEntry
{
    public class CustomerViewModel : ViewModelBase
    {

        private ObservableCollection<Customer> _customers;
        private Customer _selectedCustomer;
        private ICommand _AddCommand;
        private ICommand _SubmitCommand;
        private ICommand _SearchCommand;
        private string _customerSearchCriteria;
        public CustomerViewModel()
        {
            EnrichControls();
        }

        public ObservableCollection<Customer> Customers
        {
            get
            {
                return _customers;
            }

            set
            {
                _customers = value;
                NotifyPropertyChanged("Customers");
            }
        }

        public Customer SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }

            set
            {
                _selectedCustomer = value;
                NotifyPropertyChanged("SelectedCustomer");
            }
        }

        public ICommand AddCommand
        {
            get
            {
                if(_AddCommand ==null )
                {

                    _AddCommand = new RelayCommand(param => this.Add(), null);
                }
                return _AddCommand;
            }

            
        }

        public ICommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {

                    _SubmitCommand = new RelayCommand(param => this.Submit(), null);
                }
                
                return _SubmitCommand;
            }

            
        }

        public ICommand SearchCommand
        {
            get
            {
                if (_SearchCommand == null)
                {

                    _SearchCommand = new RelayCommand(param => this.SearchCustomer(), null);
                }

                return _SearchCommand;
            }

            
        }

        public string CustomerSearchCriteria
        {
            get
            {
                return _customerSearchCriteria;
            }

            set
            {
                _customerSearchCriteria = value;
                NotifyPropertyChanged("CustomerSearchCriteria");
            }
        }

        private void SearchCustomer()
        {
            CustomerRepository customerRepository = new CustomerRepository();
            Customers = new ObservableCollection<Customer>(customerRepository.getCustomerByName(CustomerSearchCriteria));
            NotifyPropertyChanged("Customers");
        }

        private bool Submit()
        {
            bool retValue;
            retValue = true;
            retValue = IsValidCustomer();
            if (!retValue)
            {

                return false;

            }
            CustomerRepository customerRepository = new CustomerRepository();
            if (SelectedCustomer != null)
            {
                if (SelectedCustomer.CustID == -1)
                {


                    int custID = customerRepository.saveCustomer(SelectedCustomer, "I");
                    SelectedCustomer.CustID= custID;
                    Customers.Add(SelectedCustomer);
                    MessageBox.Show("Customer added successfully", "OPS", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                else
                {

                    int productId = customerRepository.saveCustomer(SelectedCustomer, "U");
                    MessageBox.Show("Customer updated successfully", "OPS", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
                EnrichControls();
            }

            NotifyPropertyChanged("SelectedCustomer");
            NotifyPropertyChanged("Customers");
            Add();
            
            return true;
        }

        private bool IsValidCustomer()
        {
            var dupes = Customers.GroupBy(n => new { n.Customer_barcode }).Where(n => n.Skip(1).Any());
            
            if(dupes.Any())
            {
                MessageBox.Show("Duplicate Barcode Id", "OPS", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {

                return true;
            }
            
        }

        private void Add()
        {
            SelectedCustomer = new Customer();
            SelectedCustomer.CustID = -1;
        }

        private void EnrichControls()
        {
            CustomerRepository customerRepository = new CustomerRepository();
            SelectedCustomer = new Customer();
            Customers = new ObservableCollection<Customer>(customerRepository.getCustomerList());
            NotifyPropertyChanged("Customers");
        }
    }
}
