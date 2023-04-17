using BHub.Challenge.Backend.Main;

/// <summary>
/// Entry Class
/// </summary>
class Program
{
    /// <summary>
    /// Program entry point.
    /// </summary>
    /// <param name="args">arguments</param>
    static void Main(string[] args)
    {
        new SamplePluginMain().Execute();
    }
}