using System.Configuration;

namespace Bapin.WindowsService.Configuration
{
    [ConfigurationCollection(typeof(HandlerConfigurationElement), AddItemName = "handler", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    internal class HandlerConfigurationElementCollection : ConfigurationElementCollection
    {
        private static ConfigurationPropertyCollection properties;

        static HandlerConfigurationElementCollection()
        {
            properties = new ConfigurationPropertyCollection();
        }

        public HandlerConfigurationElementCollection()
        {
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get { return properties; }
        }

        protected override string ElementName
        {
            get { return "handler"; }
        }

        public HandlerConfigurationElement this[int index]
        {
            get
            {
                return (HandlerConfigurationElement)this.BaseGet(index);
            }

            set
            {
                if (this.BaseGet(index) != null)
                {
                    this.BaseRemoveAt(index);
                }

                this.BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new HandlerConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as HandlerConfigurationElement).Name;
        }
    }
}
