﻿namespace Cake.Npm.Tests.Ci;

using Cake.Npm.Ci;
using Shouldly;
using System;
using Xunit;

public sealed class NpmUpdateSettingsExtensionsTests
{
    public sealed class TheForProductionMethod
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            NpmCiSettings settings = null;

            // When
            var result = Record.Exception(settings.ForProduction);

            // Then
            result.IsArgumentNullException("settings");
        }
        [Fact]
        public void Should_Set_Production()
        {
            // Given
            var settings = new NpmCiSettings();

            // When
            settings.ForProduction();

            // Then
            settings.Production.ShouldBe(true);
        }
    }

    public sealed class TheFromRegistryMethod
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            NpmCiSettings settings = null;
            var registry = new Uri("https://myregistry.com");

            // When
            var result = Record.Exception(() => settings.FromRegistry(registry));

            // Then
            result.IsArgumentNullException("settings");
        }

        [Fact]
        public void Should_Throw_If_Registry_Is_Null()
        {
            // Given
            var settings = new NpmCiSettings();
            Uri registry = null;

            // When
            var result = Record.Exception(() => settings.FromRegistry(registry));

            // Then
            result.IsArgumentNullException("registry");
        }

        [Fact]
        public void Should_Set_Registry()
        {
            // Given
            var settings = new NpmCiSettings();
            var registry = new Uri("https://myregistry.com");

            // When
            var result = settings.FromRegistry(registry);

            // Then
            result.Registry.ShouldBe(registry);
        }
    }
}
