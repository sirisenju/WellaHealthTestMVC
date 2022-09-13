using Microsoft.EntityFrameworkCore;
using wellaTestApp.Models;


namespace wellaTestApp.DbModels
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UserModel> StudentDatas { get; set; }

    }
}
