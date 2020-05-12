using JS.Fofana_Bank_V2._3_Backend.Contexts;
using JS.Fofana_Bank_V2._3_Backend.Exceptions;
using JS.Fofana_Bank_V2._3_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JS.Fofana_Bank_V2._3_Backend.Services
{
    public class UserService : IUserService
    {
        private readonly UserContext context;
        public UserService(UserContext iContext)
        {
            context = iContext;
        }

        public User addUser(User user)
        {
            throw new NotImplementedException();
        }

        public User authenticate(User user) 
        {
            User userSent = null;
            try
            {
                userSent = context.User.First(data => data.email == user.email);
                List<Account> accounts = context.Account.ToList()
                    .FindAll(data => data.user == userSent.id);
                userSent.accounts = accounts;
                return userSent;
            }
            catch (Exception e)
            {
                return userSent;
                throw new Exception("User not found");
            }
            
        }

        public List<User> getUsers()
        {
            List<User> users = context.User.ToList();
            List<Account> accounts = context.Account.ToList();
            foreach(User user in users)
            {
                user.accounts = accounts
                    .FindAll(data => data.user == user.id);
            }
            return users;
        }

        public User updateUser(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            foreach(Account account in user.accounts)
            {
                context.Entry(account).State = EntityState.Modified;
            }
            context.SaveChanges();
            return user;
        }
    }
}
