using _08_StatiClassExtensionMethodsExceptions.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Text;
using System.Xml.Linq;

namespace _08_StatiClassExtensionMethodsExceptions.Models
{
    internal class LoginSystem
    {
        private const int MaxAttempts = 3;
        private User[] _users;

        public User[] _Users
        {
            get
            {
                return _users;
            }

            set
            {
                if (value.Length == 3)
                {
                    _users = value;
                }
                else
                {
                    throw new Exception();
                }
            }

        }
        public LoginSystem(string user)
        {
            _users = new User[3];
            _users[0] = new User("admin", "admin123");
            _users[1] = new User("student", "student123");
            _users[2] = new User("teacher", "teacher123");

        }
        public void ValidateUsername(string username)
        {
            if (username.Length < 3 && !string.IsNullOrEmpty(username))
            {
                throw new InvalidUsernameException("Username yalnisdir!!");
            }


        }
        public void ValidatePassword(string password)
        {
            if (!string.IsNullOrEmpty(password) && password.Length < 6)
            {
                throw new InvalidPasswordException("Password yalnisdir!!");
            }
        }

        private User? FindUser(string username)
        {
            foreach (var user in _users)
            {
                if ((user.Username.ToLower() == username.ToLower()))
                {
                    Console.WriteLine();
                    return user;
                }

            }
            return null;
        }

        public bool Login(string username, string password)
        {
            ValidateUsername(username);
            ValidatePassword(password);
            var user = FindUser(username);
            if (user == null)
            {
                throw new UserNotFoundException("istifadeci tapilmadi!!");
            }
            if (user.IsLocked)
            {
                throw new AccountLockedException("Hesab bloklanib!!");
            }
            if (user.Password == password)
            {
                user.FailedAttempts = 0;
                Console.WriteLine($"Login successful! Welcome, {username}!");
                return true;
            }
            else
            {
                user.FailedAttempts++;
                int Maxattempts = 3;
                int attemptsLeft = MaxAttempts - user.FailedAttempts;

                if (attemptsLeft > 0)
                {
                    throw new IncorrectPasswordException("Sifre sehvdir!!");
                }
                else
                {
                    user.IsLocked = true;
                    throw new AccountLockedException("Hesab bloklandi!!");
                }
            }


        }
        public void ShowUser()
        {
            foreach (var user in _users)
            {
                Console.WriteLine("Movcud userler:"+user.Username);
            }
        }
    }
}