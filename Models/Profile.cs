using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Qlity.Models
{
    public class Profile
    {
        public int ProfileID { get; set; }
        public string GigIDs { get; set; }
        public string RespondIDs { get; set; }
        public string GiggerIDs { get; set; }

        public string GigTitle { get; set; }
        public string Proposed_solution { get; set; }
        public string Approach { get; set; }
        public string Timelines { get; set; }

        public string Respond_Status { get; set; }
        public string Date_Responded { get; set; }
        //public int userID { get; set; }
        //public string uName { get; set; }
        //public string uSurname { get; set; }
        //public string uCountry { get; set; }
        //public string uCompany { get; set; }
        //public string uEducation { get; set; }
        //public string uSkills  { get; set; }
        //public string uReferences { get; set; }
        //public string uPastProjectName { get; set; }
        //public string uPastProjectDuration { get; set; }
        //public string uPastProjectDetails { get; set; }



        public Profile(Profile pro)
        {
    


            this.GigIDs = pro.GigIDs;
            this.GigTitle = pro.GigTitle;
            this.RespondIDs = pro.RespondIDs;
            this.GiggerIDs = pro.GiggerIDs;
            this.Proposed_solution = pro.Proposed_solution;
            this.Approach = pro.Approach;
            this.Timelines = pro.Timelines;
            this.Date_Responded = pro.Date_Responded;
            this.Respond_Status = pro.Respond_Status;


        }
        public Profile()
        {

        }
    }
}