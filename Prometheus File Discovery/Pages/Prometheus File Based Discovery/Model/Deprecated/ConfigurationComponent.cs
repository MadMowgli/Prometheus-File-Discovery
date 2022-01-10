namespace Prometheus_File_Discovery.Pages.Prometheus_File_Based_Discovery.Model
{
    public class ConfigurationComponent
    {

        // Fields
        private ComponentType componentType;
        private PrometheusConfiguration_old parent;
        private Dictionary<string, object> properties;

        // Constructor
        public ConfigurationComponent(ComponentType componentType, PrometheusConfiguration_old parent)
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

        public PrometheusConfiguration_old Parent
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
                case ComponentType.global:
                    this.properties.Add("scrape_interval", new string(""));
                    this.properties.Add("evaluation_interval", new string(""));
                    break;

                case ComponentType.rule_files:
                    // Not supported yet
                    break;

                case ComponentType.remote_write:
                    // Not supported yet
                    break;

                case ComponentType.remote_read:
                    // Not supported yet
                    break;

                case ComponentType.scrape_configs:
                    this.properties.Add("job_name", new string(""));
                    this.properties.Add("honor_labels", new bool());
                    this.properties.Add("scrape_interval", new string(""));

                    // File configs
                    this.properties.Add("file_sd_configs", new Dictionary<string, string>());
                    this.properties["file_sd_configs"].Add("files", )
                    break;

                case ComponentType.alerting:
                    break;
            }
        }
    }
}
