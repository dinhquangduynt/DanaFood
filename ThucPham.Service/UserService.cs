using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucPham.Model.Models;

namespace ThucPham.Service
{
    public interface IUserService {
        IEnumerable<User> GetAll();
        User GetById(string id);
    }

    public class UserService
    {
    }
}
