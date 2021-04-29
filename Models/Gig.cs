using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Qlity.Models
{
    public class Gig
    {
        public int GigID { get; set; }
        public string GigTitle { get; set; }
        public string DueDate { get; set; }
        public string GigDescription { get; set; }
        public string RequiredSkills { get; set; }
        public string DescriptionGig { get; set; }
        public int RequestorID { get; set; }

        public string Gig_Status { get; set; }
        public string Date_Gigmodified { get; set; }

        //responde models
        public string Proposed_solution { get; set; }
        public string Approach { get; set; }
        public string Timelines { get; set; }

        public string Initial_GigID { get; set; }
        public string GiggerIDs { get; set; }
        public string Date_Responded { get; set; }
        public string Commercial { get; set; }

       

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public string cell_number { get; set; }


        public Gig()
        {

        }

        public Gig(Gig gig)
        {
            this.GigID = gig.GigID;
            this.GigTitle = gig.GigTitle;
            this.RequestorID = gig.RequestorID;
            this.GigDescription = gig.GigDescription;
            this.DescriptionGig = gig.DescriptionGig;
            this.RequiredSkills = gig.RequiredSkills;

            this.Gig_Status = gig.Gig_Status;
            this.Date_Gigmodified = gig.Date_Gigmodified;


            this.Proposed_solution = gig.Proposed_solution;
            this.Approach = gig.Approach;
            this.Timelines = gig.Timelines;
            this.Initial_GigID = gig.Initial_GigID;
            this.GiggerIDs = gig.GiggerIDs;
            this.Date_Responded = gig.Date_Responded;
            this.Commercial = gig.Commercial;

            this.Name = gig.Name;
            this.Surname = gig.Surname;
            this.Email = gig.Email;
            this.cell_number = gig.cell_number;

        }

    }
}




