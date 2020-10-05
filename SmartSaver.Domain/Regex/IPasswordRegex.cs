﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSaver.Domain.Regex
{
    interface IPasswordRegex
    {
        /// <summary>
        /// Checks if given password is great format.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        bool Match(string password);
    }
}
