namespace OderApp.DataSource.Entities
{
    public class ConfigurationEntity
    {
        public string Policy { get; set; }
        public string Rules { get; set; }
        public string Address { get; set; }

        public ConfigurationEntity(string policy, string rules, string address)
        {
            Policy = policy;
            Rules = rules;
            Address = address;
        }
    }
}