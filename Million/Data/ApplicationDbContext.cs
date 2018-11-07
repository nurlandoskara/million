using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Million.Models;

namespace Million.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuestionScope> QuestionScopes { get; set; }
        public new DbSet<User> Users { get; set; }
        public DbSet<UserMoney> UserMoneys { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
    }
}
