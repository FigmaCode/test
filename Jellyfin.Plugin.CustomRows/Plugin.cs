using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;
using Jellyfin.Plugin.CustomRows.Configuration;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;
using Microsoft.Extensions.Logging;

namespace Jellyfin.Plugin.CustomRows;

/// <summary>
/// Custom Rows Plugin for Jellyfin - allows creating custom home screen rows
/// </summary>
public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
{
    private readonly ILogger<Plugin> _logger;

    public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer, ILogger<Plugin> logger)
        : base(applicationPaths, xmlSerializer)
    {
        _logger = logger;
        Instance = this;
    }

    /// <inheritdoc />
    public override string Name => "Custom Rows";

    /// <inheritdoc />
    public override Guid Id => Guid.Parse("f2f8b500-2b43-4f72-9b2a-d4a5c8e7f1a9");

    /// <summary>
    /// Gets the current plugin instance.
    /// </summary>
    public static Plugin? Instance { get; private set; }

    /// <inheritdoc />
    public IEnumerable<PluginPageInfo> GetPages()
    {
        return new[]
        {
            new PluginPageInfo
            {
                Name = this.Name,
                EmbeddedResourcePath = GetType().Namespace + ".Configuration.configPage.html"
            }
        };
    }

    /// <summary>
    /// Initialize plugin and register UI transformations
    /// </summary>
    public void Initialize()
    {
        _logger.LogInformation("Custom Rows Plugin initializing...");
        
        try 
        {
            RegisterFileTransformation();
            RegisterPluginPage();
            _logger.LogInformation("Custom Rows Plugin initialized successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to initialize Custom Rows Plugin");
        }
    }

    /// <summary>
    /// Register with File Transformation plugin to modify UI
    /// </summary>
    private void RegisterFileTransformation()
    {
        var payload = new
        {
            id = Guid.NewGuid(),
            fileNamePattern = @".*index\.html$",
            callbackAssembly = GetType().Assembly.FullName,
            callbackClass = "Jellyfin.Plugin.CustomRows.Services.UITransformationService",
            callbackMethod = "TransformHomePage"
        };

        // Find File Transformation plugin assembly
        Assembly? fileTransformationAssembly =
            AssemblyLoadContext.All
                .SelectMany(x => x.Assemblies)
                .FirstOrDefault(x => x.FullName?.Contains(".FileTransformation") ?? false);

        if (fileTransformationAssembly != null)
        {
            Type? pluginInterfaceType = fileTransformationAssembly
                .GetType("Jellyfin.Plugin.FileTransformation.PluginInterface");
            
            if (pluginInterfaceType != null)
            {
                pluginInterfaceType.GetMethod("RegisterTransformation")
                    ?.Invoke(null, new object?[] { Newtonsoft.Json.JsonConvert.SerializeObject(payload) });
                
                _logger.LogInformation("Successfully registered file transformation");
            }
            else
            {
                _logger.LogWarning("Could not find File Transformation PluginInterface type");
            }
        }
        else
        {
            _logger.LogWarning("File Transformation plugin not found - UI modifications will not work");
        }
    }

    /// <summary>
    /// Register plugin page with Plugin Pages
    /// </summary>
    private void RegisterPluginPage()
    {
        // For now we'll keep this simple and let the standard Jellyfin config page handle it
        // Later we can integrate with Plugin Pages for a better UI
        _logger.LogCustomRowsInfo("Plugin page registration completed");
    }
}