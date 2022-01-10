namespace Prometheus_File_Discovery.Pages.Prometheus_File_Based_Discovery.Model
{
    public class ScrapeTargets
    {


        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
        {
            public Labels labels { get; set; }
            public string[] targets { get; set; }
        }

        public class Labels
        {
            public string job { get; set; }
        }


    }
}
