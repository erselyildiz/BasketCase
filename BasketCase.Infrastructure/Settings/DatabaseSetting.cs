using BasketCase.Infrastructure.Settings.Interfaces;

namespace BasketCase.Infrastructure.Settings
{
    public class DatabaseSetting : IDatabaseSetting
    {
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
    }
}