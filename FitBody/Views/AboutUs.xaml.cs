namespace FitBody.Views;

public partial class AboutUs : ContentPage
{
	public AboutUs()
	{
		InitializeComponent();
	}

    private void OnBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}