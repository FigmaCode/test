using System;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Jellyfin.Plugin.CustomRows.Services;

/// <summary>
/// Service for transforming UI content
/// </summary>
public static class UITransformationService
{
    /// <summary>
    /// Transform the home page HTML content
    /// </summary>
    /// <param name="data">Transformation data containing the file contents</param>
    /// <returns>Modified content</returns>
    public static string TransformHomePage(string data)
    {
        try
        {
            var transformData = JsonConvert.DeserializeObject<TransformationData>(data);
            if (transformData?.Contents == null)
            {
                return data;
            }

            var config = Plugin.Instance?.Configuration;
            if (config == null || !config.EnableCustomRows)
            {
                return transformData.Contents;
            }

            var modifiedContent = transformData.Contents;

            // Log debug info if enabled
            if (config.DebugMode)
            {
                // Debug logging would go here
            }

            // Inject custom CSS if provided
            if (!string.IsNullOrEmpty(config.CustomCSS))
            {
                modifiedContent = InjectCustomCSS(modifiedContent, config.CustomCSS);
            }

            // Inject basic custom rows functionality
            modifiedContent = InjectCustomRowsScript(modifiedContent, config);

            return modifiedContent;
        }
        catch (Exception)
        {
            // Error logging would go here
            // Return original content on error to prevent breaking the UI
            return data;
        }
    }

    /// <summary>
    /// Inject custom CSS into the page
    /// </summary>
    /// <param name="content">Original HTML content</param>
    /// <param name="customCSS">Custom CSS to inject</param>
    /// <returns>Modified HTML content</returns>
    private static string InjectCustomCSS(string content, string customCSS)
    {
        var cssInjection = $@"
<style>
/* Custom Rows Plugin CSS */
{customCSS}
</style>";

        // Insert before closing head tag
        content = content.Replace("</head>", $"{cssInjection}</head>");
        return content;
    }

    /// <summary>
    /// Inject custom rows script into the page
    /// </summary>
    /// <param name="content">Original HTML content</param>
    /// <param name="config">Plugin configuration</param>
    /// <returns>Modified HTML content</returns>
    private static string InjectCustomRowsScript(string content, Configuration.PluginConfiguration config)
    {
        var scriptInjection = $@"
<script>
// Custom Rows Plugin Script
(function() {{
    console.log('Custom Rows Plugin: Initializing...');
    
    // Plugin configuration
    var customRowsConfig = {{
        enableCustomRows: {config.EnableCustomRows.ToString().ToLower()},
        maxRows: {config.MaxRows},
        maxItemsPerRow: {config.MaxItemsPerRow},
        minItemsPerRow: {config.MinItemsPerRow},
        showGenreRows: {config.ShowGenreRows.ToString().ToLower()},
        showRecentlyAddedRow: {config.ShowRecentlyAddedRow.ToString().ToLower()},
        showMyListRow: {config.ShowMyListRow.ToString().ToLower()},
        showRandomPicksRow: {config.ShowRandomPicksRow.ToString().ToLower()},
        showNotWatchedRow: {config.ShowNotWatchedRow.ToString().ToLower()},
        debugMode: {config.DebugMode.ToString().ToLower()}
    }};

    // Wait for page to be ready
    function initCustomRows() {{
        if (customRowsConfig.debugMode) {{
            console.log('Custom Rows Plugin: Configuration loaded', customRowsConfig);
        }}
        
        // Basic UI indication that plugin is loaded
        var indicator = document.createElement('div');
        indicator.style.cssText = 'position: fixed; top: 10px; right: 10px; background: #00a4dc; color: white; padding: 5px 10px; border-radius: 4px; z-index: 9999; font-size: 12px; opacity: 0.8;';
        indicator.textContent = 'Custom Rows Plugin Active';
        document.body.appendChild(indicator);
        
        // Remove indicator after 3 seconds
        setTimeout(function() {{
            if (indicator.parentNode) {{
                indicator.parentNode.removeChild(indicator);
            }}
        }}, 3000);

        if (customRowsConfig.debugMode) {{
            console.log('Custom Rows Plugin: Basic initialization complete');
        }}
    }}

    // Initialize when DOM is ready
    if (document.readyState === 'loading') {{
        document.addEventListener('DOMContentLoaded', initCustomRows);
    }} else {{
        initCustomRows();
    }}
}})();
</script>";

        // Insert before closing body tag
        content = content.Replace("</body>", $"{scriptInjection}</body>");
        return content;
    }

    /// <summary>
    /// Data structure for transformation callback
    /// </summary>
    private class TransformationData
    {
        public string? Contents { get; set; }
    }
}