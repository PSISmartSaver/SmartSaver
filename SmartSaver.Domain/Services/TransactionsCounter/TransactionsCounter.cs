﻿using System;
using System.Collections.Generic;
using System.Linq;
using SmartSaver.EntityFrameworkCore.Models;

namespace SmartSaver.Domain.Services.TransactionsCounter
{
    public static class TransactionsCounter
    {
        public static IEnumerable<Transaction> FilterAccount(IEnumerable<Transaction> transactions, DateTime from, DateTime to)
        {
             return transactions.Where(t => InRange(t.ActionTime, from, to));
        }

        public static double TotalExpense(IEnumerable<Transaction> transaction, DateTime from, DateTime to)
        {
            return Math.Round(transaction.Where(t => t.Amount < 0 && InRange(t.ActionTime, from, to)).Sum(c => c.Amount), 2);
        }

        public static double TotalIncome(IEnumerable<Transaction> transaction, DateTime from, DateTime to)
        {
            return Math.Round(transaction.Where(t => t.Amount > 0 && InRange(t.ActionTime, from, to)).Sum(c => c.Amount), 2);
        }

        public static double SavedSum(IEnumerable<Transaction> transaction, DateTime from, DateTime to)
        {
            return Math.Round(TotalIncome(transaction, from, to) + TotalExpense(transaction, from, to), 2);
        }

        public static Dictionary<int, double> TotalIncomeByCategory(IEnumerable<Transaction> transaction, DateTime from, DateTime to)
        {
            return transaction.GroupBy(t => new { t.CategoryId, t.ActionTime }).Select(x => new Transaction
            {
                Amount = x.Where(x => x.Amount > 0).Sum(y => y.Amount),
                CategoryId = x.Key.CategoryId,
                ActionTime = x.Key.ActionTime
            }).Where(x => x.Amount > 0 && InRange(x.ActionTime, from, to)).GroupBy(x => x.CategoryId).Select(z => new Transaction
            {
                Amount = z.Where(z => z.Amount > 0).Select(z => z.Amount).Sum(),
                CategoryId = z.Select(z => z.CategoryId).First()
            }
            ).OrderBy(x => x.CategoryId).ToDictionary(x => x.CategoryId, x => x.Amount);
        }

        public static Dictionary<int, double> TotalExpenseByCategory(IEnumerable<Transaction> transaction, DateTime from, DateTime to)
        {
            return transaction.GroupBy(t => new { t.CategoryId, t.ActionTime }).Select(x => new Transaction
            {
                Amount = x.Where(x => x.Amount < 0).Select(x => x.Amount).Sum(),
                CategoryId = x.Key.CategoryId,
                ActionTime = x.Key.ActionTime
            }).Where(x => x.Amount < 0 && InRange(x.ActionTime, from, to)).GroupBy(x => x.CategoryId).Select(z => new Transaction
            {
                Amount = z.Where(z => z.Amount < 0).Select(z => z.Amount).Sum(),
                CategoryId = z.Select(z => z.CategoryId).First()
            }
            ).OrderBy(z => z.CategoryId).ToDictionary(x => x.CategoryId, x => x.Amount);
        }

        private static bool InRange(DateTime dateToCheck, DateTime startDate, DateTime endDate)
        {
            return dateToCheck >= startDate && dateToCheck < endDate;
        }
    } 
}