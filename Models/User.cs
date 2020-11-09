using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Qlity.Models
{
    //If you change this model or any other model ensure you use update-database in the PM console in order to update the database columns!

    public class User
    {
        public string uEmail { get; set; }
        public string  uPassword { get; set; }
        public int UserID { get; set; }
        public int uType { get; set; }
        public string FirstLogin { get; set; }

        public User()
        {

        }

        public User(User u)
        {
            this.UserID = u.UserID;
            this.uEmail = u.uEmail;
            this.uPassword = u.uPassword;
            this.FirstLogin = u.FirstLogin;
            this.uType = u.uType;
            
        }
    }
}