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
        public string GigDescription { get; set; }
        public string RequiredSkills { get; set; }
        public string ContactDetails { get; set; }
        public int RequestorID { get; set; }


        public Gig()
        {

        }

        public Gig(Gig gig)
        {
            this.GigID = gig.GigID;
            this.GigTitle = gig.GigTitle;
            this.RequestorID = gig.RequestorID;
            this.GigDescription = gig.GigDescription;
            this.ContactDetails = gig.ContactDetails;
            this.RequiredSkills = gig.RequiredSkills;
        }
    }
}