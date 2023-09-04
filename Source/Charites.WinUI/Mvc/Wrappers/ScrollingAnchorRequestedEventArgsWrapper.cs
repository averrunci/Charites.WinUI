// Copyright (C) 2023 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="ScrollingAnchorRequestedEventArgs"/>
/// resolved by <see cref="IScrollingAnchorRequestedEventArgsResolver"/>.
/// </summary>
public static class ScrollingAnchorRequestedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IScrollingAnchorRequestedEventArgsResolver"/>
    /// that resolves data of the <see cref="ScrollingAnchorRequestedEventArgs"/>.
    /// </summary>
    public static IScrollingAnchorRequestedEventArgsResolver Resolver { get; set; } = new DefaultScrollingAnchorRequestedEventArgsResolver();

    /// <summary>
    /// Gets the collection of anchor element candidates to pick from.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingAnchorRequestedEventArgs"/>.</param>
    /// <returns>The collection of anchor element candidates to pick from.</returns>
    public static IList<UIElement> AnchorCandidates(this ScrollingAnchorRequestedEventArgs e) => Resolver.AnchorCandidates(e);

    /// <summary>
    /// Gets the selected anchor element.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingAnchorRequestedEventArgs"/>.</param>
    /// <returns>The selected anchor element.</returns>
    public static UIElement? AnchorElement(this ScrollingAnchorRequestedEventArgs e) => Resolver.AnchorElement(e);

    /// <summary>
    /// Sets the selected anchor element.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingAnchorRequestedEventArgs"/>.</param>
    /// <param name="anchorElement">The selected anchor element.</param>
    public static void AnchorElement(this ScrollingAnchorRequestedEventArgs e, UIElement? anchorElement) => Resolver.AnchorElement(e, anchorElement);

    private sealed class DefaultScrollingAnchorRequestedEventArgsResolver : IScrollingAnchorRequestedEventArgsResolver
    {
        IList<UIElement> IScrollingAnchorRequestedEventArgsResolver.AnchorCandidates(ScrollingAnchorRequestedEventArgs e) => e.AnchorCandidates;
        UIElement? IScrollingAnchorRequestedEventArgsResolver.AnchorElement(ScrollingAnchorRequestedEventArgs e) => e.AnchorElement;
        void IScrollingAnchorRequestedEventArgsResolver.AnchorElement(ScrollingAnchorRequestedEventArgs e, UIElement? anchorElement) => e.AnchorElement = anchorElement;
    }
}

/// <summary>
/// Resolves data of the <see cref="ScrollingAnchorRequestedEventArgs"/>.
/// </summary>
public interface IScrollingAnchorRequestedEventArgsResolver
{
    /// <summary>
    /// Gets the collection of anchor element candidates to pick from.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingAnchorRequestedEventArgs"/>.</param>
    /// <returns>The collection of anchor element candidates to pick from.</returns>
    IList<UIElement> AnchorCandidates(ScrollingAnchorRequestedEventArgs e);

    /// <summary>
    /// Gets the selected anchor element.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingAnchorRequestedEventArgs"/>.</param>
    /// <returns>The selected anchor element.</returns>
    UIElement? AnchorElement(ScrollingAnchorRequestedEventArgs e);

    /// <summary>
    /// Sets the selected anchor element.
    /// </summary>
    /// <param name="e">The requested <see cref="ScrollingAnchorRequestedEventArgs"/>.</param>
    /// <param name="anchorElement">The selected anchor element.</param>
    void AnchorElement(ScrollingAnchorRequestedEventArgs e, UIElement? anchorElement);
}