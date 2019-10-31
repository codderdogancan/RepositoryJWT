
using System.Collections.Generic;


namespace WebApı.Interfaces
{
    public interface IRepository
    {
        List<User> List(); // bütün kayıtları listelemek için IEnumerable kullanılır.
        User Insert(User user);
        User Update(User user);
        User Find(int id);
        User FindUser(string username);
        bool Delete(int id);
    }
}
