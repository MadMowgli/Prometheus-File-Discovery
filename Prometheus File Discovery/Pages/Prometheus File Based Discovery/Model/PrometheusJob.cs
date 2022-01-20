namespace Prometheus_File_Discovery.Pages.Prometheus_File_Based_Discovery.Model
{
    public class PrometheusJob
    {

        // Fields
        private string? _job_name;
        private string? _scrape_interval;
        private string? _scrape_timeout;
        private string? _metrics_path;
        private string? _scheme;
        private bool _honor_labels = false;
        private List<string>? _targets;
        private Dictionary<string, string>? _labels;
        private Dictionary<string, List<String>>? _file_sd_configs;
        private List<ConfigurationComponents.Static_Configs> _static_configs = new List<ConfigurationComponents.Static_Configs>();

        // Constructor with no arguments
        public PrometheusJob()
        {

        }

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
        public string JobName { get { return _job_name; } set { _job_name = value; } }
        public string Scrape_Interval { get { return _scrape_interval;} set { _scrape_interval = value; } }
        public string Scrape_Timeout { get { return _scrape_timeout;} set { _scrape_timeout = value; } }
        public string Metrics_path { get { return _metrics_path; } set { _metrics_path = value; } }
        public string Scheme { get { return _scheme; } set { _scheme = value; } }
        public bool Honor_Labels { get { return _honor_labels; } set { _honor_labels = value; } }
        public List<string> Targets { get { return _targets; } set { _targets = value; } }
        public Dictionary<string, string> Labels { get { return _labels;  } set { _labels = value; } }
        public Dictionary<string, List<string>> File_Sd_Configs { get { return _file_sd_configs;  } set { _file_sd_configs = value;} }
        public List<ConfigurationComponents.Static_Configs> Static_Configs { get { return _static_configs;  } set { _static_configs = value; } }

        // Custom Methods
        public void addLabel(string key, string value)
        {
            if(this.Labels == null) { this.Labels = new Dictionary<string, string>(); }
            this.Labels.Add(key, value);
        }
        public void removeLabel(string key)
        {
            this.Labels.Remove(key);
        }

        public void addTarget(string target)
        {
            if(this.Targets == null) { this.Targets = new List<string>(); } 
            this.Targets.Add(target);
        }
        public void removeTarget(string target)
        {
            this.Targets.Remove(target);
        }

        public void addFileSdConfig(string key, string value)
        {
            // TODO: Adapt this data type
            List<string> configs = new List<string>();
            configs.Add(value);
            this._file_sd_configs.Add(key, configs);
        }

        public ConfigurationComponents.Scrape_Configs toScrapeConfig()
        {
            ConfigurationComponents.Scrape_Configs scrape_Configs = new ConfigurationComponents.Scrape_Configs();

            if(this._job_name != null) { scrape_Configs.job_name = this._job_name; }
            if(this._scrape_interval != null) { scrape_Configs.scrape_interval = this._scrape_interval; }
            if(this._scrape_timeout != null) { scrape_Configs.scrape_timeout = this._scrape_timeout; }
            if(this._metrics_path != null) { scrape_Configs.metrics_path = this._metrics_path; }
            if(this._scheme != null) { scrape_Configs.job_name = this._scheme; }

            if(this._static_configs != null) { scrape_Configs.static_configs = this._static_configs; }

            return scrape_Configs;
        }

    }
}
