using FitBody.Models;

namespace FitBody.Views;

public partial class CreateCustomer : ContentPage
{
	public CreateCustomer()
	{
		InitializeComponent();
	}

    private void OnCreateClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(username.Text) ||
        string.IsNullOrWhiteSpace(name.Text) ||
        string.IsNullOrWhiteSpace(email.Text) ||
        string.IsNullOrWhiteSpace(password.Text))
        {
            DisplayAlert("Input Error", "All fields must be filled out.", "OK");
            return; 
        }

        Customer newCustomer = new Customer(username.Text, name.Text, email.Text, password.Text);
        var navigationParameter = new ShellNavigationQueryParameters { { "customer", newCustomer} };
        Shell.Current.GoToAsync(nameof(CreateCustomerDetails),navigationParameter);

    }

    private void OnBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

}