using Newtonsoft.Json;

namespace Prometheus_File_Discovery.Pages.Prometheus_File_Based_Discovery.Model
{
    public class PrometheusConfiguration
    {
        // Properties
        public double Version { get; set; } = 0.0;
        public ConfigurationComponents.Global global { get; set; }
        public List<string> rule_files { get; set; }
        public List<ConfigurationComponents.Scrape_Configs> scrape_configs { get; set; }
        public ConfigurationComponents.Alerting alerting { get; set; }
        // public ConfigurationComponents.Remote_Write remote_write { get; set; }
        // public ConfigurationComponents.Remote_Read remote_read { get; set; }


        
        // Constructor
        public PrometheusConfiguration()
        {
            Version = 0.0;
            global = new ConfigurationComponents.Global();
            rule_files = new List<string>();
            scrape_configs = new List<ConfigurationComponents.Scrape_Configs>();
            alerting = new ConfigurationComponents.Alerting();

            // remote_write = new ConfigurationComponents.Remote_Write();
            // remote_read = new ConfigurationComponents.Remote_Read();
        }
        
        // ToString method
        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }

    }
}
