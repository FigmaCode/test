using MediaBrowser.Model.Plugins;

namespace Jellyfin.Plugin.CustomRows.Configuration;

/// <summary>
/// Plugin configuration for Custom Rows
/// </summary>
public class PluginConfiguration : BasePluginConfiguration
{
    /// <summary>
    /// Gets or sets a value indicating whether custom rows are enabled
    /// </summary>
    public bool EnableCustomRows { get; set; } = true;

    /// <summary>
    /// Gets or sets the maximum number of rows to display
    /// </summary>
    public int MaxRows { get; set; } = 8;

    /// <summary>
    /// Gets or sets the maximum number of items per row
    /// </summary>
    public int MaxItemsPerRow { get; set; } = 20;

    /// <summary>
    /// Gets or sets the minimum number of items per row
    /// </summary>
    public int MinItemsPerRow { get; set; } = 5;

    /// <summary>
    /// Gets or sets a value indicating whether to show genre rows
    /// </summary>
    public bool ShowGenreRows { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to show recently added row
    /// </summary>
    public bool ShowRecentlyAddedRow { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to show "My List" row (favorites)
    /// </summary>
    public bool ShowMyListRow { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to show random picks row
    /// </summary>
    public bool ShowRandomPicksRow { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether to show "not watched in a while" row
    /// </summary>
    public bool ShowNotWatchedRow { get; set; } = false;

    /// <summary>
    /// Gets or sets custom CSS to inject into the UI
    /// </summary>
    public string CustomCSS { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets debug mode for logging
    /// </summary>
    public bool DebugMode { get; set; } = false;
}