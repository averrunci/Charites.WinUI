﻿// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="AnchorRequestedEventArgs"/>
/// resolved by <see cref="IAnchorRequestedEventArgsResolver"/>.
/// </summary>
public static class AnchorRequestedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IAnchorRequestedEventArgsResolver"/>
    /// that resolves data of the <see cref="AnchorRequestedEventArgs"/>.
    /// </summary>
    public static IAnchorRequestedEventArgsResolver Resolver { get; set; } = new DefaultAnchorRequestedEventArgsResolver();

    /// <summary>
    /// Gets the anchor element to use when performing scroll anchoring.
    /// </summary>
    /// <param name="e">The requested <see cref="AnchorRequestedEventArgs"/>.</param>
    /// <returns>The <see cref="UIElement"/> to use as the <see cref="IScrollAnchorProvider.CurrentAnchor"/>.</returns>
    public static UIElement? Anchor(this AnchorRequestedEventArgs e) => Resolver.Anchor(e);

    /// <summary>
    /// Sets the anchor element to use when performing scroll anchoring.
    /// </summary>
    /// <param name="e">The requested <see cref="AnchorRequestedEventArgs"/>.</param>
    /// <param name="anchor">The <see cref="UIElement"/> to use as the <see cref="IScrollAnchorProvider.CurrentAnchor"/>.</param>
    public static void Anchor(this AnchorRequestedEventArgs e, UIElement? anchor) => Resolver.Anchor(e, anchor);

    /// <summary>
    /// Gets the set of anchor candidates that are currently registered with the scrolling control (e.g. <see cref="ScrollViewer"/>).
    /// </summary>
    /// <param name="e">The requested <see cref="AnchorRequestedEventArgs"/>.</param>
    /// <returns>A list of <see cref="UIElement"/> anchor candidates.</returns>
    public static IList<UIElement> AnchorCandidates(this AnchorRequestedEventArgs e) => Resolver.AnchorCandidates(e);

    private sealed class DefaultAnchorRequestedEventArgsResolver : IAnchorRequestedEventArgsResolver
    {
        UIElement? IAnchorRequestedEventArgsResolver.Anchor(AnchorRequestedEventArgs e) => e.Anchor;
        void IAnchorRequestedEventArgsResolver.Anchor(AnchorRequestedEventArgs e, UIElement? anchor) => e.Anchor = anchor;
        IList<UIElement> IAnchorRequestedEventArgsResolver.AnchorCandidates(AnchorRequestedEventArgs e) => e.AnchorCandidates;
    }
}

/// <summary>
/// Resolves data of the <see cref="AnchorRequestedEventArgs"/>.
/// </summary>
public interface IAnchorRequestedEventArgsResolver
{
    /// <summary>
    /// Gets the anchor element to use when performing scroll anchoring.
    /// </summary>
    /// <param name="e">The requested <see cref="AnchorRequestedEventArgs"/>.</param>
    /// <returns>The <see cref="UIElement"/> to use as the <see cref="IScrollAnchorProvider.CurrentAnchor"/>.</returns>
    UIElement? Anchor(AnchorRequestedEventArgs e);

    /// <summary>
    /// Sets the anchor element to use when performing scroll anchoring.
    /// </summary>
    /// <param name="e">The requested <see cref="AnchorRequestedEventArgs"/>.</param>
    /// <param name="anchor">The <see cref="UIElement"/> to use as the <see cref="IScrollAnchorProvider.CurrentAnchor"/>.</param>
    void Anchor(AnchorRequestedEventArgs e, UIElement? anchor);

    /// <summary>
    /// Gets the set of anchor candidates that are currently registered with the scrolling control (e.g. <see cref="ScrollViewer"/>).
    /// </summary>
    /// <param name="e">The requested <see cref="AnchorRequestedEventArgs"/>.</param>
    /// <returns>A list of <see cref="UIElement"/> anchor candidates.</returns>
    IList<UIElement> AnchorCandidates(AnchorRequestedEventArgs e);
}