using Microsoft.EntityFrameworkCore;
using RazorIntroduction.TagHelpers.Web.Models;
using System;

namespace RazorIntroduction.TagHelpers.Web.DatabaseContexts
{
    public class UserDatabaseContext: DbContext
    {
        public UserDatabaseContext(DbContextOptions<UserDatabaseContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
