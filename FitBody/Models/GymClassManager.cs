using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitBody.Models
{
    public class GymClassManager
    {
        private SQLiteConnection _database;
        public GymClassManager()
        {
            _database = new SQLiteConnection(Constants.DbPath);

            _database.CreateTable<GymClass>();
        }

        public List<GymClass> GetAllClasses()
        {
            return _database.Table<GymClass>().ToList();
        }

        public void UpdateGymClass(GymClass gymClass)
        {
            _database.Update(gymClass);
        }

        public GymClass GetGymClass(string className)
        {
            GymClass gymClass = _database.Table<GymClass>().FirstOrDefault(gc => gc.Name == className);

            return gymClass;
        }
    }
}
