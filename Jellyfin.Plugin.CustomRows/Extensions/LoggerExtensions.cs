using System;
using Microsoft.Extensions.Logging;

namespace Jellyfin.Plugin.CustomRows.Extensions;

/// <summary>
/// Logger extensions for Custom Rows plugin
/// </summary>
public static class LoggerExtensions
{
    private const string PREFIX = "CustomRows: ";

    /// <summary>
    /// Log information with plugin prefix
    /// </summary>
    public static void LogCustomRowsInfo(this ILogger logger, string message, params object[] args)
    {
        logger.LogInformation(PREFIX + message, args);
    }

    /// <summary>
    /// Log error with plugin prefix
    /// </summary>
    public static void LogCustomRowsError(this ILogger logger, Exception exception, string message, params object[] args)
    {
        logger.LogError(exception, PREFIX + message, args);
    }

    /// <summary>
    /// Log warning with plugin prefix
    /// </summary>
    public static void LogCustomRowsWarning(this ILogger logger, string message, params object[] args)
    {
        logger.LogWarning(PREFIX + message, args);
    }

    /// <summary>
    /// Log debug with plugin prefix (only when debug mode is enabled)
    /// </summary>
    public static void LogCustomRowsDebug(this ILogger logger, string message, params object[] args)
    {
        var config = Plugin.Instance?.Configuration;
        if (config?.DebugMode == true)
        {
            logger.LogDebug(PREFIX + message, args);
        }
    }
}