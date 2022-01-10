namespace Prometheus_File_Discovery.Pages.Prometheus_File_Based_Discovery.Model
{
    public class PrometheusConfigurationJSONPaste
    {


        public class Rootobject
        {
            public Global global { get; set; }
            public string[] rule_files { get; set; }
            public Remote_Write[] remote_write { get; set; }
            public Remote_Read[] remote_read { get; set; }
            public Scrape_Configs[] scrape_configs { get; set; }
            public Alerting alerting { get; set; }
        }

        public class Global
        {
            public string scrape_interval { get; set; }
            public string evaluation_interval { get; set; }
            public External_Labels external_labels { get; set; }
        }

        public class External_Labels
        {
            public string monitor { get; set; }
            public string foo { get; set; }
        }

        public class Alerting
        {
            public Alertmanager[] alertmanagers { get; set; }
        }

        public class Alertmanager
        {
            public string scheme { get; set; }
            public Static_Configs[] static_configs { get; set; }
        }

        public class Static_Configs
        {
            public string[] targets { get; set; }
        }

        public class Remote_Write
        {
            public string url { get; set; }
            public string name { get; set; }
            public Write_Relabel_Configs[] write_relabel_configs { get; set; }
            public Oauth2 oauth2 { get; set; }
            public Tls_Config1 tls_config { get; set; }
            public Headers headers { get; set; }
        }

        public class Oauth2
        {
            public string client_id { get; set; }
            public string client_secret { get; set; }
            public string token_url { get; set; }
            public Tls_Config tls_config { get; set; }
        }

        public class Tls_Config
        {
            public string cert_file { get; set; }
            public string key_file { get; set; }
        }

        public class Tls_Config1
        {
            public string cert_file { get; set; }
            public string key_file { get; set; }
        }

        public class Headers
        {
            public string name { get; set; }
        }

        public class Write_Relabel_Configs
        {
            public string[] source_labels { get; set; }
            public string regex { get; set; }
            public string action { get; set; }
        }

        public class Remote_Read
        {
            public string url { get; set; }
            public bool read_recent { get; set; }
            public string name { get; set; }
            public Required_Matchers required_matchers { get; set; }
            public Tls_Config2 tls_config { get; set; }
        }

        public class Required_Matchers
        {
            public string job { get; set; }
        }

        public class Tls_Config2
        {
            public string cert_file { get; set; }
            public string key_file { get; set; }
        }

        public class Scrape_Configs
        {
            public string job_name { get; set; }
            public bool honor_labels { get; set; }
            public File_Sd_Configs[] file_sd_configs { get; set; }
            public Static_Configs1[] static_configs { get; set; }
            public Relabel_Configs[] relabel_configs { get; set; }
            public Authorization authorization { get; set; }
            public Basic_Auth basic_auth { get; set; }
            public string scrape_interval { get; set; }
            public string scrape_timeout { get; set; }
            public string body_size_limit { get; set; }
            public int sample_limit { get; set; }
            public string metrics_path { get; set; }
            public string scheme { get; set; }
            public Dns_Sd_Configs[] dns_sd_configs { get; set; }
            public Metric_Relabel_Configs[] metric_relabel_configs { get; set; }
            public Consul_Sd_Configs[] consul_sd_configs { get; set; }
            public Tls_Config3 tls_config { get; set; }
            public Kubernetes_Sd_Configs[] kubernetes_sd_configs { get; set; }
            public Kuma_Sd_Configs[] kuma_sd_configs { get; set; }
            public Marathon_Sd_Configs[] marathon_sd_configs { get; set; }
            public Ec2_Sd_Configs[] ec2_sd_configs { get; set; }
            public Lightsail_Sd_Configs[] lightsail_sd_configs { get; set; }
            public Azure_Sd_Configs[] azure_sd_configs { get; set; }
            public Nerve_Sd_Configs[] nerve_sd_configs { get; set; }
            public bool honor_timestamps { get; set; }
            public Http_Sd_Configs[] http_sd_configs { get; set; }
            public Triton_Sd_Configs[] triton_sd_configs { get; set; }
            public Digitalocean_Sd_Configs[] digitalocean_sd_configs { get; set; }
            public Docker_Sd_Configs[] docker_sd_configs { get; set; }
            public Dockerswarm_Sd_Configs[] dockerswarm_sd_configs { get; set; }
            public Openstack_Sd_Configs[] openstack_sd_configs { get; set; }
            public Puppetdb_Sd_Configs[] puppetdb_sd_configs { get; set; }
            public Hetzner_Sd_Configs[] hetzner_sd_configs { get; set; }
            public Eureka_Sd_Configs[] eureka_sd_configs { get; set; }
            public Scaleway_Sd_Configs[] scaleway_sd_configs { get; set; }
            public Linode_Sd_Configs[] linode_sd_configs { get; set; }
            public Uyuni_Sd_Configs[] uyuni_sd_configs { get; set; }
        }

        public class Authorization
        {
            public string credentials_file { get; set; }
            public string credentials { get; set; }
        }

        public class Basic_Auth
        {
            public string username { get; set; }
            public string password { get; set; }
            public string password_file { get; set; }
        }

        public class Tls_Config3
        {
            public string cert_file { get; set; }
            public string key_file { get; set; }
        }

        public class File_Sd_Configs
        {
            public string[] files { get; set; }
            public string refresh_interval { get; set; }
        }

        public class Static_Configs1
        {
            public string[] targets { get; set; }
            public Labels labels { get; set; }
        }

        public class Labels
        {
            public string my { get; set; }
            public string your { get; set; }
        }

        public class Relabel_Configs
        {
            public string[] source_labels { get; set; }
            public object regex { get; set; }
            public string target_label { get; set; }
            public string replacement { get; set; }
            public string action { get; set; }
            public int modulus { get; set; }
            public string separator { get; set; }
        }

        public class Dns_Sd_Configs
        {
            public string refresh_interval { get; set; }
            public string[] names { get; set; }
        }

        public class Metric_Relabel_Configs
        {
            public string[] source_labels { get; set; }
            public string regex { get; set; }
            public string action { get; set; }
        }

        public class Consul_Sd_Configs
        {
            public string server { get; set; }
            public string token { get; set; }
            public string[] services { get; set; }
            public string[] tags { get; set; }
            public Node_Meta node_meta { get; set; }
            public bool allow_stale { get; set; }
            public string scheme { get; set; }
            public Tls_Config4 tls_config { get; set; }
        }

        public class Node_Meta
        {
            public string rack { get; set; }
        }

        public class Tls_Config4
        {
            public string ca_file { get; set; }
            public string cert_file { get; set; }
            public string key_file { get; set; }
            public bool insecure_skip_verify { get; set; }
        }

        public class Kubernetes_Sd_Configs
        {
            public string role { get; set; }
            public string api_server { get; set; }
            public Tls_Config5 tls_config { get; set; }
            public Basic_Auth1 basic_auth { get; set; }
            public Namespaces namespaces { get; set; }
        }

        public class Tls_Config5
        {
            public string cert_file { get; set; }
            public string key_file { get; set; }
        }

        public class Basic_Auth1
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        public class Namespaces
        {
            public string[] names { get; set; }
        }

        public class Kuma_Sd_Configs
        {
            public string server { get; set; }
        }

        public class Marathon_Sd_Configs
        {
            public string[] servers { get; set; }
            public string auth_token { get; set; }
            public Tls_Config6 tls_config { get; set; }
        }

        public class Tls_Config6
        {
            public string cert_file { get; set; }
            public string key_file { get; set; }
        }

        public class Ec2_Sd_Configs
        {
            public string region { get; set; }
            public string access_key { get; set; }
            public string secret_key { get; set; }
            public string profile { get; set; }
            public Filter[] filters { get; set; }
        }

        public class Filter
        {
            public string name { get; set; }
            public string[] values { get; set; }
        }

        public class Lightsail_Sd_Configs
        {
            public string region { get; set; }
            public string access_key { get; set; }
            public string secret_key { get; set; }
            public string profile { get; set; }
        }

        public class Azure_Sd_Configs
        {
            public string environment { get; set; }
            public string authentication_method { get; set; }
            public string subscription_id { get; set; }
            public string tenant_id { get; set; }
            public string client_id { get; set; }
            public string client_secret { get; set; }
            public int port { get; set; }
        }

        public class Nerve_Sd_Configs
        {
            public string[] servers { get; set; }
            public string[] paths { get; set; }
        }

        public class Http_Sd_Configs
        {
            public string url { get; set; }
        }

        public class Triton_Sd_Configs
        {
            public string account { get; set; }
            public string dns_suffix { get; set; }
            public string endpoint { get; set; }
            public int port { get; set; }
            public string refresh_interval { get; set; }
            public int version { get; set; }
            public Tls_Config7 tls_config { get; set; }
        }

        public class Tls_Config7
        {
            public string cert_file { get; set; }
            public string key_file { get; set; }
        }

        public class Digitalocean_Sd_Configs
        {
            public Authorization1 authorization { get; set; }
        }

        public class Authorization1
        {
            public string credentials { get; set; }
        }

        public class Docker_Sd_Configs
        {
            public string host { get; set; }
        }

        public class Dockerswarm_Sd_Configs
        {
            public string host { get; set; }
            public string role { get; set; }
        }

        public class Openstack_Sd_Configs
        {
            public string role { get; set; }
            public string region { get; set; }
            public int port { get; set; }
            public string refresh_interval { get; set; }
            public Tls_Config8 tls_config { get; set; }
        }

        public class Tls_Config8
        {
            public string ca_file { get; set; }
            public string cert_file { get; set; }
            public string key_file { get; set; }
        }

        public class Puppetdb_Sd_Configs
        {
            public string url { get; set; }
            public string query { get; set; }
            public bool include_parameters { get; set; }
            public int port { get; set; }
            public string refresh_interval { get; set; }
            public Tls_Config9 tls_config { get; set; }
        }

        public class Tls_Config9
        {
            public string ca_file { get; set; }
            public string cert_file { get; set; }
            public string key_file { get; set; }
        }

        public class Hetzner_Sd_Configs
        {
            public string role { get; set; }
            public Authorization2 authorization { get; set; }
            public Basic_Auth2 basic_auth { get; set; }
        }

        public class Authorization2
        {
            public string credentials { get; set; }
        }

        public class Basic_Auth2
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        public class Eureka_Sd_Configs
        {
            public string server { get; set; }
        }

        public class Scaleway_Sd_Configs
        {
            public string role { get; set; }
            public string project_id { get; set; }
            public string access_key { get; set; }
            public string secret_key { get; set; }
        }

        public class Linode_Sd_Configs
        {
            public Authorization3 authorization { get; set; }
        }

        public class Authorization3
        {
            public string credentials { get; set; }
        }

        public class Uyuni_Sd_Configs
        {
            public string server { get; set; }
            public string username { get; set; }
            public string password { get; set; }
        }


    }
}
