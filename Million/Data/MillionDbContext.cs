using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Million.Models;

namespace Million.Data
{
    public class MillionDbContext: DbContext
    {
        public MillionDbContext(DbContextOptions<MillionDbContext> options)
            : base(options)
        {

        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuestionRating> QuestionRatings { get; set; }
        public DbSet<QuestionScope> QuestionScopes { get; set; }
        public new DbSet<User> Users { get; set; }
        public DbSet<UserMoney> UserMoneys { get; set; }
    }
}
