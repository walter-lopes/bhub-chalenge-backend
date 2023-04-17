using PluginComponent;

namespace BookPaymentPlugin;

public class BookPaymentPlugin : IPlugin
{
        /// <summary> Plugin Name </summary>
        public string Name { get; } = "BookPayment";
        
        /// <summary> Execute </summary>
        public void DoAction()
        {
            Console.WriteLine("Retrieving current book payment and running the business rule..");
        }
}