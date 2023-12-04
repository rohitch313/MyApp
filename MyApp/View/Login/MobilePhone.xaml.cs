

namespace MyApp.View.Login;

public partial class MobilePhone : ContentPage
{
	public MobilePhone()
	{
		InitializeComponent();


    }
    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EnterOtpPage));

    }
}