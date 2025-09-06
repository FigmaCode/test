using MediaBrowser.Controller;
using MediaBrowser.Controller.Plugins;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Jellyfin.Plugin.CustomRows;

/// <summary>
/// Plugin service registrator for dependency injection and initialization
/// </summary>
public class PluginServiceRegistrator : IPluginServiceRegistrator
{
    /// <inheritdoc />
    public void RegisterServices(IServiceCollection serviceCollection, IServerApplicationHost applicationHost)
    {
        // Register any services that the plugin needs
        // For now, we keep it minimal
    }
}

/// <summary>
/// Server entry point for plugin initialization
/// </summary>
public class ServerEntryPoint : IServerEntryPoint
{
    private readonly ILogger<ServerEntryPoint> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ServerEntryPoint"/> class.
    /// </summary>
    /// <param name="logger">Instance of the <see cref="ILogger{ServerEntryPoint}"/> interface.</param>
    public ServerEntryPoint(ILogger<ServerEntryPoint> logger)
    {
        _logger = logger;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        // Cleanup if needed
    }

    /// <inheritdoc />
    public void RunAsync()
    {
        _logger.LogInformation("Custom Rows Plugin: Server entry point running...");
        
        // Initialize the plugin
        Plugin.Instance?.Initialize();
    }
}