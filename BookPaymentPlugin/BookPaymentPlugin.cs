using PluginComponent;

namespace BookPaymentPlugin;

public class BookPaymentPlugin : IPlugin
{
        /// <summary> Plugin Name </summary>
        public string Name { get; } = "BookPayment";
        
        /// <summary> Execute </summary>
        public void DoAction()
        {
            Console.WriteLine("I`m BookPayment Plugin.");
        }
}