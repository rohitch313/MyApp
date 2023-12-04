

using MyApp.ViewModel;

namespace MyApp.View.Account;

public partial class CustomerSupportViewPage : ContentPage
{
	public CustomerSupportViewPage()
    {
        InitializeComponent();

        BindingContext = new CustomerSupportViewModel();

    }
 

 

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        string phoneNumber = "7417848676"; // Replace with the desired phone number

        if (!string.IsNullOrEmpty(phoneNumber))
        {
            // Launch the phone dialer with the phone number
             Launcher.OpenAsync($"tel:{phoneNumber}");
        }
    }
    private async void OnWhatsAppIconTapped(object sender, EventArgs e)
    {
        string phoneNumber = "+915678904532"; // Replace with the desired phone number

        if (!string.IsNullOrEmpty(phoneNumber))
        {
            // Launch WhatsApp with the phone number
            await Launcher.OpenAsync($"https://wa.me/{phoneNumber}");
        }
    }

    private async void OnEmailIconTapped(object sender, EventArgs e)
    {
        string email = "Nxfin@gmail.com"; // Replace with the desired email address

        if (!string.IsNullOrEmpty(email))
        {
            // Launch the default email app with the specified email address
            await Launcher.OpenAsync($"mailto:{email}");
        }
    }


}