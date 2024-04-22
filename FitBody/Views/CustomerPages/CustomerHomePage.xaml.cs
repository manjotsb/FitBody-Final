using FitBody.Models;
using FitBody.Models.RoutineModels;
using System.Diagnostics;
namespace FitBody.Views.CustomerPages;

public partial class CustomerHomePage : ContentPage
{
	Customer currentCustomer;
	public CustomerHomePage()
	{
		InitializeComponent();
        UpdatePage();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdatePage();
    }


    public void UpdatePage()
    {
        currentCustomer = CustomerService.Instance.CurrentCustomer;
        welcomeLabel.Text = $"Hello, {currentCustomer.Name}!";

        DateTime currentDate = DateTime.Now;
        DayOfWeek currentDay = currentDate.DayOfWeek;

        string dayName = currentDay.ToString();

        todaysWorkoutLabel.Text = $"Today's {dayName} Workout Details:";

        if (currentCustomer.UserRoutineId != 0)
        {
            workoutDetails.IsVisible = true;

            Routine routine = RoutineManager.routineDictionary[currentCustomer.UserRoutineId];
            routineLabel.Text = routine.Name;

            Workout workout = routine.WeeklyRoutine[currentDay];

            if (workout.Id == 0) 
            {
                workoutName.Text = $"Today is your {workout.Name}. You deserve it!";
                workoutDifficulty.Text = "";
                workoutExercises.Text = "";
                workoutCategory.Text = "";
                startWorkoutButton.IsVisible = false;
                return;
            }

            workoutName.Text = $"Workout Name: {workout.Name}";
            workoutDifficulty.Text = $"Difficulty: {workout.Difficulty}";
            workoutExercises.Text = $"Number of Exercises: {workout.Exercises.Count()}";
            workoutCategory.Text = $"Category: {workout.Category}";
            startWorkoutButton.IsVisible = true;
        }
        else
        {
            todaysWorkoutLabel.Text = "First Select a Routine to see your next Workout!";
        }
    }

    private void OnStartClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(StartWorkout));
    }
}