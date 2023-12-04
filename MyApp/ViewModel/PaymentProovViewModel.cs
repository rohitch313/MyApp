using CommunityToolkit.Mvvm.ComponentModel;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    class PaymentProovViewModel : ObservableObject
    {
        private DocPaymentProofPage _parentPage;

        public PaymentProovViewModel(DocPaymentProofPage parentPage)
        {
            _parentPage = parentPage;
        }

        public void Show()
        {
            PaymentProovView PaymentProov = new PaymentProovView(_parentPage);
            PaymentProov.ShowAsync();
        }
    }
}
