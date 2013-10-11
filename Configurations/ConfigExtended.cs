using System;
using System.Configuration;
using System.Linq;
using Microsoft.SharePoint;

namespace SOEESReceiver
{
    public static class ConfigExtended
    {
        #region Config

        public static string PathToConfigFile
        {
            get { return _pathToConfigFile; }
            set
            {
                _pathToConfigFile = value;
                if (string.IsNullOrEmpty(PathToConfigFile))
                    throw new Exception("Не задан путь к файлу конфигурации");

                var pathToConfigFile = @"c:\Program Files\Common Files\microsoft shared\Web Server Extensions\14\CONFIG\" + PathToConfigFile + ".config";
                Config = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap {ExeConfigFilename = pathToConfigFile}, ConfigurationUserLevel.None).AppSettings.Settings;
                ConfigCS =
                    ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap {ExeConfigFilename = pathToConfigFile}, ConfigurationUserLevel.None).ConnectionStrings.ConnectionStrings;
            }
        }

        private static KeyValueConfigurationCollection _config;

        public static KeyValueConfigurationCollection Config
        {
            get
            {
                if (string.IsNullOrEmpty(PathToConfigFile))
                    throw new Exception("Не задан путь к файлу конфигурации");

                return _config;
            }
            private set { _config = value; }
        }

        private static ConnectionStringSettingsCollection _configCS;
        private static string _pathToConfigFile;

        public static ConnectionStringSettingsCollection ConfigCS
        {
            get
            {
                if (string.IsNullOrEmpty(PathToConfigFile))
                    throw new Exception("Не задан путь к файлу конфигурации");

                return _configCS;
            }
            private set { _configCS = value; }
        }

        #endregion

        #region Read config methods

        public static string GetParameterAsString(this KeyValueConfigurationCollection configuration, string parameterName)
        {
            var parameterValue = configuration.AllKeys.Contains(parameterName) && configuration[parameterName].Value.Length > 0
                                     ? configuration[parameterName].Value
                                     : string.Empty;

            return parameterValue;
        }

        public static int GetParameterAsInteger(this KeyValueConfigurationCollection configuration, string parameterName)
        {
            var parameterValue = configuration.AllKeys.Contains(parameterName) && configuration[parameterName].Value.Length > 0
                                     ? int.Parse(configuration[parameterName].Value)
                                     : 0;

            return parameterValue;
        }

        #endregion

        #region Read SPListItem config methods

        public static string GetParameterAsString(this SPListItem configuration, string parameterName)
        {
            var field = configuration.ListItems.List.Fields.GetField(parameterName);
            if (field == null || configuration[parameterName] == null)
                return string.Empty;

            return configuration[parameterName].ToString();
        }

        public static int GetParameterAsInteger(this SPListItem configuration, string parameterName)
        {
            var field = configuration.ListItems.List.Fields.GetField(parameterName);
            if (field == null || string.IsNullOrEmpty(configuration[parameterName].ToString()))
                return 0;

            return int.Parse(configuration[parameterName].ToString());
        }

        public static int GetParameterAsInteger(this SPListItem configuration, string parameterName, int defaultValue)
        {
            var field = configuration.ListItems.List.Fields.GetField(parameterName);
            if (field == null || string.IsNullOrEmpty(configuration[parameterName].ToString()))
                return defaultValue;

            return int.Parse(configuration[parameterName].ToString());
        }

        #endregion
    }
}