using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitBody.Models
{
    public static class Constants
    {
        

        public const string DatabaseFile = "Database\\FitBodyDB.db";

        public static string DbPath =>
         Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
         @"..\..\..\..\..\", DatabaseFile);

        static string RoutineFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\", @"..\", @"..\", @"..\", @"..\", @"Resources\", @"Raw\", @"Routines.json");
        public static string RoutinePath = Path.GetFullPath(RoutineFile);

        static string WorkoutFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\", @"..\", @"..\", @"..\", @"..\", @"Resources\", @"Raw\", @"Workouts.json");
        public static string WorkoutPath = Path.GetFullPath(WorkoutFile);

        static string ExerciseFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\", @"..\", @"..\", @"..\", @"..\", @"Resources\", @"Raw\", @"Exercises.json");
        public static string ExercisePath = Path.GetFullPath(ExerciseFile);
    }
}
