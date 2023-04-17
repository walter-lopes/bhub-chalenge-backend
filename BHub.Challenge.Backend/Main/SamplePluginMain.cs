using BHub.Challenge.Backend.Utils;
using PluginComponent;

namespace BHub.Challenge.Backend.Main;

public class SamplePluginMain
{
    /// <summary>
    /// Do Action.
    /// </summary>
    public void Execute()
    {
        var endflag = false;
        do
        {
            var plugins = PluginLoader.LoadPlugins(SettingsUtils.SettingsUtil.GetAppSettings("pluginPath"));
            ShowMenu(plugins);
            var input = Console.ReadLine();
            if (input != "z")
            {
                if (!int.TryParse(input, out int result) || plugins.Count <= result)
                {
                    Console.WriteLine("Please input again.");
                }
                else
                {
                    plugins.ElementAt(result).DoAction();
                }
            }
            else
            {
                endflag = true;
            }
        } while (!endflag);
    }

    private void ShowMenu(ICollection<IPlugin> plugins)
    {
        Console.WriteLine("=== MENU ====");
        foreach (var plugin in plugins.Select((value, i) => new {value, i}))
        {
            Console.WriteLine("[{0:00}] : {1}", plugin.i, plugin.value.Name);
        }

        Console.WriteLine("[ z] : END");
    }
}