﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using SmartSaver.EntityFrameworkCore.Models;

namespace SmartSaver.Domain.ExtensionMethods
{
    public static class UserCheck
    {
        public static bool IsPasswordValid(this User user)
        {
            bool isValid = true;

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum5Chars = new Regex(@".{5,}");

            if (!(hasNumber.IsMatch(user.Password) 
                  && hasUpperChar.IsMatch(user.Password) 
                  && hasMinimum5Chars.IsMatch(user.Password)))
                isValid = false;

            return isValid;
        }
    }
}