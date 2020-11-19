using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Qlity.Models
{
    public class Profile
    {
        public int ProfileID { get; set; }
        public int userID { get; set; }
        public string uName { get; set; }
        public string uSurname { get; set; }
        public string uCountry { get; set; }
        public string uCompany { get; set; }
        public string uEducation { get; set; }
        public string uSkills  { get; set; }
        public string uReferences { get; set; }
        public string uPastProjectName { get; set; }
        public string uPastProjectDuration { get; set; }
        public string uPastProjectDetails { get; set; }
     
        

        public Profile(Profile pro)
        {
            this.uName = pro.uName;
            this.uSurname = pro.uSurname;
            this.uCountry = pro.uCountry;
            this.uCompany = pro.uCompany;
            this.uEducation = pro.uEducation;
            this.uSkills = pro.uSkills;
            this.uReferences = pro.uReferences;
            this.uPastProjectName = pro.uPastProjectName;
            this.uPastProjectDuration = pro.uPastProjectDuration;
            this.uPastProjectDetails = pro.uPastProjectDetails;
            this.userID = pro.userID;


        }
        public Profile()
        {

        }
    }
}