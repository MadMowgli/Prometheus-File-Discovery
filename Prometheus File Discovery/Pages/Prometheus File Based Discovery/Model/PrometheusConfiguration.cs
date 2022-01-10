namespace Prometheus_File_Discovery.Pages.Prometheus_File_Based_Discovery.Model
{
    public class PrometheusConfiguration
    {

        // Properties
        public double Version { get; set; }
        public Global global { get; set; }
        public string[] rule_files { get; set; }
        public Remote_Write[] remote_write { get; set; }
        public Remote_Read[] remote_read { get; set; }
        public Scrape_Configs[] scrape_configs { get; set; }
        public Alerting alerting { get; set; }

        // Constructor
        public PrometheusConfiguration(double Version)
        {
            this.Version = Version;
        }

    }
}
