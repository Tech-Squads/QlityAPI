using Qlity.Data;
using Qlity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Qlity.Controllers
{
    public class UserController : ApiController
    {
        DatabaseContext db = new DatabaseContext();



        [Route("UserLogon")]
        public User UserLogin(User u)
        {
            try
            {
               List<User> Users = db.Users.ToList();

                foreach (User user in Users)
                {
                   if(user.uEmail == u.uEmail && user.uPassword == u.uPassword)
                    {
                        return user;
                    } 
                }
                return null; 
            }
            catch (Exception)
            {

                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return null;
            }
        }



        [Route("api/User/GetUserByID/{id?}")]
        public User GetUserByID(int? id)
        {
            return db.Users.Find(id);
        }



        [Route("GetAllUsers")]
        public IEnumerable<User> GetAllUsers()
        {
            return db.Users.ToList();
        }

        [HttpPost]
        [Route("api/User/AddUser")]
        public HttpResponseMessage CreateUser(User u)
        {
            try
            {
                db.Users.Add(u);
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

        

        [HttpPost]
        [Route("api/User/AddRequestorProfile")]
        public HttpResponseMessage CreateUserRProfile(Profile pro)
        {
            pro.uEducation = "null";
            pro.uReferences = "null";
            pro.uSkills = "null";
            pro.uPastProjectDetails = "null";
            pro.uPastProjectDuration = "null";
            pro.uPastProjectName = "null";
            
            try
            {
                db.Profiles.Add(pro);
                db.SaveChanges();
                HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.Created) ;
                return resp;
            }
            catch (Exception)
            {
                HttpResponseMessage reps = new HttpResponseMessage(HttpStatusCode.InternalServerError);

                return reps;
            }
        }

        [HttpPost]
        [Route("api/User/AddGiggerProfile")]
        public HttpResponseMessage CreateUserGProfile(Profile pro)
        {
            pro.uCompany = "null";


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
        [Route ("api/User/UpdateUserProfile")]
        public HttpResponseMessage UpdateUserProfile(Profile pro)
        {
            try
            {
              
                    db.Entry(pro).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.OK);
                    return resp;
                
                 
            }
            catch (Exception)
            {
                HttpResponseMessage reps = new HttpResponseMessage(HttpStatusCode.InternalServerError);

                return reps;
            }
        }


        [HttpPut]
        [Route ("api/User/UpdateUser")]
        public HttpResponseMessage UpdateUser(User u)
        {
            try
            {
                
                    db.Entry(u).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.OK);
                    return resp;
                
                
            }
            catch (Exception)
            {
                HttpResponseMessage reps = new HttpResponseMessage(HttpStatusCode.InternalServerError);

                return reps;
            }
        }

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
