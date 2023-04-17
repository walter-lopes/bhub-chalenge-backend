using PluginComponent;

namespace PhysicalProductPaymentPlugin;

public class PhysicalProductPaymentPlugin : IPlugin
{
    /// <summary> Plugin Name </summary>
    public string Name { get; } = "PhysicalProductPaymentPlugin";
        
    /// <summary> Execute </summary>
    public void DoAction()
    {
        Console.WriteLine("Retrieving current Physical Product Payment and running the business rule..");
    }
}