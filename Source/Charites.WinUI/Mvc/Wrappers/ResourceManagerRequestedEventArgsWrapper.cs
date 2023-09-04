// Copyright (C) 2023 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;
using Microsoft.Windows.ApplicationModel.Resources;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="ResourceManagerRequestedEventArgs"/>
/// resolved by <see cref="IResourceManagerRequestedEventArgsResolver"/>.
/// </summary>
public static class ResourceManagerRequestedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IResourceManagerRequestedEventArgsResolver"/>
    /// that resolves data of the <see cref="ResourceManagerRequestedEventArgs"/>.
    /// </summary>
    public static IResourceManagerRequestedEventArgsResolver Resolver { get; set; } = new DefaultResourceManagerRequestedEventArgsResolver();

    /// <summary>
    /// Gets the custom resource manager.
    /// </summary>
    /// <param name="e">The requested <see cref="ResourceManagerRequestedEventArgs"/>.</param>
    /// <returns>The custom resource manager.</returns>
    public static IResourceManager CustomResourceManager(this ResourceManagerRequestedEventArgs e) => Resolver.CustomResourceManager(e);

    /// <summary>
    /// Sets the custom resource manager.
    /// </summary>
    /// <param name="e">The requested <see cref="ResourceManagerRequestedEventArgs"/>.</param>
    /// <param name="customResourceManager">The custom resource manager.</param>
    public static void CustomResourceManager(this ResourceManagerRequestedEventArgs e, IResourceManager customResourceManager) => Resolver.CustomResourceManager(e, customResourceManager);

    private sealed class DefaultResourceManagerRequestedEventArgsResolver : IResourceManagerRequestedEventArgsResolver
    {
        IResourceManager IResourceManagerRequestedEventArgsResolver.CustomResourceManager(ResourceManagerRequestedEventArgs e) => e.CustomResourceManager;
        void IResourceManagerRequestedEventArgsResolver.CustomResourceManager(ResourceManagerRequestedEventArgs e, IResourceManager customResourceManager) => e.CustomResourceManager = customResourceManager;
    }
}

/// <summary>
/// Resolves data of the <see cref="ResourceManagerRequestedEventArgs"/>.
/// </summary>
public interface IResourceManagerRequestedEventArgsResolver
{
    /// <summary>
    /// Gets the custom resource manager.
    /// </summary>
    /// <param name="e">The requested <see cref="ResourceManagerRequestedEventArgs"/>.</param>
    /// <returns>The custom resource manager.</returns>
    IResourceManager CustomResourceManager(ResourceManagerRequestedEventArgs e);

    /// <summary>
    /// Sets the custom resource manager.
    /// </summary>
    /// <param name="e">The requested <see cref="ResourceManagerRequestedEventArgs"/>.</param>
    /// <param name="customResourceManager">The custom resource manager.</param>
    void CustomResourceManager(ResourceManagerRequestedEventArgs e, IResourceManager customResourceManager);
}