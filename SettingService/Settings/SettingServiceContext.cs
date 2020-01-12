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
        public DbSet<Setting> Settings { get; set; }


        public DbSet<SettingsEntry> SettingsEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
