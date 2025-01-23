namespace Cake.Npm.Prune;

using System;

/// <summary>
/// Extensions for <see cref="NpmPruneSettings"/>.
/// </summary>
public static class NpmPruneSettingsExtensions
{
    /// <summary>
    /// Defines that npm should remove modules listed in <c>devDependencies</c>.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <returns>The <paramref name="settings"/> instance with <see cref="NpmPruneSettings.Production"/> set to <c>true</c>.</returns>
    public static NpmPruneSettings ForProduction(this NpmPruneSettings settings)
    {
        return settings.ForProduction(true);
    }

    /// <summary>
    /// Defines whether npm should remove modules listed in <c>devDependencies</c>.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <param name="production">True to enable</param>
    /// <returns>The <paramref name="settings"/> instance with <see cref="NpmPruneSettings.Production"/> set to <paramref name="production"/>.</returns>
    public static NpmPruneSettings ForProduction(this NpmPruneSettings settings, bool production)
    {
        ArgumentNullException.ThrowIfNull(settings);

        settings.Production = production;
        return settings;
    }

    /// <summary>
    /// If a package name is added, then only packages matching one of the supplied names are removed.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <param name="packageName">The package name to add.</param>
    /// <returns>The <paramref name="settings"/> instance with the package added to <see cref="NpmPruneSettings.Packages"/>.</returns>
    public static NpmPruneSettings AddPackage(this NpmPruneSettings settings, string packageName)
    {
        return settings.AddPackage(packageName, null);
    }

    /// <summary>
    /// If a package name is added, then only packages matching one of the supplied names are removed.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <param name="packageName">The package name to add.</param>
    /// <param name="scope">The package scope.</param>
    /// <returns>The <paramref name="settings"/> instance with the package added to <see cref="NpmPruneSettings.Packages"/>.</returns>
    public static NpmPruneSettings AddPackage(this NpmPruneSettings settings, string packageName, string scope)
    {
        ArgumentNullException.ThrowIfNull(settings);

        if (string.IsNullOrWhiteSpace(packageName))
        {
            throw new ArgumentNullException(nameof(packageName));
        }

        var resolvedPackageName = packageName;
        if (!string.IsNullOrWhiteSpace(scope))
        {
            if (!scope.StartsWith('@'))
            {
                throw new ArgumentException("Scope should start with @", nameof(scope));
            }

            resolvedPackageName = $"{scope}/{resolvedPackageName}";
        }

        settings.Packages.Add(resolvedPackageName);
        return settings;
    }

    /// <summary>
    /// Set so no changes will actually be made.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <returns>The <paramref name="settings"/> instance with <see cref="NpmPruneSettings.DryRun"/> set to <c>true</c>.</returns>
    public static NpmPruneSettings DryRun(this NpmPruneSettings settings)
    {
        return settings.DryRun(true);
    }

    /// <summary>
    /// If true, then no changes will actually be made.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <param name="dryRun">Whether or not to make changes</param>
    /// <returns>The <paramref name="settings"/> instance with <see cref="NpmPruneSettings.DryRun"/> set to <paramref name="dryRun"/>.</returns>
    public static NpmPruneSettings DryRun(this NpmPruneSettings settings, bool dryRun)
    {
        ArgumentNullException.ThrowIfNull(settings);

        settings.DryRun = dryRun;
        return settings;
    }

    /// <summary>
    /// The changes npm prune made (or would have made with DryRun) are printed as a JSON object.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <returns>The <paramref name="settings"/> instance with <see cref="NpmPruneSettings.Json"/> set to <c>true</c>.</returns>
    public static NpmPruneSettings Json(this NpmPruneSettings settings)
    {
        return settings.Json(true);
    }

    /// <summary>
    /// If true, the changes npm prune made (or would have made with DryRun) are printed as a JSON object.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <param name="json">Whether or not to print json.</param>
    /// <returns>The <paramref name="settings"/> instance with <see cref="NpmPruneSettings.Json"/> set to <paramref name="json"/>.</returns>
    public static NpmPruneSettings Json(this NpmPruneSettings settings, bool json)
    {
        ArgumentNullException.ThrowIfNull(settings);

        settings.Json = json;
        return settings;
    }
}
