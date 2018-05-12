using Microsoft.EntityFrameworkCore;

namespace Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<RoomBooking> RoomBookings { get; set; }
    }
}
