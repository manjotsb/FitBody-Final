using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FitBody.Models.RoutineModels
{
    public static class RoutineManager
    {
        static string workoutPath = Constants.WorkoutPath;
        static string exercisePath = Constants.ExercisePath;
        static string routinePath = Constants.RoutinePath;

        static string exercisesJson = File.ReadAllText(exercisePath);
        static List<Exercise> exercises = JsonSerializer.Deserialize<List<Exercise>>(exercisesJson);
        static Dictionary<int, Exercise> exerciseDictionary = exercises.ToDictionary(ex => ex.Id);

        static string workoutsJson = File.ReadAllText(workoutPath);
        static List<Workout> workouts = JsonSerializer.Deserialize<List<Workout>>(workoutsJson);
        static Dictionary<int, Workout> workoutDictionary = workouts.ToDictionary(w => w.Id);

        static string routinesJson = File.ReadAllText(routinePath);
        public static List<Routine> routines = JsonSerializer.Deserialize<List<Routine>>(routinesJson);
        public static Dictionary<int, Routine> routineDictionary = 
            routines.ToDictionary(r => r.Id);

        public static void SetRoutines()
        {
            foreach (var routine in routines)
            {
                routine.PopulateWorkouts(workoutDictionary);
            }
        }
        public static void SetWorkouts()
        {
            foreach (var workout in workouts)
            {
                workout.PopulateExercises(exerciseDictionary);
            }
        }

        // SetRoutines and SetWorkouts MUST BE initialized once app runs or before getting routines info.
    }
}
