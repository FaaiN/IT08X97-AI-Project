using System;
using System.Collections.Generic;

namespace agent
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public double Budget { get; set; }
        public DateTime DateCreated { get; set; }

        private ICollection<Session> Visits;


        public User() { }

        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
            DateCreated = DateTime.UtcNow;
            Visits = new List<Session>();
        }
        
        public void AddUserDetails(string Name, string Gender, DateTime DOB, double Budget)
        {
            this.Name = Name;
            this.Gender = Gender;
            this.DOB = DOB;
            this.Budget = Budget;
        }

        private void NewVisit(Session Visit)
        {
            Visits.Add(Visit); 
        }

        private void NewVisit()
        {
            Visits.Add(null);
        }
    }
}
