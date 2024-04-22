namespace FitBody.Views.CustomerPages;

public partial class ExclusiveMember : ContentPage
{
	public ExclusiveMember()
	{
		InitializeComponent();
	}

	private void OnPremiumClicked(object sender, EventArgs e)
	{
		DisplayAlert("Subscription", "Congratulations! You are now added to Premium subscription....", "Ok");
	}

	private void OnAdvancedClicked(object sender, EventArgs e)
	{
		DisplayAlert("Subscription", "Congratulations! You are now added to Advance subscription....", "Ok");
	}
}