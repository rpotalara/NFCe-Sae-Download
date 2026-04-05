using System;
using System.Configuration;

namespace NfceSaeDownloader.Infrastructure
{
    public static class AppSettingsStore
    {
        public static string GetString(string key, string defaultValue)
        {
            var value = ConfigurationManager.AppSettings[key];
            return string.IsNullOrWhiteSpace(value) ? defaultValue : value;
        }

        public static int GetInt(string key, int defaultValue)
        {
            int parsed;
            return int.TryParse(ConfigurationManager.AppSettings[key], out parsed) ? parsed : defaultValue;
        }
    }
}
