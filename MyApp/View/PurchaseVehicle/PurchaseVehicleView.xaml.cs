using CommunityToolkit.Maui.Views;
using MyApp.View.Account;
using MyApp.ViewModel;

namespace MyApp.View.PurchaseVehicle;

[XamlCompilation(XamlCompilationOptions.Skip)]

public partial class PurchaseVehicleView : ContentPage
{
    public PurchaseVehicleView(VehicleRecordsViewModel vehicleRecordsViewModel)
    {
        InitializeComponent();
        BindingContext =  vehicleRecordsViewModel;
        SectionB.IsVisible = false;

        Section2.IsVisible = false;
        Section3.IsVisible = false;
        Section11.IsVisible = true;
        Section22.IsVisible = false;


        // Attach event handlers to the buttons
        SignButton1.Clicked += OnSignButtonClicked;
        DownloadButton.Clicked += OnDownloadButtonClicked;
        SignButton.Clicked += Sign_Clicked;
        MarketButton.Clicked += Market_Button_Clicked;
        New_CarButton.Clicked += New_Car_Clicked;
      
       
    }



    private ImageSource _capturedImageSource;

    public ImageSource CapturedImageSource
    {
        get { return _capturedImageSource; }
        set
        {
            _capturedImageSource = value;
            // Optionally, you can update UI elements here to reflect the new image source.
            // For example, if you have an Image control in your XAML named "capturedImage":
            // capturedImage.Source = value;
        }
    }

    private void Sign_Clicked(object sender, EventArgs e)
    {
        // Show section A and hide section B
        Section1.IsVisible = true;
        Section2.IsVisible = false;
        Section3.IsVisible = false;
    }


    private void Market_Button_Clicked(object sender, EventArgs e)
    {
        // Show section A and hide section B
        Section2.IsVisible = true;
        Section1.IsVisible = false;
        Section3.IsVisible = false;
    }

    private void New_Car_Clicked(object sender, EventArgs e)
    {
        // Show section A and hide section B
        Section3.IsVisible = true;
        Section1.IsVisible = false;
        Section2.IsVisible = false;
    }

    private void OnSignButtonClicked(object sender, EventArgs e)
    {
        // Show section A and hide section B
        SectionC.IsVisible = true;
        SectionB.IsVisible = false;
    }

    private void OnDownloadButtonClicked(object sender, EventArgs e)
    {
        // Show section B and hide section A
        SectionC.IsVisible = false;
        SectionB.IsVisible = true;
    }

    private void Vehicle1_Clicked(object sender, EventArgs e)
    {
        // Show section B and hide section A
        Section11.IsVisible = false;
        Section22.IsVisible = true;
    }
    private void Vehicle2_Clicked(object sender, EventArgs e)
    {
        // Show section B and hide section A
        Section11.IsVisible = false;
        Section22.IsVisible = true;
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        var popup = new PurchaseVehiclePopup();
        Shell.Current.CurrentPage.ShowPopup(popup);

    }

    private void Button_Clicked1(object sender, EventArgs e)
    {
        var popup = new PurchaseVehiclePopup();
        Shell.Current.CurrentPage.ShowPopup(popup);

    }
    private void Button_Clicked2(object sender, EventArgs e)
    {
        var popup = new PurchaseVehiclePopup();
        Shell.Current.CurrentPage.ShowPopup(popup);

    }
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(NotificationPage));
    }
    //private async void CapturedImage_Clicked(object sender, EventArgs e)
    //{
    //    // Open the bottom sheet (PaymentProovView)
    //    var paymentProovView = new PaymentProovView(this);
    //    await paymentProovView.ShowAsync();
    //    await Task.Delay(10000);
    //    await paymentProovView.DismissAsync();
    //}
}