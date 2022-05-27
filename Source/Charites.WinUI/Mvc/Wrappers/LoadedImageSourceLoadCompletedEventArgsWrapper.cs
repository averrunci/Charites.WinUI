// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Media;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="LoadedImageSourceLoadCompletedEventArgs"/>
/// resolved by <see cref="ILoadedImageSourceLoadCompletedEventArgsResolver"/>.
/// </summary>
public static class LoadedImageSourceLoadCompletedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ILoadedImageSourceLoadCompletedEventArgsResolver"/>
    /// that resolves data of the <see cref="LoadedImageSourceLoadCompletedEventArgs"/>.
    /// </summary>
    public static ILoadedImageSourceLoadCompletedEventArgsResolver Resolver { get; set; } = new DefaultLoadedImageSourceLoadCompletedEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether the operation was successful. If it failed, indicates the reason for the failure.
    /// </summary>
    /// <param name="e">The requested <see cref="LoadedImageSourceLoadCompletedEventArgs"/>.</param>
    /// <returns>
    /// A value of the enumeration that indicates whether the operation was successful. If it failed, indicates the reason for the failure.
    /// </returns>
    public static LoadedImageSourceLoadStatus Status(this LoadedImageSourceLoadCompletedEventArgs e) => Resolver.Status(e);

    private sealed class DefaultLoadedImageSourceLoadCompletedEventArgsResolver : ILoadedImageSourceLoadCompletedEventArgsResolver
    {
        LoadedImageSourceLoadStatus ILoadedImageSourceLoadCompletedEventArgsResolver.Status(LoadedImageSourceLoadCompletedEventArgs e) => e.Status;
    }
}

/// <summary>
/// Resolves data of the <see cref="LoadedImageSourceLoadCompletedEventArgs"/>.
/// </summary>
public interface ILoadedImageSourceLoadCompletedEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether the operation was successful. If it failed, indicates the reason for the failure.
    /// </summary>
    /// <param name="e">The requested <see cref="LoadedImageSourceLoadCompletedEventArgs"/>.</param>
    /// <returns>
    /// A value of the enumeration that indicates whether the operation was successful. If it failed, indicates the reason for the failure.
    /// </returns>
    LoadedImageSourceLoadStatus Status(LoadedImageSourceLoadCompletedEventArgs e);
}