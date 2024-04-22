using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitBody.Models.RoutineModels
{
    public class Exercise
    {
        public int Id { get; set; } // Unique identifier for the exercise
        public string Name { get; set; } // Name of the exercise (e.g., "Running", "Weightlifting")
        public string Equipment { get; set; } // Equipment needed for the exercise (e.g., "Treadmill", "Dumbbells")
        public string Repetitions { get; set; } // Number of repetitions
        public string MuscleGroup { get; set; } // Primary muscle group targeted by the exercise

        public Exercise(int id, string name, string equipment, string repetitions, string muscleGroup)
        {
            Id = id;
            Name = name;
            Equipment = equipment;
            Repetitions = repetitions;
            MuscleGroup = muscleGroup;
        }
    }
}
