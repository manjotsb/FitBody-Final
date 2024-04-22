using FitBody.Models;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using FitBody;

namespace FitBody.Views;

[QueryProperty(nameof(newCustomer), "customer")]
public partial class CreateCustomerDetails : ContentPage
{
    private int _count;
    private int _age;
    private string _gender;
    private int _height;
    private int _weight;
    private Customer _newCustomer;
    public Customer newCustomer 
    {
        set { _newCustomer = value;}
        get { return _newCustomer; }
    }

	public CreateCustomerDetails()
	{
        List<int> agesList;
        List<int> heightList;
        List<int> weightList;

        InitializeComponent();
        _count = 1;

        agesList = new List<int>();
        heightList = new List<int>();
        weightList = new List<int>();

        for (int age = 12; age <= 100; age++)
        {
            agesList.Add(age);
        }

        for (int height = 100; height <= 210; height++)
        {
            heightList.Add(height);
        }

        for (int weight = 32; weight <= 180; weight++)
        {
            weightList.Add(weight);
        }

        pickerYears.ItemsSource = agesList;
        pickerHeight.ItemsSource = heightList;
        pickerWeight.ItemsSource = weightList;
    }
    private void OnPickerSelected (object sender, EventArgs e)
    {
        continueButton.IsEnabled = true;
        continueButton.Background = (LinearGradientBrush)Resources["BackgroundGradient"];
        continueButton.TextColor = Color.FromArgb("#FFFFFF");

        switch (_count)
        {
            case 1:
                _age = (int)pickerYears.SelectedItem;
                break;
            case 2:
                _gender = (string)pickerGender.SelectedItem;
                break;
            case 3:
                _height = (int)pickerHeight.SelectedItem;
                break;
            case 4:
                _weight = (int)pickerWeight.SelectedItem;
                break;
        }
    }

    private void OnContinueClicked(object sender, EventArgs e)
    {
        string stackName = $"stack{_count}";

        var stackLayout = this.FindByName<VerticalStackLayout>(stackName);
        if (stackLayout != null)
        {
            stackLayout.IsVisible = false;
            _count++;
            stackName = $"stack{_count}";
            if (!(_count > 4))
            {
                var nextStack = this.FindByName<VerticalStackLayout>(stackName);
                nextStack.IsVisible = true;
            }
            else 
            {
                _newCustomer.Age = _age;
                _newCustomer.Gender = _gender;
                _newCustomer.Height = _height;
                _newCustomer.Weight = _weight;

                CustomerManager customerManager = new CustomerManager();

                customerManager.AddCustomer(_newCustomer);

                Shell.Current.GoToAsync("../..");
            }
        }

        string colName = $"col{_count}";

        var progressBar = this.FindByName<BoxView>(colName);
        if (progressBar != null)
        {
            progressBar.BackgroundColor = Color.FromArgb("#080CFE");
        }

        continueButton.Background = Color.FromArgb("#C8C8C8");
        continueButton.IsEnabled = false;
    }

    private void OnBackClicked(object sender, EventArgs e)
    {
        switch (_count)
        {
            case 1:
                Shell.Current.GoToAsync(nameof(CreateCustomer));
                break;
            default:
                string colName = $"col{_count}";
                var progressBar = this.FindByName<BoxView>(colName);
                if (progressBar != null)
                {
                    progressBar.BackgroundColor = Color.FromArgb("#00000000");
                }

                string stackName = $"stack{_count}";

                var stackLayout = this.FindByName<VerticalStackLayout>(stackName);
                if (stackLayout != null)
                {
                    stackLayout.IsVisible = false;
                    _count--;
                    stackName = $"stack{_count}";
                    if (!(_count > 4))
                    {
                        var nextStack = this.FindByName<VerticalStackLayout>(stackName);
                        nextStack.IsVisible = true;
                    }
                }

                break;

        }
    }
}