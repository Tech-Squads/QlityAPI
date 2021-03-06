﻿using Qlity.Data;
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
        public User UserLogins( string Upassword)
        {
            try
            {
                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
                var LoggedUser = db.Users.Where(us =>  us.uPassword == Upassword).FirstOrDefault<User>();
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


        [Route("GetUserProfile/{id?}")]
        public Profile GetProfileByID(int? id)
        {
            var profi = db.Profiles.Where(p => p.userID == id).FirstOrDefault<Profile>();
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


        //Update gig


        [HttpPut]
        [Route("Updategig/{id}")]
        public HttpResponseMessage UpdateUserProfile(int id, Gig gig)
        {
            try
            {
                if (id == gig.GigID)
                {
                    db.Entry(gig).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.OK);
                    return resp;
                }
                HttpResponseMessage r = new HttpResponseMessage(HttpStatusCode.NotModified);
                return r;
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
        public HttpResponseMessage UpdateUserProfile(int id, Profile pro)
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
                HttpResponseMessage r = new HttpResponseMessage(HttpStatusCode.NotModified);
                return r;
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
