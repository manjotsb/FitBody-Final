using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitBody.Models
{
    public class GymClass
    {
        [Required]
        [PrimaryKey]

        public string Name { get; set; }

        [Required]
        public string Instructor{ get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Level { get; set; }

        [Required]
        public int CurrentCapacity { get; set; }

        [Required]
        public int StartingTime { get; set; }

    }
}
