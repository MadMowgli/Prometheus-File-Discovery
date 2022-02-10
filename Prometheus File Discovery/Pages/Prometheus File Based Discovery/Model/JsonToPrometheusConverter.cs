using Newtonsoft.Json.Linq;

namespace Prometheus_File_Discovery.Pages.Prometheus_File_Based_Discovery.Model
{
    public static class JsonToPrometheusConverter
    {

        // Fields


        // Constructor


        // Methods
        public static PrometheusConfiguration convertJsonToDotNet(dynamic dynamicConfig, PrometheusConfiguration prometheusConfiguration)
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
                        // ConfigurationComponents.Scrape_Configs scrape_configs = new ConfigurationComponents.Scrape_Configs();
                        Console.WriteLine("Parsing scrape_configs component...");

                        // Loop over object properties
                        foreach (JArray arr in property.Values<object>())
                        {
                            // Check if property has properties itself
                            if (arr.Values().Any())
                            {
                                
                                // Each property is a new PrometheusJob
                                PrometheusJob prometheusJob = new PrometheusJob();
                                ConfigurationComponents.Static_Configs static_Configs = new ConfigurationComponents.Static_Configs();
                                
                                foreach (JProperty val in arr.Values())
                                {
                                    string propName = val.Name;
                                    string propValue = val.Value.ToString();
                                    if (propName.Equals("job_name")) { prometheusJob.JobName = propValue; Console.WriteLine("Job Name: " + propValue); }
                                    if (propName.Equals("scrape_interval")) { prometheusJob.Scrape_Interval = propValue; Console.WriteLine("Scrape Interval: " + propValue); }
                                    if (propName.Equals("scrape_timeout")) { prometheusJob.Scrape_Timeout = propValue; Console.WriteLine("Scrape Timeout: " + propValue); }
                                    if (propName.Equals("honor_labels")) { prometheusJob.Honor_Labels = Convert.ToBoolean(propValue); Console.WriteLine("Honor Labels: " + propValue); }
                                    if (propName.Equals("static_configs"))
                                    {
                                        
                                        foreach (JObject jObj in val.Value)
                                        {
                                            // Loop over each property
                                            foreach (JProperty jProp in jObj.Properties())
                                            {
                                                string propName2 = jProp.Name;
                                                if (propName2 == "targets")
                                                {
                                                    Console.WriteLine("Targets:");
                                                    foreach(JValue jVal in jProp.Values())
                                                    {
                                                        prometheusJob.addTarget(jVal.ToString());
                                                        static_Configs.targets.Add(jVal.ToString());
                                                        Console.WriteLine(jVal.ToString());
                                                    }
                                                }

                                                if (propName2 == "labels")
                                                {
                                                    Console.WriteLine("Labels:");
                                                    foreach(dynamic jVal in jProp.Values())
                                                    {
                                                        string key = jVal.Name.ToString();
                                                        string value = jVal.Value.ToString();
                                                        Console.WriteLine(key + ":" + value);
                                                        static_Configs.labels.Add(key, value);
                                                        prometheusJob.addLabel(key, value);
                                                    }
                                                }
                                            }
                                        }
                                        prometheusJob.Static_Configs.Add(static_Configs);
                                    }
                                    // Assign new configComponent
                                    Console.WriteLine("Debug Line 127");
                                    ConfigurationComponents.Scrape_Configs
                                        scrapeConfig = prometheusJob.toScrapeConfig();
                                    prometheusConfiguration.scrape_configs.Add(scrapeConfig); // This produces nullpointerexception
                                    Console.WriteLine("Debug Line 129");
                                }
                            }
                        }

                        
                        break;


                    case "alerting":
                        // Create new configComponent
                        ConfigurationComponents.Alerting alerting = new ConfigurationComponents.Alerting();
                        Console.WriteLine("Parsing alerting component...");

                        // Check if not empty
                        if(property.HasValues)
                        {
                            
                            foreach(dynamic val in property.Values<dynamic>())
                            {
                                // Goes into the 'alertmanagers' object
                                foreach (dynamic val2 in val.Values<dynamic>())
                                {
                                    ConfigurationComponents.Alertmanager alertManager = new ConfigurationComponents.Alertmanager();
                                    Console.WriteLine("Alerting property name: " + val2.Name);
                                    dynamic objType = val2.GetType();

                                    // TODO: Multiple alertmanager-objects can be passed.
                                    if (val2.GetType() == typeof(Newtonsoft.Json.Linq.JArray))
                                    {
                                        Console.WriteLine("Alerting value type: JArray");
                                    }

                                    // Single alertmanager-object
                                    if (val2.GetType() == typeof(Newtonsoft.Json.Linq.JProperty))
                                    {
                                        Console.WriteLine("Alerting value type: JProperty");
                                        
                                        // Get values of alertmanagers object
                                        foreach(dynamic val3 in val2.Values<dynamic>())
                                        {
                                            // val3 is JArray
                                            // Console.WriteLine(val3.GetType());
                                            // Console.WriteLine(val3.ToString());

                                            foreach(dynamic arrVal in val3.Values<dynamic>())
                                            {
                                                //JArray contains Jobjects
                                                foreach(dynamic arrObj in arrVal.Values<dynamic>())
                                                {
                                                    string arrObjName = arrObj.Name;

                                                    // Scheme object
                                                    if(arrObjName == "scheme")
                                                    {
                                                        Console.WriteLine("Alertmanager scheme: " + arrObj.Value.ToString());
                                                        alertManager.scheme = arrObj.Value.ToString();
                                                    }

                                                    // Static_configs object
                                                    ConfigurationComponents.Static_Configs static_Configs = new ConfigurationComponents.Static_Configs();
                                                    if (arrObjName == "static_configs")
                                                    {
                                                        Console.WriteLine(arrObjName);
                                                        foreach(JObject jObj in arrObj.Value)
                                                        {
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
                                                                    {
                                                                        
                                                                        foreach(dynamic jArrVal in jVal.Value<dynamic>())
                                                                        {
                                                                            Console.WriteLine(jArrVal.ToString());
                                                                            static_Configs.targets.Add(jArrVal.ToString());
                                                                        }
                                                                    }
                                                                }

                                                                if (propName2 == "labels")
                                                                {
                                                                    Console.WriteLine("Labels:");
                                                                    foreach (dynamic jVal in jProp.Values())
                                                                    {
                                                                        string key = jVal.Name.ToString();
                                                                        string value = jVal.Value.ToString();
                                                                        Console.WriteLine(key + ":" + value);
                                                                        static_Configs.labels.Add(key, value);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    alertManager.static_configs.Add(static_Configs);
                                                }
                                            }
                                        }

                                    }
                                }
                                

                            }
                        }

                        // Assign new configComponent
                        prometheusConfiguration.alerting = alerting;
                        break;


                    case "rule_files":
                        // Create new configComponent
                        List<string> ruleFiles = new List<string>();
                        Console.WriteLine("Parsing rule_files component...");

                        // Looop over property values
                        foreach(JArray jArr in property.Values<dynamic>())
                        {
                            foreach(dynamic jArrVal in jArr.Value<dynamic>())
                            {
                                Console.WriteLine("Rule Files: " + jArrVal.ToString());
                                ruleFiles.Add(jArrVal.ToString());
                            }
                           
                        }

                        // Assign new configComponent
                        prometheusConfiguration.rule_files = ruleFiles;
                        break;

                }

            }
            return prometheusConfiguration;
        }

    }
}
