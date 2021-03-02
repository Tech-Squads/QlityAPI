using Qlity.Data;
using Qlity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace Qlity.Controllers
{
    public class UserController : ApiController
    {
        DatabaseContext db = new DatabaseContext();


        public class utils
        {
            public static string HashThis(string passW)
            {
                SHA256CryptoServiceProvider sha2 = new SHA256CryptoServiceProvider();

                byte[] pssw_bytes = Encoding.ASCII.GetBytes(passW);
                byte[] encr_bytes = sha2.ComputeHash(pssw_bytes);

                return Convert.ToBase64String(encr_bytes);

            }

        }



        //for getting  all users name that start with specific letter


        [Route("GetA")]
        public IEnumerable<Profile> GetA()
        {
            return db.Profiles.ToList();
        }





    






    //for getting  all users name that start with specific number 

    [Route("GetFirstletter/{id?}")]
        public IEnumerable<User> GetFirs(int? id)
        {
          try { 

                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
                    return db.Users.Where(us => us.uType==id || id == null).ToList();
                    
           }
            catch (Exception)
            {

                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return null;
            }
        }









        //for getting  all users name that start with specific letter

        [Route("Getskillscontains/{skills?}")]
        public IEnumerable<User> GetFir(string skills)
        {
            try
            {

                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
                return db.Users.Where(us => us.uRequiredSkills.Contains(skills) || skills == null).ToList();

            }
            catch (Exception)
            {

                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return null;
            }
        }

        //for getting  all users that are new contains [status ="new"]

        [Route("Getnewgigrunning")]
        public IEnumerable<User> Getnewgigrunning(string skills="New")
        {
            try
            {

                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
                return db.Users.Where(us => us.uStatusGigs.Contains(skills)).ToList();

            }
            catch (Exception)
            {

                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return null;
            }
        }



        //for getting  users that contain [HasGig ="True"]

        [Route("Gettingallgigs")]
        public IEnumerable<User> GetAllGigs(string skills = "True")
        {
            try
            {

                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
                return db.Users.Where(us => us.HasGig.Contains(skills)).ToList();

            }
            catch (Exception)
            {

                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return null;
            }
        }

        //for getting  all users that contains your skills

        [Route("Getnumbercontains/{number?}")]
        public IEnumerable<User> GetFidate(string number)
        {
            try
            {
              
                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
                return db.Users.Where(us => us.uRequiredSkills.Contains(number) || number == null).ToList();

            }
            catch (Exception)
            {

                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return null;
            }
        }



        [HttpGet]
        [Route("UserLogon")]
        public User UserLogin(string Uemail, string Upassword)
        {
            try
            {
                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
                var LoggedUser = db.Users.Where(us => us.uEmail == Uemail && us.uPassword == Upassword).FirstOrDefault<User>();
                if (LoggedUser != null)
                {
                    return LoggedUser;
                }
                return null;
            }

            catch (Exception)
            {

                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return null;
            }
        }
        //for google login and search email on database for reset password

        [HttpGet]
        [Route("UserLogongoogle")]
        public User UserLogingin(string Uemail)
        {
            try
            {
                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
                var LoggedUser = db.Users.Where(us => us.uEmail == Uemail).FirstOrDefault<User>();
                if (LoggedUser != null)
                {
                    return LoggedUser;
                }
                return null;
            }

            catch (Exception)
            {

                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return null;
            }
        }


        //for password for reset password
        [HttpGet]
        [Route("UserLogonPass")]
        public User UserLogins(string Upassword)
        {
            try
            {
                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
                var LoggedUser = db.Users.Where(us => us.uPassword == Upassword).FirstOrDefault<User>();
                if (LoggedUser != null)
                {
                    return LoggedUser;
                }
                return null;
            }

            catch (Exception)
            {

                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return null;
            }
        }





        [HttpGet]
        [Route("GetUser")]
        public User UserGet(string Uemail, string Upassword)
        {
            try
            {
                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
                var LoggedUser = db.Users.Where(us => us.uEmail == Uemail && us.uPassword == Upassword).FirstOrDefault<User>();
                if (LoggedUser != null)
                {
                    return null;
                }
                return LoggedUser;
            }

            catch (Exception)
            {

                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return null;
            }
        }



        [HttpGet]
        [Route("Login")]
        public bool ULogin(string Uemail, string Upassword)
        {
            try
            {
                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);

                var LoggedUser = db.Users.Where(us => us.uEmail == Uemail && us.uPassword == Upassword).FirstOrDefault<User>();
                if (LoggedUser != null)
                {
                    return true;
                }
                return false;
            }

            catch (Exception)
            {
                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return false;
            }
        }



        [Route("GetUserByID/{id?}")]
        public User GetUserByID(int? id)
        {
            return db.Users.Find(id);
        }

        //Getting user profile by id
        [Route("GetUserProfilebyId/{id?}")]
        public Profile GetUserProfilebyId(int? id)
        {
            return db.Profiles.Find(id);
        }


        //get Requestorbyid
        [Route("GetRequestorByID/{id?}")]
        public Gig GetRequestorByID(int? id)
        {
            return db.Gigs.Find(id);
        }


        [Route("GetUserProfile/{id?}")]
        public Profile GetProfileByID(int? id)
        {
            var profi = db.Profiles.Where(p => p.userID == id).FirstOrDefault<Profile>();
            return profi;
        }



        //get user profiles
        [Route("GetUserPro/{id?}")]
        public User GetUser(int? id)
        {
            var profi = db.Users.Where(p => p.UserID == id).FirstOrDefault<User>();
            return profi;
        }


        [Route("GetGigByID/{id?}")]
        public Gig GetGigByID(int? id)
        {
            return db.Gigs.Find(id);
        }


        [Route("GetAllUsers")]
        public IEnumerable<User> GetAllUsers()
        {
            return db.Users.ToList();
        }

        [Route("GetAllU")]
        public IQueryable<User> GetAllU()
        {
            return db.Users;
        }



        [Route("GetAllGigs")]
        public IEnumerable<Gig> GetAllGigs()
        {
            return db.Gigs.ToList();
        }


        [HttpPost]
        [Route("AddUser")]
        public HttpResponseMessage CreateUser(User u)
        {

            try
            {
               

                var user = db.Users.Where(p => p.uEmail == u.uEmail).FirstOrDefault<User>();

                if (user == null)
                {
                    
                    db.Users.Add(u);
                    db.SaveChanges();
                    HttpResponseMessage respon = new HttpResponseMessage(HttpStatusCode.Created);
                    return respon;
                }
                HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return resp;
            }
            catch (Exception)
            {
                HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return resp;
            }
        }

        [HttpPost]
        [Route("AddGig")]
        public HttpResponseMessage CreateGig(Gig g)
        {
            try
            {
                db.Gigs.Add(g);
                db.SaveChanges();
                HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.Created);
                return resp;
            }
            catch (Exception)
            {
                HttpResponseMessage reps = new HttpResponseMessage(HttpStatusCode.InternalServerError);

                return reps;
            }
        }
        //updateGig
        [HttpPut]
        [Route("UpdateGig/{id}")]
        public HttpResponseMessage UpdateGig(int id, Gig updategig)
        {
            try
            {
                if (id == updategig.RequestorID)
                {
                    db.Entry(updategig).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.OK);
                    return resp;
                }
                else
                {
                    HttpResponseMessage r = new HttpResponseMessage(HttpStatusCode.NotModified);
                    return r;
                }

            }
            catch (Exception)
            {
                HttpResponseMessage reps = new HttpResponseMessage(HttpStatusCode.InternalServerError);

                return reps;
            }
        }

        [Route("AddProfile")]
        public HttpResponseMessage CreateUProfile(Profile pro)
        {
            try
            {
                db.Profiles.Add(pro);
                db.SaveChanges();
                HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.Created);
                return resp;
            }
            catch (Exception)
            {
                HttpResponseMessage reps = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return reps;
            }
        }



        [HttpPut]
        [Route("UpdateUProfile/{id}")]
        public HttpResponseMessage UpdateUProfile(int id, Profile pro)
        {
            try
            {
                if (id == pro.userID)
                {
                    db.Entry(pro).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.OK);
                    return resp;
                }
                else
                {
                    HttpResponseMessage r = new HttpResponseMessage(HttpStatusCode.NotModified);
                    return r;
                }
            }
            catch (Exception)
            {
                HttpResponseMessage reps = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return reps;
            }
        }


        [HttpPut]
        [Route("UpdateUser/{id}")]
        public HttpResponseMessage UpdateUser(int id, User updateUser)
        {
            try
            {
                if (id == updateUser.UserID)
                {
                    db.Entry(updateUser).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.OK);
                    return resp;
                }
                else
                {
                    HttpResponseMessage r = new HttpResponseMessage(HttpStatusCode.NotModified);
                    return r;
                }

            }
            catch (Exception)
            {
                HttpResponseMessage reps = new HttpResponseMessage(HttpStatusCode.InternalServerError);

                return reps;
            }
        }


        //[Route("Emailsend")]

        //public HttpResponseMessage Emailsend(EmailClass u)
        //{
        //    try 
        //    {
        //    string subject = u.subject;
        //    string body = u.body;
        //    string to = u.to;
        //    MailMessage mm = new MailMessage();
        //    mm.From = new MailAddress("joretogeorg@gmail.com");
        //    mm.To.Add(to);
        //    mm.Subject = subject;
        //    mm.Body = body;
        //    mm.IsBodyHtml = false;
        //    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
        //    smtp.UseDefaultCredentials = true;
        //    smtp.Port = 587;
        //    smtp.EnableSsl = true;
        //    smtp.Credentials = new System.Net.NetworkCredential("joretogeorg@gmail.com", "Ubi0789!");
        //    smtp.Send(mm);
        //     HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
        //            return res;
        //    }
        //    catch (Exception)
        //    {
        //        HttpResponseMessage Badresponse = new HttpResponseMessage(HttpStatusCode.NotFound);
        //        return Badresponse;

        //    }

        //}
        public HttpResponseMessage DeleteUser(int id)
        {
            try
            {
                User user = db.Users.Find(id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
                    return res;
                }
                else
                {
                    HttpResponseMessage Badresponse = new HttpResponseMessage(HttpStatusCode.NotFound);
                    return Badresponse;
                }
            }
            catch (Exception)
            {
                HttpResponseMessage Badresponse = new HttpResponseMessage(HttpStatusCode.NotFound);
                return Badresponse;

            }
        }


    }
}
