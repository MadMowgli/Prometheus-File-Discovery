namespace Prometheus_File_Discovery.Pages.Prometheus_File_Based_Discovery.Model
{
    public class PrometheusConfiguration
    {

        // Fields
        private float version;
        private Dictionary<ComponentType, ConfigurationComponent> configurationComponents;

        // Constructor
        public PrometheusConfiguration(float version)
        {
            this.version = version;
            this.configurationComponents = new Dictionary<ComponentType, ConfigurationComponent>();
        }

        // Properties
        public float Version
        {
            get { return version; }
            set { version = value; }
        }

        public Dictionary<ComponentType,ConfigurationComponent> ConfigurationComponents
        {
            get { return configurationComponents; }
            set { configurationComponents = value; }
        }

        // Methods


    }
}
