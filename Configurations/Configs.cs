using System.Web.Configuration;
using X3Store.Configurations.Sections;

namespace X3Store.Configurations
{
    public static class Configs
    {
        public static Interface Interface { get { return (Interface) WebConfigurationManager.GetSection("x3/interface") ?? new Interface(); } }

        public static Common Common { get { return (Common)WebConfigurationManager.GetSection("x3/common") ?? new Common(); } }
    }
}