/***************************************************
    DeviceContext.cs

    Isaac Walker
****************************************************/

using Microsoft.EntityFrameworkCore;


namespace Web.Iot.DeviceService.Devices
{
    /// <summary>
    /// Database Context for the devices
    /// </summary>
    public class DeviceContext : DbContext
    {
        /// <summary>
        /// Devices in the context
        /// </summary>
        public DbSet<Device> Devices { get; set; }


        public DeviceContext(DbContextOptions<DeviceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>()
                .HasKey(D => D.MacAddress);
        }
    }
}
