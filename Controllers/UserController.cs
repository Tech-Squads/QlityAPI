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

        [Route("api/User/GetUserByID/{id?}")]
        public User GetUserByID(int? id)
        {
            return db.Users.Find(id);
        }

        [Route("api/User/GetAllUsers")]
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

        [HttpGet]
        [Route("api/User/LoginUser")]
        public HttpResponseMessage LoginUser(string email,string password)
        {
            db.Users.SqlQuery("");
            HttpResponseMessage res = new HttpResponseMessage();
            return res;
        }

        [HttpPost]
        [Route("api/User/AddProfile")]
        public HttpResponseMessage CreateUserProfile(Profile pro)
        {
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

        [HttpPut]
        [Route ("api/User/UpdateUserProfile")]
        public HttpResponseMessage UpdateUserProfile(int id,Profile pro)
        {
            try
            {
              
                if (id == pro.UserID)
                {
                    db.Entry(pro).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.OK);
                    return resp;
                }
                else
                {
                    HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.NotModified);
                    return res;
                }
            }
            catch (Exception)
            {
                HttpResponseMessage reps = new HttpResponseMessage(HttpStatusCode.InternalServerError);

                return reps;
            }
        }


        [HttpPut]
        [Route ("api/User/UpdateUser")]
        public HttpResponseMessage UpdateUser(int id, User u)
        {
            try
            {
                if (id == u.UserID)
                {
                    db.Entry(u).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.OK);
                    return resp;
                }
                else
                {
                    HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.NotModified);
                    return res;
                }
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
