namespace Prometheus_File_Discovery.Pages.Prometheus_File_Based_Discovery.Model
{
    public class ConfigurationComponent
    {

        // Fields
        private ComponentType componentType;
        private PrometheusConfiguration parent;
        private Dictionary<string, object> properties;

        // Constructor
        public ConfigurationComponent(ComponentType componentType, PrometheusConfiguration parent)
        {
            this.componentType = componentType;
            this.parent = parent;
            this.properties = new Dictionary<string, object>();
        }

        // Properties
        public ComponentType ComponentType
        {
            get { return componentType; }
            set { this.componentType = value; }
        }

        public PrometheusConfiguration Parent
        {
            get { return parent; }
            set { this.parent = value; }
        }

        // Methods
        private void prepareProperties(ComponentType componentType)
        {
            // Assign components properties based on component type
            switch(componentType)
            {
                case ComponentType.Global:
                    this.properties.Add("scrape_interval", new string(""));
                    this.properties.Add("evaluation_interval", new string(""));
                    break;

                case ComponentType.Rule_Files:
                    // Not supported yet
                    break;

                case ComponentType.Remote_Write:
                    // Not supported yet
                    break;

                case ComponentType.Remote_Read:
                    // Not supported yet
                    break;

                case ComponentType.Scrape_Configs:
                    this.properties.Add("job_name", new string(""));
                    this.properties.Add("honor_labels", new bool());
                    this.properties.Add("scrape_interval", new string(""));
                    break;

                case ComponentType.Alerting:
                    break;
            }
        }
    }
}
