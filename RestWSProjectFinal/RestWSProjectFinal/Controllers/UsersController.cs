//CSHP 330 A
//Christopher Davenport
//chrisd94

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestWSProjectFinal.Models;

namespace RestWSProjectFinal.Controllers
{
    public class UsersController : ApiController
    {

        List<User> users = new List<User>()
        {
            new User{id=1, name="Tim", email="Test1@email.com", password="98345"},
            new User{id=2, name="Mark", email="Test2@email.com", password="345345"},
            new User{id=3, name="Lisa", email="Test3@eamil.com", password="3244899"}
        };

        // GET: api/Users
        [HttpGet]

        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        // GET: api/Users/5
        [HttpGet]
        public IEnumerable<User> GetUserById(int id)
        {
            var Usr = from usr in GetUsers()
                      where usr.id.Equals(id)
                      select usr;
            return Usr.ToList<User>();
        }

        // POST: api/Users
        [HttpPost]
        public List<User> Post([FromBody] User user)
        {
            users.Add(user);
            return users;
        }

        // PUT: api/Users/5
        [HttpPut]
        public List<User> Put(int id, [FromBody] User user)
        {
            User userToUpdate = users.Find(f => f.id == id);
            int index = users.IndexOf(userToUpdate);

            users[index].id = user.id;
            users[index].name = user.name;
            users[index].email = user.email;
            users[index].password = user.password;
            return users;
        }

        // DELETE: api/Users/5
        [HttpDelete]
        public List<User> Delete(int id)
        {
            User user = users.Find(f => f.id == id);
            users.Remove(user);
            return users;
        }
    }
}
