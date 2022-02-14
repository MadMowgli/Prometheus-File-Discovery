using Newtonsoft.Json.Linq;

namespace Prometheus_File_Discovery.Pages.Prometheus_File_Based_Discovery.Model;

public static class JsonToPrometheusConverter
{
    // Fields


    // Constructor


    // Methods
    public static PrometheusConfiguration convertJsonToDotNet(dynamic dynamicConfig,
        PrometheusConfiguration prometheusConfiguration)
    {
        // dynamicConfig is a JObject
        // dynamicConfig has JProperties
        // Jproperties have child values
        // These Child values are JObjects themselves

        /* NAMING CONVENTION
         * - configProperty = elements of the prometheus configuration (global, rule_files, scrape_configs, ...)
         */

        // Loop over each attribute to parse it
        foreach (var configProperty in dynamicConfig.Properties())
        {
            string configPropertyName = configProperty.Name;
            switch (configPropertyName)
            {
                case "global":
                    // Create new configComponent
                    var global = new ConfigurationComponents.Global();
                    Console.WriteLine("Parsing global component...");

                    // Loop over object properties
                    foreach (JObject globalComponentValues in configProperty.Values<object>())
                        // Check if property has properties itself
                        if (globalComponentValues.Properties().Any())
                            foreach (var globalComponentProperty in globalComponentValues.Properties())
                            {
                                // Check for each subtype
                                var propName = globalComponentProperty.Name;
                                Console.WriteLine("Parsing " + propName + " of global component...");

                                if (propName == "scrape_interval")
                                {
                                    global.scrape_interval = globalComponentProperty.Value.ToString();
                                    Console.WriteLine("Scrape Interval: " + globalComponentProperty.Value);
                                }

                                if (propName == "evaluation_interval")
                                {
                                    global.evaluation_interval = globalComponentProperty.Value.ToString();
                                    Console.WriteLine("Evaluation Interval: " + globalComponentProperty.Value);
                                }
                                // if(name.Equals("external_labels")) { global.evaluation_interval = prop.Value.ToString(); }
                            }

                    // Assign new configComponent
                    prometheusConfiguration.global = global;
                    break;


                case "scrape_configs":
                    // Create new configComponent
                    // Each scrape_config element should represents a prometheus job, according to the docs.
                    Console.WriteLine("Parsing scrape_configs component...");

                    // Loop over object properties
                    // The configProperty is actually a list (JArray) containing jobObjects
                    foreach (JArray jobArray in configProperty.Values<object>())
                    {
                        Console.WriteLine("Found Prometheus Jobs: " + jobArray.Count);
                        if (jobArray.Values().Any())
                        {
                            var count = 0;
                            // foreach (JProperty jobProperty in jobArray.Values())
                            foreach (JObject job in jobArray.Children())
                            {
                                var prometheusJob = new PrometheusJob();
                                count++;
                                // TODO: Continue here, 10.02.22
                                // Each object is a new PrometheusJob, parse it's data
                                foreach (var jobProperty in job.Properties())
                                {
                                    var propName = jobProperty.Name;
                                    var propValue = jobProperty.Value.ToString();

                                    if (propName.Equals("job_name"))
                                    {
                                        prometheusJob.JobName = propValue;
                                        Console.WriteLine("Job Name: " + propValue);
                                    }

                                    if (propName.Equals("scrape_interval"))
                                    {
                                        prometheusJob.Scrape_Interval = propValue;
                                        Console.WriteLine("Scrape Interval: " + propValue);
                                    }

                                    if (propName.Equals("scrape_timeout"))
                                    {
                                        prometheusJob.Scrape_Timeout = propValue;
                                        Console.WriteLine("Scrape Timeout: " + propValue);
                                    }

                                    if (propName.Equals("honor_labels"))
                                    {
                                        prometheusJob.Honor_Labels = Convert.ToBoolean(propValue);
                                        Console.WriteLine("Honor Labels: " + propValue);
                                    }

                                    if (propName.Equals("static_configs"))
                                    {
                                        // Each static config element is a list of JProperties, so we need to iterate
                                        Console.WriteLine("Reading static_configs...");

                                        foreach (JObject staticConfigJObject in jobProperty.Values())
                                        {
                                            var static_Configs = new ConfigurationComponents.Static_Configs();
                                            Console.WriteLine("staticConfigObject: " + staticConfigJObject);

                                            // Loop over each property
                                            foreach (var staticConfigProperty in staticConfigJObject.Properties())
                                            {
                                                var staticConfigPropertyName = staticConfigProperty.Name;

                                                // Target list
                                                if (staticConfigPropertyName == "targets")
                                                {
                                                    Console.Write("Targets: ");
                                                    foreach (JValue jVal in staticConfigProperty.Values())
                                                    {
                                                        static_Configs.targets.Add(jVal.ToString());
                                                        Console.WriteLine(jVal.ToString());
                                                    }
                                                }

                                                // Labels
                                                if (staticConfigPropertyName == "labels")
                                                {
                                                    Console.Write("Labels: ");
                                                    foreach (dynamic jVal in staticConfigProperty.Values())
                                                    {
                                                        string key = jVal.Name.ToString();
                                                        string value = jVal.Value.ToString();
                                                        Console.WriteLine(key + ":" + value);
                                                        static_Configs.labels.Add(key, value);
                                                    }
                                                }

                                                prometheusJob.Static_Configs.Add(static_Configs);
                                            }
                                        }
                                    }
                                }
                                // Assign new configComponent
                                ConfigurationComponents.Scrape_Configs
                                    scrapeConfig = prometheusJob.toScrapeConfigObject();
                                prometheusConfiguration.scrape_configs.Add(scrapeConfig); // This produces nullpointerexception
                            }
                        }
                    }


                    break;


                case "alerting":
                    // Create new configComponent
                    var alerting = new ConfigurationComponents.Alerting();
                    Console.WriteLine("Parsing alerting component...");

                    // Check if not empty
                    if (configProperty.HasValues)
                        foreach (var val in configProperty.Values<dynamic>())
                            // Goes into the 'alertmanagers' object
                        foreach (var val2 in val.Values<dynamic>())
                        {
                            var alertManager = new ConfigurationComponents.Alertmanager();
                            Console.WriteLine("Alerting property name: " + val2.Name);
                            var objType = val2.GetType();

                            // TODO: Multiple alertmanager-objects can be passed.
                            if (val2.GetType() == typeof(JArray)) Console.WriteLine("Alerting value type: JArray");

                            // Single alertmanager-object
                            if (val2.GetType() == typeof(JProperty))
                            {
                                Console.WriteLine("Alerting value type: JProperty");

                                // Get values of alertmanagers object
                                foreach (var val3 in val2.Values<dynamic>())
                                    // val3 is JArray
                                    // Console.WriteLine(val3.GetType());
                                    // Console.WriteLine(val3.ToString());

                                foreach (var arrVal in val3.Values<dynamic>())
                                    //JArray contains Jobjects
                                foreach (var arrObj in arrVal.Values<dynamic>())
                                {
                                    string arrObjName = arrObj.Name;

                                    // Scheme object
                                    if (arrObjName == "scheme")
                                    {
                                        Console.WriteLine("Alertmanager scheme: " + arrObj.Value.ToString());
                                        alertManager.scheme = arrObj.Value.ToString();
                                    }

                                    // Static_configs object
                                    var static_Configs = new ConfigurationComponents.Static_Configs();
                                    if (arrObjName == "static_configs")
                                    {
                                        Console.WriteLine(arrObjName);
                                        foreach (JObject jObj in arrObj.Value)
                                            // Console.WriteLine("JValue Type: " + jObj.GetType());
                                            // Loop over each property
                                        foreach (dynamic jProp in jObj.Properties())
                                        {
                                            string propName2 = jProp.Name;
                                            Console.WriteLine(propName2);
                                            if (propName2 == "targets")
                                            {
                                                Console.WriteLine("Targets:");
                                                foreach (JArray jVal in jProp.Values<dynamic>())
                                                foreach (var jArrVal in jVal.Value<dynamic>())
                                                {
                                                    Console.WriteLine(jArrVal.ToString());
                                                    static_Configs.targets.Add(jArrVal.ToString());
                                                }
                                            }

                                            if (propName2 == "labels")
                                            {
                                                Console.WriteLine("Labels:");
                                                foreach (var jVal in jProp.Values())
                                                {
                                                    string key = jVal.Name.ToString();
                                                    string value = jVal.Value.ToString();
                                                    Console.WriteLine(key + ":" + value);
                                                    static_Configs.labels.Add(key, value);
                                                }
                                            }
                                        }
                                    }

                                    alertManager.static_configs.Add(static_Configs);
                                }
                            }
                        }

                    // Assign new configComponent
                    prometheusConfiguration.alerting = alerting;
                    break;


                case "rule_files":
                    // Create new configComponent
                    var ruleFiles = new List<string>();
                    Console.WriteLine("Parsing rule_files component...");

                    // Looop over property values
                    foreach (JArray jArr in configProperty.Values<dynamic>())
                    foreach (var jArrVal in jArr.Value<dynamic>())
                    {
                        Console.WriteLine("Rule Files: " + jArrVal.ToString());
                        ruleFiles.Add(jArrVal.ToString());
                    }

                    // Assign new configComponent
                    prometheusConfiguration.rule_files = ruleFiles;
                    break;
            }
        }

        return prometheusConfiguration;
    }
}