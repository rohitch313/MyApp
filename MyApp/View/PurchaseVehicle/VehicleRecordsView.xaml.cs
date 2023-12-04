
using Microsoft.Maui.Controls;
using MyApp.ViewModel;

namespace MyApp
{
    public partial class VehicleRecordsView : ContentPage
    {
        

        public VehicleRecordsView(VehicleRecordsModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
