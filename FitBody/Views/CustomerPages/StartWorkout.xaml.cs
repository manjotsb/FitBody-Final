using FitBody.Models;
using FitBody.Models.RoutineModels;
using FitBody.Views.CustomerPages;
using System.Diagnostics;

namespace FitBody.Views;

public partial class StartWorkout : ContentPage
{
	private Customer currentCustomer;
    private Workout workout;
	private int exercisesCompleted = 0;
	public StartWorkout()
	{
		InitializeComponent();
		workout = GetWorkout();
		workoutTitle.Text = workout.Name;
		exerciseCollection.ItemsSource = workout.Exercises;
	}

	private Workout GetWorkout()
	{
        currentCustomer = CustomerService.Instance.CurrentCustomer;
        DateTime currentDate = DateTime.Now;
        DayOfWeek currentDay = currentDate.DayOfWeek;
        Routine routine = RoutineManager.routineDictionary[currentCustomer.UserRoutineId];
        Workout workout = routine.WeeklyRoutine[currentDay];

		return workout;
    }
    private void OnCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            exercisesCompleted++;
        }
        else
        {
            exercisesCompleted--;
        }
    }

	private void OnBackClicked (object sender, EventArgs e)
	{
		Shell.Current.GoToAsync(nameof(TabsCustomer));
	}

    private void OnFinishClicked(object sender, EventArgs e)
    {
        if (exercisesCompleted == workout.Exercises.Count())
        {
            DisplayAlert("Congratulations!", "You have completed all exercises!", "OK");
            Shell.Current.GoToAsync(nameof(TabsCustomer));
        }
        else
        {
            DisplayAlert("Workout Not Completed", "You have to complete all the exercises in the workout to finish it.", "OK");
            return;
        }
    }

    

}
