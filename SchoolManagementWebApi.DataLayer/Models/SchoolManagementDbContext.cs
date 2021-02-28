using Microsoft.EntityFrameworkCore;

namespace SchoolManagementWebApi.DataLayer.Models
{
    public class SchoolManagementDbContext : DbContext
    {
        public SchoolManagementDbContext(DbContextOptions<SchoolManagementDbContext> options) : base(options)
        {
        }

        public DbSet<SchoolModel> schools { get; set; }
        public DbSet<TeacherModel> teachers { get; set; }
        public DbSet<SubjectModel> subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolModel>().ToTable("School");
            modelBuilder.Entity<SubjectModel>().ToTable("Subject");
            modelBuilder.Entity<TeacherModel>().ToTable("Teacher");
        }
    }
}