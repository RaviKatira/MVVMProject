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

namespace OPSMain.SupplierEntry
{
    public class SupplierViewModel : ViewModelBase
    {
        private ObservableCollection<Supplier> _suppliers;
        private Supplier _selectedSupplier;

        private ActiveType _selectedActiveType;
        private ObservableCollection<ActiveType> _activeTypes;


        private ICommand _AddCommand;
        private ICommand _SubmitCommand;
        private ICommand _SearchCommand;


        public SupplierViewModel()
        {
            EnrichControls();
        }

        public ObservableCollection<Supplier> Suppliers
        {
            get
            {
                return _suppliers;
            }

            set
            {
                _suppliers = value;
                NotifyPropertyChanged("Suppliers");
            }
        }

        public ObservableCollection<ActiveType> ActiveTypes
        {
            get
            {
                return _activeTypes;
            }

            set
            {
                _activeTypes = value;
                NotifyPropertyChanged("ActiveTypes");
            }
        }
        public ActiveType SelectedActiveType
        {
            get
            {
                return _selectedActiveType;
            }

            set
            {


                _selectedActiveType = value;
                if (value != null)
                {

                    SelectedSupplier.IsActive = _selectedActiveType.ActiveCategory .ToUpper() == "TRUE" ? true : false;

                }
                NotifyPropertyChanged("SelectedActiveType");
                NotifyPropertyChanged("SelectedSupplier");
            }
        }
        public Supplier SelectedSupplier
        {
            get
            {
                return _selectedSupplier;
            }

            set
            {
                _selectedSupplier = value;
                if (_selectedSupplier != null && ActiveTypes != null)
                {
                    SelectedActiveType = ActiveTypes.Where(a => a.ActiveCategory.ToUpper() == _selectedSupplier.IsActive.ToString().ToUpper()).SingleOrDefault();
                }

                NotifyPropertyChanged("SelectedSupplier");
                NotifyPropertyChanged("SelectedActiveType");
            }
        }

        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
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


        private void Add()
        {
            SelectedSupplier = new Supplier();
            SelectedSupplier.SupplierId = -1;
            SelectedSupplier.IsActive = true;
            SelectedActiveType = new ActiveType { ActiveId = 1, ActiveCategory = "TRUE" };
            NotifyPropertyChanged("SelectedActiveType");

        }

        private bool Submit()
        {
            bool retValue;
            retValue = true;
            retValue = IsValidSupplier();
            if (!retValue)
            {

                return false;

            }
            SupplierRepository supplierRepository = new SupplierRepository();
            if (SelectedSupplier != null)
            {
                if (SelectedSupplier.SupplierId == -1)
                {


                    int supplierID = supplierRepository.saveSupplier(SelectedSupplier, "I");
                    SelectedSupplier.SupplierId = supplierID;
                    Suppliers.Add(SelectedSupplier);
                    MessageBox.Show("Supplier added successfully", "OPS", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                else
                {

                    int supplierID = supplierRepository.saveSupplier(SelectedSupplier, "U");
                    MessageBox.Show("Supplier updated successfully", "OPS", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                EnrichControls();
            }

            NotifyPropertyChanged("SelectedSupplier");
            NotifyPropertyChanged("Suppliers");
            Add();

            return true;
        }
        private void EnrichControls()
        {
            OrderRepository orderRepository = new OrderRepository();
            SupplierRepository supplierRepository = new SupplierRepository();
            SelectedSupplier = new Supplier();
            Suppliers = new ObservableCollection<Supplier>(supplierRepository.getSuppliers());
            ActiveTypes = new ObservableCollection<ActiveType>(orderRepository.getActiveTypes());
            NotifyPropertyChanged("Suppliers");
        }

        private bool IsValidSupplier()
        {
            var dupes = Suppliers.GroupBy(n => new { n.SupplierName }).Where(n => n.Skip(1).Any());

            if (dupes.Any())
            {
                MessageBox.Show("Duplicate Supplier Name", "OPS", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
