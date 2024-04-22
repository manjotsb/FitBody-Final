using Microsoft.VisualBasic;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitBody.Models
{
    public class EmployeeManager
    {
        private SQLiteConnection _database;

        public EmployeeManager()
        {
            _database = new SQLiteConnection(Constants.DbPath);

            _database.CreateTable<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            _database.Insert(employee);
        }



        public List<Employee> GetAllEmployes()
        {
            return _database.Table<Employee>().ToList();
        }

        public void DropAllEmployee()
        {
            _database.DropTable<Employee>();
        }

        public bool IsEmployee(string empEmail, string empPasswprd)
        {
            var employee = _database.Table<Employee>().FirstOrDefault(e => e.Email == empEmail);


            if (employee == null)
            {
                Debug.WriteLine("Employee doesn't exist");
                return false;
            }

            else if (employee.Password == empPasswprd)
            {
                Debug.WriteLine("Found");
                return true;
            }
            else
            {
                Debug.WriteLine("Incorrect Password");
                return false;
            }
        }
    }
}
