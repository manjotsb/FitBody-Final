using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitBody.Models.RoutineModels
{
    public class Routine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<DayOfWeek, int> Schedule { get; set; }
        public Dictionary<DayOfWeek, Workout> WeeklyRoutine { get; set; }

        public Routine(int id, string name, Dictionary<DayOfWeek, int> schedule)
        {
            Id = id;
            Name = name;
            Schedule = schedule;
            WeeklyRoutine = new Dictionary<DayOfWeek, Workout>();
        }

        public void PopulateWorkouts(Dictionary<int, Workout> workoutDictionary)
        {
            foreach (var dayOfWeek in Schedule.Keys.ToList()) 
            {
                int workoutId = Schedule[dayOfWeek];
                if (workoutDictionary.ContainsKey(workoutId))
                {
                    WeeklyRoutine.Add(dayOfWeek, workoutDictionary[workoutId]);
                }
            }
        }
    }
}
