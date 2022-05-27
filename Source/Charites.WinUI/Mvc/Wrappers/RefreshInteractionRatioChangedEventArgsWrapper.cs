// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="RefreshInteractionRatioChangedEventArgs"/>
/// resolved by <see cref="IRefreshInteractionRatioChangedEventArgsResolver"/>.
/// </summary>
public static class RefreshInteractionRatioChangedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IRefreshInteractionRatioChangedEventArgsResolver"/>
    /// that resolves data of the <see cref="RefreshInteractionRatioChangedEventArgs"/>.
    /// </summary>
    public static IRefreshInteractionRatioChangedEventArgsResolver Resolver { get; set; } = new DefaultRefreshInteractionRatioChangedEventArgsResolver();

    /// <summary>
    /// Gets the interaction ratio value.
    /// </summary>
    /// <param name="e">The requested <see cref="RefreshInteractionRatioChangedEventArgs"/>.</param>
    /// <returns>The interaction ratio value.</returns>
    public static double InteractionRatio(this RefreshInteractionRatioChangedEventArgs e) => Resolver.InteractionRatio(e);

    private sealed class DefaultRefreshInteractionRatioChangedEventArgsResolver : IRefreshInteractionRatioChangedEventArgsResolver
    {
        double IRefreshInteractionRatioChangedEventArgsResolver.InteractionRatio(RefreshInteractionRatioChangedEventArgs e) => e.InteractionRatio;
    }
}

/// <summary>
/// Resolves data of the <see cref="RefreshInteractionRatioChangedEventArgs"/>.
/// </summary>
public interface IRefreshInteractionRatioChangedEventArgsResolver
{
    /// <summary>
    /// Gets the interaction ratio value.
    /// </summary>
    /// <param name="e">The requested <see cref="RefreshInteractionRatioChangedEventArgs"/>.</param>
    /// <returns>The interaction ratio value.</returns>
    double InteractionRatio(RefreshInteractionRatioChangedEventArgs e);
}