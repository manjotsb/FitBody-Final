using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Models.RoutineModels;
namespace FitBody.Models
{
    public class Customer
    {
        private string _username;
        private string _name;
        private string _email;
        private string _password;
        private int _age;
        private string _gender;
        private int _height;
        private int _weight;
        private int _userRoutineId;

        [Required]
        [PrimaryKey]
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        [Required]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        [Required]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        [Required]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        [Required]
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        [Required]
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        [Required]
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        [Required]
        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        [Required]
        public int UserRoutineId
        {
            get { return _userRoutineId; }
            set { _userRoutineId = value; }
        }

        public Customer()
        {
            
        }
        public Customer(string userName, string name, string email, string password)
        {
            Username = userName;
            Name = name;
            Email = email;
            Password = password;
        }
        public override string ToString()
        {
            return $"Username: {Username}, Name: {Name}, Email: {Email}, Age: {Age}, Gender: {Gender}, Height: {Height}, Weight: {Weight}";
        }
    }
}

