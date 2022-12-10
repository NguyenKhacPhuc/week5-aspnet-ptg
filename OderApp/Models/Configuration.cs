namespace OderApp.Models;

public class Configuration
{
    public Configuration(string policy = null, string rules = null, string address = null)
    {
        Policy = policy ?? throw new ArgumentNullException(nameof(policy));
        Rules = rules ?? throw new ArgumentNullException(nameof(rules));
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }

    public string Policy { get; set; }
    public string Rules { get; set; }
    public string Address { get; set; }
}