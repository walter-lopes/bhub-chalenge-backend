namespace PluginComponent;

public interface IPlugin
{
    string Name { get; }
    
    void DoAction();
}