using CommunityToolkit.Maui.Views;


namespace MyApp.View.Account;

public partial class ProfileInfo : ContentPage
{
	public ProfileInfo()
	{
		InitializeComponent();
	}

    private void ProfileInfos(object sender, EventArgs e)
    {
      
        Navigation.PushAsync(new ProfileInformationPage());
       // Shell.Current.GoToAsync(nameof(ProfileInformationPage));

    }
    private void TermsInfos(object sender, EventArgs e)
    {
      
        Shell.Current.GoToAsync(nameof(Terms));

    }

    private void CustomerInfo(object sender, EventArgs e)
    {
      
        Shell.Current.GoToAsync(nameof(CustomerSupportViewPage));

    }

    private void Logout(object sender, EventArgs e)
    {
        var popupPage = new LogoutPage(); // Assuming "NewPopup" is the name of your popup page
        Shell.Current.CurrentPage.ShowPopup(popupPage);
    }
}