using MyAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyAppApi.Controllers
{
    public class DemoController : ApiController
    {
        private employeeEntities1 db = new employeeEntities1();

        //returns all user details

        [HttpGet]
        public List<UserDetail> GetAllUser()
        {
            return db.UserDetails.ToList();
        }

        //get userdetail by id
        [HttpGet]
        public UserDetail GetUserById(int id)
        {
            return db.UserDetails.Find(id);
        }

        [HttpPost]
        public string AddUser(UserDetail user)
        {
            if(user != null && !string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.City) && !string.IsNullOrEmpty(user.Age))
            {
                db.UserDetails.Add(user);
                db.SaveChanges();
                return "User details added successfully";
                /*int UserId = db.UserDetails.OrderByDescending(x => x.Id).First().Id;
                return UserId;*/
            }
            else
            {
                return "Please enter proper details";
            }
        }
        [HttpPut]
        public string UpdateUser(int id,UserDetail user)
        {
            if(id > 0 && user != null && !string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.City) && !string.IsNullOrEmpty(user.Age))
            {
                UserDetail uDetail = db.UserDetails.Find(id);
                uDetail.Name = user.Name;
                uDetail.City = user.City;
                uDetail.Age = user.Age;
                db.SaveChanges();
                return "User detail Updated!!";
            }
            else
            {
                return "Please enter proper details";
            }
        }
        [HttpDelete]
        public string DeleteUser(int id)
        {
            if(id > 0)
            {
                UserDetail uDetail = db.UserDetails.Find(id);
                db.UserDetails.Remove(uDetail);
                db.SaveChanges();
                return "User details removed successfully";
            }
            else
            {
                return "please enter proper details";
            }
 
        }
        
    }
}
