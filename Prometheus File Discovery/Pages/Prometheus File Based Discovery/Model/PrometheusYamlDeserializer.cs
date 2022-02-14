using YamlDotNet.Serialization;

namespace Prometheus_File_Discovery.Pages.Prometheus_File_Based_Discovery.Model;

public class PrometheusYamlDeserializer
{
    public static PrometheusConfiguration desirializeToPrometheusConfiguration(string yaml)
    {
        // Set up deserializer
        var deserializer = new DeserializerBuilder().Build();
        return deserializer.Deserialize<PrometheusConfiguration>(yaml);
    }
}