
using MyApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ViewModel

{
    public class CustomerSupportViewModel : INotifyPropertyChanged
    {
        private CustomerSupportModel _customerSupportData;

        public CustomerSupportViewModel()
        {
            _customerSupportData = new CustomerSupportModel
            {
                Call = "+9174178478676",
                WhatsAppNumber = "+915678904532",
                Email = "Nxfin@gmail.com"
            };
        }

        public string Call
        {
            get { return _customerSupportData.Call; }
            set
            {
                if (_customerSupportData.Call != value)
                {
                    _customerSupportData.Call = value;
                    OnPropertyChanged(nameof(Call));
                }
            }
        }

        public string WhatsAppNumber
        {
            get { return _customerSupportData.WhatsAppNumber; }
            set
            {
                if (_customerSupportData.WhatsAppNumber != value)
                {
                    _customerSupportData.WhatsAppNumber = value;
                    OnPropertyChanged(nameof(WhatsAppNumber));
                }
            }
        }

        public string Email
        {
            get { return _customerSupportData.Email; }
            set
            {
                if (_customerSupportData.Email != value)
                {
                    _customerSupportData.Email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
