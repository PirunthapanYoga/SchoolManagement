using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<ClassRoom> ClassRooms { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Subject> Subjects { get; set; }
        
        public DbSet<Teacher> Teachers { get; set; }

    }

}