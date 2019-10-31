using System.Collections.Generic;
using System.Linq;
using WebApı.Interfaces;

namespace WebApı
{
    public class Repository : IRepository
    {
        readonly XContext _xcontext;

        public Repository(XContext xcontext)
        {
            _xcontext = xcontext;
        }

        public bool Delete(int id)
        {
            bool result = false;
            var user = Find(id);
            if( user != null)
            {
                _xcontext.Users.Remove(user);
                _xcontext.SaveChanges();
                result = true;
            }
                return result;
        }

        public User Find(int id)
        {
            return _xcontext.Users.Find(id);
        }

        public User FindUser(string username)
        {
            return _xcontext.Users.FirstOrDefault(s => s.username == username);
        }

        public User Insert(User user)
        {
            _xcontext.Users.Add(user);
            _xcontext.SaveChanges();
            return user;
        }

        public List<User> List()
        {
             return _xcontext.Users.ToList();
        }

        public User Update(User user)
        {
            _xcontext.Users.Update(user);
            _xcontext.SaveChanges();
            return user;
        }

    }
}
