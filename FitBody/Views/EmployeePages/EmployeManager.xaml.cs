namespace FitBody.Views.Employee;

public partial class EmployeManager : ContentPage
{
	public EmployeManager()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EMadduser));
    }
}