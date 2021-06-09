using Moj.DataImporter.Contracts.Data;
using Moj.DataImporter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moj.DataImporter.Data;

namespace Moj.DataImporter.Business
{
    public class CategoryHandler : ICategoryHandler
    {
        private readonly ApplicationDbContext context;

        public CategoryHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Category>> GetAllCategories()
        {
            return await context.Categories.ToListAsync();
        }
    }
}
