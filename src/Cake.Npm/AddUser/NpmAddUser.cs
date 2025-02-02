﻿namespace Cake.Npm.AddUser;

using System;
using Core;
using Core.Diagnostics;
using Core.IO;
using Core.Tooling;

/// <summary>
/// Tool for adding a user registry account.
/// </summary>
/// <param name="fileSystem">The file system.</param>
/// <param name="environment">The environment.</param>
/// <param name="processRunner">The process runner.</param>
/// <param name="tools">The tool locator.</param>
/// <param name="log">Cake log instance.</param>
public class NpmAddUser(
    IFileSystem fileSystem,
    ICakeEnvironment environment,
    IProcessRunner processRunner,
    IToolLocator tools,
    ICakeLog log) : NpmTool<NpmAddUserSettings>(fileSystem, environment, processRunner, tools, log)
{

    /// <summary>
    /// Adds a user from the specified settings.
    /// </summary>
    /// <param name="settings">The settings.</param>
    public void AddUser(NpmAddUserSettings settings)
    {
        ArgumentNullException.ThrowIfNull(settings);

        RunCore(settings);
    }
}
