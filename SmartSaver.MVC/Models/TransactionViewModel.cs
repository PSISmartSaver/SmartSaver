﻿using System.Collections.Generic;
using SmartSaver.EntityFrameworkCore.Models;

namespace SmartSaver.MVC.Models
{
    public class TransactionViewModel
    {
        public List<Transaction> Transactions { get; set; }
        public List<Category> Categories { get; set; }
    }
}
