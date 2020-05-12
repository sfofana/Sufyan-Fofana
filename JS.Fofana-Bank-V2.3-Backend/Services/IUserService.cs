using JS.Fofana_Bank_V2._3_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JS.Fofana_Bank_V2._3_Backend.Services
{
    public interface IUserService
    {
        List<User> getUsers();
        User authenticate(User user);
        User addUser(User user);
        User updateUser(User user);
    }
}
