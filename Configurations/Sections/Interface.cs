using System.Configuration;

namespace X3Store.Configurations.Sections
{
    public class Interface : ConfigurationSection
    {
        [ConfigurationProperty("siteTitle", DefaultValue = "X3Store")]
        public string SiteTitle { get { return (string) base["siteTitle"]; } set { base["siteTitle"] = value; } }

        [ConfigurationProperty("contactForm")]
        public ContactForm ContactForm
        {
            get { return (ContactForm) (base["contactForm"] ?? new ContactForm()); }
        }
    }

    public class ContactForm : ConfigurationElement
    {
        [ConfigurationProperty("subject", DefaultValue = "X3Store: {0}")]
        public string Subject { get { return (string) base["subject"]; } set { base["subject"] = value; } }

        [ConfigurationProperty("to", IsRequired = true)]
        public string To { get { return (string)base["to"]; } set { base["to"] = value; } }
    }
}