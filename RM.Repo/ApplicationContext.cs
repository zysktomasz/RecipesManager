using Microsoft.EntityFrameworkCore;
using RM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Repo
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

    }
}
