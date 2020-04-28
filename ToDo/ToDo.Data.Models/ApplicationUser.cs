using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        //var user = new ApplicationUser
        //{
        //    UserName = Input.Email,
        //    Email = Input.Email,
        //    EmailConfirmed = true,
        //    Age = Input.Age,
        //    FirstName = Input.FirstName,
        //    LastName = Input.LastName,
        //    Gender = Input.Gender,
        //    CityId = Input.CityId
        //};

        public ApplicationUser()
        {
            this.Notes = new HashSet<Note>();

            this.SentMessages = new HashSet<Message>();

            this.ReceivedMessages = new HashSet<Message>();
        }

        public int Age { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public ICollection<Note> Notes { get; set; }

        public ICollection<Message> SentMessages { get; set; }

        public ICollection<Message> ReceivedMessages { get; set; }
    }
}
