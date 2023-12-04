namespace MyApp.View.Login;

public partial class EnterOtpPage : ContentPage
{
    public EnterOtpPage()
    {
        InitializeComponent();



        // Automatically focus on the first Entry when the page is displayed
        Digit1Entry.Focus();
    }

    private void OnSubmitClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(BasicDetailView));
    }

    private void OnDigitEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        Entry currentEntry = (Entry)sender;

        if (!string.IsNullOrEmpty(e.NewTextValue) && e.NewTextValue.Length == 1)
        {
            // Move focus to the next Entry when a digit is entered
            switch (currentEntry)
            {
                case Entry _ when currentEntry == Digit1Entry:
                    Digit2Entry.Focus();
                    break;
                case Entry _ when currentEntry == Digit2Entry:
                    Digit3Entry.Focus();
                    break;
                case Entry _ when currentEntry == Digit3Entry:
                    Digit4Entry.Focus();
                    break;
                case Entry _ when currentEntry == Digit4Entry:
                    // Focus is already on the last Entry; you can perform additional actions here
                    break;
            }
        }
    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        Shell.Current.GoToAsync(nameof(LoginPage));
    }

    [Obsolete]
    private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(ProcessPage));

    }
}
