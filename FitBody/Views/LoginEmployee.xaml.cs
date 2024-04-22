using FitBody.Models;
using FitBody.Views.Employee;

namespace FitBody.Views;

public partial class LoginEmployee : ContentPage
{
	public LoginEmployee()
	{
		InitializeComponent();

		
	}

    private void OnLoginClicked(object sender, EventArgs e)
	{
        string email = EmployeEmail.Text;
        string password = EmployeePassword.Text;
        bool isEmployee;

        EmployeeManager employeeManager = new EmployeeManager();


        isEmployee = employeeManager.IsEmployee(email, password);

        if (isEmployee == true)
        {
            Shell.Current.GoToAsync(nameof(EmployeePage));
        }
        else
        {
            DisplayAlert("Invalid Password/email", "Error", "Ok");
        }
    }

    private void OnBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}