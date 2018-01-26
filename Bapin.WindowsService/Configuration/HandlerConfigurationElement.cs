using System;
using System.Configuration;

namespace Bapin.WindowsService.Configuration
{
    internal class HandlerConfigurationElement : ConfigurationElement
    {
        private static ConfigurationPropertyCollection properties;
        private static ConfigurationProperty nameProperty;
        private static ConfigurationProperty handlerTypeProperty;
        private static ConfigurationProperty enabledProperty;
        private static ConfigurationProperty pollingIntervalProperty;
        private static ConfigurationProperty scheduledTimeProperty;

        static HandlerConfigurationElement()
        {
            nameProperty = new ConfigurationProperty("name", typeof(string), null, ConfigurationPropertyOptions.IsRequired | ConfigurationPropertyOptions.IsKey);
            handlerTypeProperty = new ConfigurationProperty("type", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
            enabledProperty = new ConfigurationProperty("enabled", typeof(bool), true, ConfigurationPropertyOptions.None);
            pollingIntervalProperty = new ConfigurationProperty("pollingInterval", typeof(int), 30, ConfigurationPropertyOptions.None);
            scheduledTimeProperty = new ConfigurationProperty("scheduledTime", typeof(DateTime), null, ConfigurationPropertyOptions.None);

            properties = new ConfigurationPropertyCollection();
            properties.Add(nameProperty);
            properties.Add(handlerTypeProperty);
            properties.Add(enabledProperty);
            properties.Add(pollingIntervalProperty);
            properties.Add(scheduledTimeProperty);
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this[nameProperty]; }
        }

        [ConfigurationProperty("type")]
        public Type Type
        {
            get { return Type.GetType((string)this[handlerTypeProperty]); }
        }

        [ConfigurationProperty("enabled")]
        public bool Enabled
        {
            get { return (bool)this[enabledProperty]; }
        }

        [ConfigurationProperty("pollingInterval")]
        public int PollingInterval
        {
            get { return (int)this[pollingIntervalProperty]; }
        }

        [ConfigurationProperty("scheduledTime")]
        public DateTime? ScheduledTime
        {
            get { return (DateTime?)this[scheduledTimeProperty]; }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get { return properties; }
        }
    }
}
