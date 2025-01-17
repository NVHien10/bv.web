﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Models;

namespace Hospital.ViewModels
{
    public class ApplicationUserViewModel
    {
        
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string City { get; set; }
        public Gender Gender { get; set; }
        public bool IsDoctor { get; set; }
        public string Specialist { get; set; }

        public ApplicationUserViewModel() { }
        public ApplicationUserViewModel (ApplicationUser user)
        {
            Name = user.Name;
            Email = user.Email;
            UserName = user.UserName;
            City = user.City;
            Gender = user.Gender;
            IsDoctor = user.IsDoctor;
            Specialist = user.Specialist;
        }
        public ApplicationUser ConVertViewModelToModel(ApplicationUserViewModel user)
        {
            return new ApplicationUser
            {
                Name = user.Name,
                City = user.City,
                Gender = user.Gender,
                IsDoctor = user.IsDoctor,
                Specialist = user.Specialist,
                Email = user.Email,
                UserName = user.UserName
            };

        }
        public List<ApplicationUser> Doctors { get; set; } = new List<ApplicationUser>();
    }
}
