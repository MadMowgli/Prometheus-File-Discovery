using Newtonsoft.Json.Linq;

namespace Prometheus_File_Discovery.Pages.Prometheus_File_Based_Discovery.Model
{
    public static class JsonToPrometheusConverter
    {

        // Fields


        // Constructor


        // Methods
        public static void convertJsonToDotNet(dynamic dynamicConfig, PrometheusConfiguration prometheusConfiguration)
        {

            // dynamicConfig is a JObject
            // dynamicConfig has JProperties
            // Jproperties have child values
            // These Child values are JObjects themselves

            // Loop over each attribute to parse it
            foreach (var property in dynamicConfig.Properties())
            {
                string name = property.Name;
                switch (name)
                {
                    case "global":
                        // Create new configComponent
                        ConfigurationComponents.Global global = new ConfigurationComponents.Global();
                        Console.WriteLine("Parsing global component...");

                        // Loop over object properties
                        foreach (JObject val in property.Values<object>())
                        {
                            // Check if property has properties itself
                            if (val.Properties().Any())
                            {
                                foreach (var prop in val.Properties())
                                {
                                    // Check for each subtype
                                    string propName = prop.Name;
                                    Console.WriteLine("Parsing " + propName + " of global component...");

                                    if (propName == "scrape_interval") {
                                        
                                        global.scrape_interval = prop.Value.ToString();
                                        Console.WriteLine("Scrape Interval: " + prop.Value.ToString());
                                    }
                                    if (propName == "evaluation_interval") {
                                        global.evaluation_interval = prop.Value.ToString();
                                        Console.WriteLine("Evaluation Interval: " + prop.Value.ToString());
                                    }
                                    // TODO: Support for external_labels
                                    // if(name.Equals("external_labels")) { global.evaluation_interval = prop.Value.ToString(); }

                                }
                            }
                        }

                        // Assign new configComponent
                        prometheusConfiguration.global = global;
                        break;


                    case "scrape_configs":
                        // Create new configComponent
                        ConfigurationComponents.Scrape_Configs scrape_configs = new ConfigurationComponents.Scrape_Configs();
                        Console.WriteLine("Parsing scrape_configs component...");

                        // Loop over object properties
                        foreach (JArray arr in property.Values<object>())
                        {
                            // Check if property has properties itself
                            if (arr.Values().Any())
                            {
                                foreach (JProperty val in arr.Values())
                                {
                                    // Each property is a new PrometheusJob
                                    PrometheusJob prometheusJob = new PrometheusJob();

                                    string propName = val.Name;
                                    string propValue = val.Value.ToString();
                                    if (propName.Equals("job_name")) { prometheusJob.JobName = propValue; Console.WriteLine("Job Name: " + propValue); }
                                    if (propName.Equals("scrape_interval")) { prometheusJob.Scrape_Interval = propValue; Console.WriteLine("Scrape Interval: " + propValue); }
                                    if (propName.Equals("scrape_timeout")) { prometheusJob.Scrape_Timeout = propValue; Console.WriteLine("Scrape Timeout: " + propValue); }
                                    if (propName.Equals("honor_labels")) { prometheusJob.Honor_Labels = Convert.ToBoolean(propValue); Console.WriteLine("Honor Labels: " + propValue); }
                                    if (propName.Equals("static_configs"))
                                    {
                                        foreach (JArray arr2 in val.Values())
                                        {
                                            Console.WriteLine(arr2.ToString());
                                        }
                                    }
                                    //if (propName.Equals("file_sd_configs"))
                                    //{
                                    //    foreach (JObject val2 in prop.Values<object>())
                                    //    {
                                    //        foreach (var prop2 in val2.Properties())
                                    //        {
                                    //            string prop2Name = prop2.Name;

                                    //            if (prop2Name.Equals("files"))
                                    //            {
                                    //                foreach (var prop3 in prop2.Values())
                                    //                {
                                    //                    Console.WriteLine(prop3.ToString());
                                    //                }
                                    //                // prometheusJob.File_Sd_Configs
                                    //            }
                                    //        }
                                    //    }
                                    //}

                                }
                            }
                        }

                        // Assign new configComponent
                        prometheusConfiguration.scrape_configs = scrape_configs;
                        break;


                    case "alerting":
                        // Create new configComponent
                        ConfigurationComponents.Alerting alerting = new ConfigurationComponents.Alerting();

                        // Assign new configComponent
                        prometheusConfiguration.alerting = alerting;
                        break;


                    case "rule_files":
                        // Create new configComponent
                        List<string> ruleFiles = new List<string>();

                        // Assign new configComponent
                        prometheusConfiguration.rule_files = ruleFiles;
                        break;

                }

            }
        }

    }
}
