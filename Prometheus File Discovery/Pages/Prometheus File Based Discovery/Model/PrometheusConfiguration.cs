using Newtonsoft.Json;

namespace Prometheus_File_Discovery.Pages.Prometheus_File_Based_Discovery.Model
{
    public class PrometheusConfiguration
    {

        // Properties
        public double Version { get; set; } = 0.0;
        public ConfigurationComponents.Global global { get; set; }
        public List<string> rule_files { get; set; }
        public ConfigurationComponents.Remote_Write remote_write { get; set; }
        public ConfigurationComponents.Remote_Read remote_read { get; set; }
        public ConfigurationComponents.Scrape_Configs scrape_configs { get; set; }
        public ConfigurationComponents.Alerting alerting { get; set; }

        // ToString method
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
