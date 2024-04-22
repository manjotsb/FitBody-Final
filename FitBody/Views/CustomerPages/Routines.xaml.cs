using FitBody.Models;
using FitBody.Models.RoutineModels;

namespace FitBody.Views.CustomerPages;

public partial class Routines : ContentPage
{
    Customer currentCustomer;
    Routine _routineSelected;
    public Routine routineSelected
    {
        get { return _routineSelected; }
        set
        {
            _routineSelected = value;
            routineName.Text = _routineSelected.Name;
            sunday.Text = _routineSelected.WeeklyRoutine[DayOfWeek.Sunday].Name;
            monday.Text = _routineSelected.WeeklyRoutine[DayOfWeek.Monday].Name;
            tuesday.Text = _routineSelected.WeeklyRoutine[DayOfWeek.Tuesday].Name;
            wednesday.Text = _routineSelected.WeeklyRoutine[DayOfWeek.Wednesday].Name;
            thursday.Text = _routineSelected.WeeklyRoutine[DayOfWeek.Thursday].Name;
            friday.Text = _routineSelected.WeeklyRoutine[DayOfWeek.Friday].Name;
            saturday.Text = _routineSelected.WeeklyRoutine[DayOfWeek.Saturday].Name;
        }
    }
    public Routines()
	{
        currentCustomer = CustomerService.Instance.CurrentCustomer;
        InitializeComponent();
		routineCollection.ItemsSource = RoutineManager.routines;
	}

    private void OnItemSelected(object sender, SelectionChangedEventArgs e)
    {
        if (routineCollection.SelectedItem != null)
        {
            Routine itemSelected = e.CurrentSelection.FirstOrDefault() as Routine;

            routineSelected = itemSelected;
            routineCollection.IsVisible = false;
            routineFrame.IsVisible = true;
        }
    }

    private void OnBackClicked(object sender, EventArgs e)
    {
        routineCollection.IsVisible = true;
        routineFrame.IsVisible = false;
    }

    private void OnRoutineSelected(object sender, EventArgs e)
    {
        currentCustomer = CustomerService.Instance.CurrentCustomer;
        if (currentCustomer.UserRoutineId == _routineSelected.Id)
        {
            DisplayAlert("Routine Was Already Selected", $"The routine selected, was already assigned to the routine library of: {currentCustomer.Name}", "OK");
            return;
        }

        currentCustomer.UserRoutineId = _routineSelected.Id;
        CustomerManager customerManager = new CustomerManager();
        customerManager.UpdateCustomer(currentCustomer);

        DisplayAlert("Routine Changed", $"The routine: {_routineSelected.Name} was successfully added.", "OK");
    }

}