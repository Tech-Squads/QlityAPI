﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Qlity.Models
{
    //If you change this model or any other model ensure you use update-database in the PM console in order to update the database columns!

    public class User
    {
        public int UserID { get; set; }
        public string uEmail { get; set; }
        public string  uPassword { get; set; }
        public int uType { get; set; }
        public string FirstLogin { get; set; }
        public string HasGig { get; set; }

        public User(User u)
        {
            this.uEmail = u.uEmail;
            this.uPassword = u.uPassword;
        }
        public User()
        {
                
        }


    }
}