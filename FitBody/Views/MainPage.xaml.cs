using FitBody.Models.RoutineModels;
using FitBody.Models;
using FitBody.Views.CustomerPages;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Formats.Tar;
using System.Xml.Linq;

namespace FitBody.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            RoutineManager.SetWorkouts();
            RoutineManager.SetRoutines();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            username.Text = string.Empty;
            password.Text = string.Empty;
        }

        private void OnLogUserClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(username.Text) ||
                string.IsNullOrWhiteSpace(password.Text))
            {
                DisplayAlert("Input Error", "All fields must be filled out.", "OK");
                return;
            }

            CustomerManager  customerManager = new CustomerManager();
            if (!(customerManager.IsCustomer(username.Text, password.Text)))
            {
                DisplayAlert("Customer does not exist", "Check the spelling of the username/password.", "OK");
                return;
            }

            var customer = customerManager.GetCustomer(username.Text);

            CustomerService.Instance.CurrentCustomer = customer;
            Shell.Current.GoToAsync(nameof(TabsCustomer));
        }

        private void OnLogEmployeeClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(LoginEmployee));
        }

        private void OnCreateAccountClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(CreateCustomer));
        }

        private void OnAboutUsClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(AboutUs));
        }
    }

}
