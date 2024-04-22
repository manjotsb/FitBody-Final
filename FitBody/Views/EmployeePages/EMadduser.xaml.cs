using FitBody.Views.Employee;

namespace FitBody.Views;

public partial class EMadduser : ContentPage
{
	public EMadduser()
	{
		InitializeComponent();
	}

    private void Back_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(EmployeManager));
    }
}