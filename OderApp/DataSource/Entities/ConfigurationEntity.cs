namespace OderApp.DataSource.Entities
{
    public class ConfigurationEntity
    {
        public int Id { get; set; }
        public string Policy { get; set; }
        public string Rules { get; set; }
        public string Address { get; set; }

        public ConfigurationEntity(int id, string policy, string rules, string address)
        {
            Id = id;
            Policy = policy;
            Rules = rules;
            Address = address;
        }
    }
}