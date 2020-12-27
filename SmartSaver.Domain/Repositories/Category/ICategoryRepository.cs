﻿using System;
using System.Collections.Generic;
using SmartSaver.EntityFrameworkCore.Models;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartSaver.Domain.Repositories
{
    public enum CreateCategoryResponse
    {
        Success,
        BadRequest
    }

    public interface ICategoryRepository
    {
        IEnumerable<Category> GetMultiple();
        IEnumerable<Category> GetMultiple(Expression<Func<Category, bool>> predicate);
        Category GetSingle(Expression<Func<Category, bool>> predicate);
        Task<int> CreateAsync(Category category);
    }
}
