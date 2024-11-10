using System;
using System.Collections.Generic;
using System.Linq;
using SajaProjectV2.Factory;
using SajaProjectV2.Model;

namespace SajaProjectV2.Controller
{
    class CmdUsers
    {
        Repository<CLS_Users> cmd = new Repository<CLS_Users>();

        // Get all users from the Users table
        public List<CLS_Users> GetAllUsers()
        {
            try
            {
                return cmd.GetAll("SELECT Id, UserName, Password, Role FROM users").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<CLS_Users> GetUserByNameAndPass(string username,string password)
        {
            try
            {
                return cmd.GetAll($"SELECT Id, UserName, Password, Role FROM users Where UserName = '{username}' and Password = '{password}'").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Add a new user
        public void AddUser(CLS_Users user)
        {
            try
            {
                // Insert new user into Users table

                cmd.ExecuteParam($"INSERT INTO users (Id, UserName, Password, Role) VALUES (@Id, @UserName, @Password, @Role)", user);
            }
            catch (Exception e)
            {
                throw e;
            }



        }

        // Edit an existing user
        public bool EditUser(CLS_Users user)
        {
            try
            {
                // Update user details
                cmd.ExecuteParam("UPDATE users SET UserName = @UserName, Password = @Password, Role = @Role WHERE Id = @Id", user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Remove a user by ID
        public bool RemoveUser(int userId)
        {
            try
            {
                cmd.ExecuteParam("DELETE FROM users WHERE Id = @Id", new CLS_Users { Id = userId });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Get a new user ID (increments by 1 from the max Id)
        public int getNewId()
        {
            List<CLS_Users> users = cmd.GetAll("SELECT Id FROM users WHERE Id = (SELECT MAX(Id) FROM users)").ToList();
            if (users.Count > 0)
            {
                return users[0].Id + 1;
            }
            return 1;
        }
    }
}
