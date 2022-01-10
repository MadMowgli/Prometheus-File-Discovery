namespace Prometheus_File_Discovery.Pages.Prometheus_File_Based_Discovery.Model
{
    public class PrometheusJob
    {

        // Fields
        private string _job_name;
        private string _scrape_interval;
        private string _scrape_timeout;
        private string _metrics_path;
        private string _scheme;
        private List<string> _targets;
        private Dictionary<string, string> _labels;

        // Constructor taking all parameters
        public PrometheusJob(string job_name, string scrape_interval, string scrape_timeout,
            string metrics_path, string scheme, List<string> targets, Dictionary<string, string> labels)
        {
            _job_name = job_name;
            _scrape_interval = scrape_interval;
            _scrape_timeout = scrape_timeout;
            _metrics_path = metrics_path;
            _scheme = scheme;
            _targets = targets;
            _labels = labels;
        }

        // Constructor taking all parameters except metrics_path and scheme, setting them to default
        public PrometheusJob(string job_name, string scrape_interval, string scrape_timeout,
            List<string> targets, Dictionary<string, string> labels)
        {
            _job_name = job_name;
            _scrape_interval = scrape_interval;
            _scrape_timeout = scrape_timeout;
            _targets = targets;
            _labels = labels;

            // Defaulting metrics_path and scheme
            _metrics_path = "/metrics";
            _scheme = "https";
        }

        // Constructor taking all parameters except metrics_path, scheme and labels, setting metrics_path and scheme to default
        public PrometheusJob(string job_name, string scrape_interval, string scrape_timeout, List<string> targets)
        {
            _job_name = job_name;
            _scrape_interval = scrape_interval;
            _scrape_timeout = scrape_timeout;
            _targets = targets;

            // Defaulting metrics_path and scheme
            _metrics_path = "/metrics";
            _scheme = "https";
        }

        // Properties

    }
}
