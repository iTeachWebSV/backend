using Microsoft.EntityFrameworkCore;
using ModuleItem;
using UsersItem;
using EnrollmentItem;
using ClassItem;
using TaskItem;
namespace Especialidad.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<ModuleItems>? ModuleItem { get; set; }
        public DbSet<UserItems>? UserItem { get; set; }
        public DbSet<EnrollmentItems>? EnrollmentItem { get; set; }
        public DbSet<ClassItems>? ClassItem { get; set; }
        public DbSet<TaskItems>? TaskItem { get; set; }
    }
}