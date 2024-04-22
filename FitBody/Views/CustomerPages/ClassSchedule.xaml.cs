using FitBody.Models;
using FitBody.Models.RoutineModels;
using FitBody.Views.CustomerPages;

namespace FitBody.Views;

public partial class ClassSchedule : ContentPage
{
    public GymClass gymClass;
	public ClassSchedule()
	{
		InitializeComponent();
	}

	private void OnButtonClicked(object sender, EventArgs e)
	{
		schedule.IsVisible = false;
		classFrame.IsVisible = true;

        if (sender is Button button)
        {
            string buttonText = button.Text;

            GymClassManager gymClassManager = new GymClassManager();
            gymClass = gymClassManager.GetGymClass(buttonText);
            className.Text = gymClass.Name;
            instructor.Text = $"Instructor: {gymClass.Instructor}";
            location.Text = $"Located at: {gymClass.Location}";
            level.Text = $"Difficulty: {gymClass.Level}";
            currentCapacity.Text = $"Available Spots: {gymClass.CurrentCapacity}";
        }
    }
    
    private void OnRegisterClicked(object sender, EventArgs e)
    {
        if (gymClass.CurrentCapacity < 1)
        {
            DisplayAlert($"No Available Spots", $"All the available spots for {gymClass.Name} have been filled.", "OK");
            return;
        }

        gymClass.CurrentCapacity -= 1;
        GymClassManager gymClassManager = new GymClassManager();
        gymClassManager.UpdateGymClass(gymClass);
        DisplayAlert($"Registered for {gymClass.Name} Class", "You were successfully registered for this class.", "OK");
    }

    private void OnBackClicked(object sender, EventArgs e)
    {
        schedule.IsVisible = true;
        classFrame.IsVisible = false;
    }
}