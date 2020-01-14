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
        public DbSet<SettingsEntry> SettingsEntries { get; set; }


        /// <summary>
        /// Junction table for Settings - SettingsEntry many-to-many relationship
        /// </summary>
        public DbSet<SettingsEntrySetting> SettingsEntrySettings { get; set; }


        public SettingServiceContext(DbContextOptions<SettingServiceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SettingsEntrySetting>()
                .HasKey(ses =>  new { ses.SettingId, ses.SettingsEntryId });

            modelBuilder.Entity<SettingsEntrySetting>()
                .HasOne(ses => ses.Setting)
                .WithMany(ses => ses.SettingsEntrySettings)
                .HasForeignKey(ses => ses.SettingId);

            modelBuilder.Entity<SettingsEntrySetting>()
                .HasOne(ses => ses.SettingsEntry)
                .WithMany(ses => ses.SettingsEntrySettings)
                .HasForeignKey(ses => ses.SettingsEntryId);
        }

    }
}
