namespace FitBody.Views.Employee;

public partial class EmployeePage : ContentPage
{
	public EmployeePage()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		Shell.Current.GoToAsync(nameof(EMadduser));
    }
}