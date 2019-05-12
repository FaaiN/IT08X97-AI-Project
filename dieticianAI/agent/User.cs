using System;
using System.Collections.Generic;

namespace agent
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public double Budget { get; set; }
        public DateTime DateCreated { get; set; }

        private ICollection<Session> Visits;

    }
}
