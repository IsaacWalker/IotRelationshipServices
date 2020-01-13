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
        public SettingsEntry CurrentSettings { get; set; }


        public DbSet<Setting> Settings { get; set; }


        public DbSet<SettingsEntry> SettingsEntries { get; set; }


        public SettingServiceContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Setting>()
                .HasKey(S => new { S.Name, S.Type, S.Value });

            modelBuilder.Entity<SettingsEntrySetting>()
                .HasKey(ses => new { ses.Name, ses.Type, ses.Value, ses.SettingsEntryId });

            modelBuilder.Entity<SettingsEntrySetting>()
                .HasOne(ses => ses.Setting)
                .WithMany(ses => ses.SettingsEntrySettings)
                .HasForeignKey(ses => new { ses.Name, ses.Type, ses.Value });

            modelBuilder.Entity<SettingsEntrySetting>()
                .HasOne(ses => ses.SettingsEntry)
                .WithMany(ses => ses.SettingsEntrySettings)
                .HasForeignKey(ses => ses.SettingsEntryId);
        }

    }
}
