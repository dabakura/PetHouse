using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetHouse.MVC.Models
{
    public class UsersInRoleModel
    {
        public UsersInRoleModel()
        {
            EnrolledUsers = new List<string>();
            RemovedUsers = new List<string>();
        }

        public UsersInRoleModel(string id)
        {
            Id = id;
            EnrolledUsers = new List<string>();
            RemovedUsers = new List<string>();
        }

        public string Id { get; set; }
        public List<string> EnrolledUsers { get; set; }
        public List<string> RemovedUsers { get; set; }
    }
}