using FitBody.Models;

namespace FitBody.Views.CustomerPages;

public partial class Profile : ContentPage
{
	Customer currentCustomer;
	public Profile()
	{
        InitializeComponent();
        currentCustomer = CustomerService.Instance.CurrentCustomer;
        username.Text = currentCustomer.Username;
        name.Text = currentCustomer.Name;
        email.Text = currentCustomer.Email;
        weight.Text = $"{currentCustomer.Weight} Kg.";
        height.Text = $"{currentCustomer.Height} Cm.";
        age.Text = $"{currentCustomer.Age} Years.";
    }


}