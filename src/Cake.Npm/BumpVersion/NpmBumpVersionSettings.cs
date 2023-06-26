namespace Cake.Npm.BumpVersion
{
    using Core;
    using Core.IO;

    /// <summary>
    /// Contains settings used by <see cref="NpmBumpVersionTool"/>.
    /// </summary>
    public class NpmBumpVersionSettings : NpmSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmBumpVersionSettings"/> class.
        /// </summary>
        public NpmBumpVersionSettings()
            : base("version")
        {
            Version = "minor";
        }

        /// <summary>
        /// Gets or sets the force-option
        /// </summary>
        public bool Force { get; set; }

        /// <summary>
        /// Gets or sets the commit message.
        /// </summary>
        public string CommitMessage { get; set; }

        /// <summary>
        /// Gets or sets the version to bump to. Should be a valid semver
        /// or one of <c>"patch"</c>, <c>"minor"</c>, <c>"major"</c>, 
        /// <c>"prepatch"</c>, <c>"preminor"</c>, <c>"premajor"</c>, 
        /// <c>"prerelease"</c> or <c>"from-git"</c>.
        /// </summary>
        public string Version  {get;set; }

        /// <summary>
        /// Gets or sets the <c>--git-tag-version</c> option.
        /// Tag the commit when using the <c>npm version</c> command. Setting this to <c>true</c> results in no commit being made at all.
        /// </summary>
        public bool? GitTagVersion { get; set; }

        /// <summary>
        /// Evaluates the settings and writes them to <paramref name="args"/>.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            base.EvaluateCore(args);
            args.Append(Version);

            if (!string.IsNullOrEmpty(CommitMessage))
            {
                args.AppendSwitchQuoted("-m", CommitMessage);
            }

            if (Force)
            {
                args.Append("-f");
            }

            if (GitTagVersion.HasValue)
            {
                args.Append($"--git-tag-version={GitTagVersion.ToString().ToLowerInvariant()}");
            }

        }
    }
}
