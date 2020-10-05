﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartSaver.Domain.Regex;
using SmartSaver.Domain.Services.PasswordEncryption;
using SmartSaver.EntityFrameworkCore;
using SmartSaver.EntityFrameworkCore.Models;

namespace SmartSaver.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : BasicAuthenticationService
    {
        private readonly IPasswordHasherService _hasher;
        private readonly IPasswordRegex _passwordRegex;
        private readonly ApplicationDbContext _context;

        public AuthenticationService()
        {
            _hasher = new PasswordHasherService();
            _passwordRegex = new PasswordRegex();
            _context = new ApplicationDbContext();
        }

        public override User Login(string username, string password)
        {
            User user = base.Login(username, password);
            if (user == null || !_hasher.Verify(password: password, passwordHash: user.Password))
            {
                return null;
            }

            return user;
        }

        public override RegistrationResult Register(User user)
        {
            if (!_passwordRegex.Match(user.Password))
            {
                return RegistrationResult.BadPasswordFormat;
            }

            if (_context.Users.FirstOrDefault(u => u.Username.Equals(user.Username)) != null)
            {
                return RegistrationResult.UserAlreadyExist;
            }

            user.Password = _hasher.Hash(user.Password);
            return base.Register(user);
        }
    }
}
