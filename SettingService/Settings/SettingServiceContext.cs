/***************************************************
    SettingServiceContext.cs

    Isaac Walker
****************************************************/

using Microsoft.EntityFrameworkCore;

namespace Web.Iot.SettingService.Settings
{
    /// <summary>
    /// DB Context of the Settings and their Entries
    /// </summary>
    public class SettingServiceContext : DbContext
    {
        /// <summary>
        /// Settings, which can be related to multiple setting entries
        /// </summary>
        public DbSet<Setting> Settings { get; set; }


        /// <summary>
        /// An set of settings
        /// </summary>
        public DbSet<Configuration> Configurations { get; set; }


        /// <summary>
        /// Junction table for Settings - SettingsEntry many-to-many relationship
        /// </summary>
        public DbSet<ConfigurationSetting> ConfigurationSettings { get; set; }


        public SettingServiceContext(DbContextOptions<SettingServiceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfigurationSetting>()
                .HasKey(cs =>  new { cs.SettingId, cs.ConfigurationId });

            modelBuilder.Entity<ConfigurationSetting>()
                .HasOne(cs => cs.Setting)
                .WithMany(cs => cs.ConfigurationSettings)
                .HasForeignKey(cs => cs.SettingId);

            modelBuilder.Entity<ConfigurationSetting>()
                .HasOne(cs => cs.Configuration)
                .WithMany(cs => cs.ConfigurationSettings)
                .HasForeignKey(cs => cs.ConfigurationId);
        }

    }
}
