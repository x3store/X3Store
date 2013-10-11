using System.Configuration;

namespace X3Store.Configurations.Sections
{
    public class Common : ConfigurationSection
    {
        [ConfigurationProperty("siteTitle", DefaultValue = "X3Store")]
        public string SiteTitle { get { return (string) base["siteTitle"]; } set { base["siteTitle"] = value; } }
    }
}
