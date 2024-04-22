using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitBody.Models.RoutineModels
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public List<Exercise> Exercises { get; set; }
        public List<int> ExerciseIds { get; set; }
        public string Category { get; set; }

        public Workout(int id, string name, string difficulty, List<int> exerciseIds, string category)
        {
            Id = id;
            Name = name;
            Difficulty = difficulty;
            ExerciseIds = exerciseIds;
            Exercises = new List<Exercise>();
            Category = category;
        }

        public void PopulateExercises(Dictionary<int, Exercise> exerciseDictionary)
        {
            foreach (var exerciseId in ExerciseIds)
            {
                if (exerciseDictionary.ContainsKey(exerciseId))
                {
                    Exercises.Add(exerciseDictionary[exerciseId]);
                }
            }
        }
    }
}
