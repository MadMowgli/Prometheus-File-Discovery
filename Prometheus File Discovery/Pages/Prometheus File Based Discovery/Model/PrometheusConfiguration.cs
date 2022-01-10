namespace Prometheus_File_Discovery.Pages.Prometheus_File_Based_Discovery.Model
{
    public class PrometheusConfiguration
    {

        // Properties
        public double Version { get; set; }
        public ConfigurationComponents.Global global { get; set; }
        public List<string> rule_files { get; set; }
        public ConfigurationComponents.Remote_Write remote_write { get; set; }
        public ConfigurationComponents.Remote_Read remote_read { get; set; }
        public ConfigurationComponents.Scrape_Configs scrape_configs { get; set; }
        public ConfigurationComponents.Alerting alerting { get; set; }


        // Constructor
        public PrometheusConfiguration(double Version)
        {
            this.Version = Version;
        }


        // Methods
        public void loadConfiguration(PrometheusConfiguration prometheusConfiguration)
        {
            this.Version = prometheusConfiguration.Version;
            this.global = prometheusConfiguration.global;
            this.rule_files = prometheusConfiguration.rule_files;
            this.remote_write = prometheusConfiguration.remote_write;
            this.remote_read = prometheusConfiguration.remote_read;
            this.scrape_configs = prometheusConfiguration.scrape_configs;
            this.alerting = prometheusConfiguration.alerting;
        }

    }
}
