using System.Configuration;

namespace Bapin.WindowsService.Configuration
{
    internal class HandlerConfigurationSection : ConfigurationSection
    {
        private static ConfigurationPropertyCollection properties;
        private static ConfigurationProperty handlersElement;

        static HandlerConfigurationSection()
        {
            properties = new ConfigurationPropertyCollection();
            handlersElement = new ConfigurationProperty("handlers", typeof(HandlerConfigurationElementCollection), null, ConfigurationPropertyOptions.IsRequired);

            properties.Add(handlersElement);
        }

        [ConfigurationProperty("handlers")]
        public HandlerConfigurationElementCollection HandlerConfigurations
        {
            get { return (HandlerConfigurationElementCollection)this[handlersElement]; }
        }
    }
}