// Copyright (C) 2022-2024 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using System.Drawing;
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2ContextMenuRequestedEventArgs"/>
/// resolved by <see cref="ICoreWebView2ContextMenuRequestedEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2ContextMenuRequestedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2ContextMenuRequestedEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2ContextMenuRequestedEventArgs"/>.
    /// </summary>
    public static ICoreWebView2ContextMenuRequestedEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2ContextMenuRequestedEventArgsResolver();

    /// <summary>
    /// Gets the target information associated with the requested context menu.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ContextMenuRequestedEventArgs"/>.</param>
    /// <returns>The target information associated with the requested context menu.</returns>
    public static CoreWebView2ContextMenuTarget ContextMenuTarget(this CoreWebView2ContextMenuRequestedEventArgs e) => Resolver.ContextMenuTarget(e);

    /// <summary>
    /// Gets a value that indicates whether the <see cref="CoreWebView2.ContextMenuRequested"/> event is handled by host
    /// after the event handler completes or after the deferral is completed if there is a taken <see cref="CoreWebView2Deferral"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ContextMenuRequestedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the <see cref="CoreWebView2.ContextMenuRequested"/> event is handled by host; otherwise, <c>false</c>.
    /// </returns>
    public static bool Handled(this CoreWebView2ContextMenuRequestedEventArgs e) => Resolver.Handled(e);

    /// <summary>
    /// Sets a value that indicates whether the <see cref="CoreWebView2.ContextMenuRequested"/> event is handled by host
    /// after the event handler completes or after the deferral is completed if there is a taken <see cref="CoreWebView2Deferral"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ContextMenuRequestedEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> if the <see cref="CoreWebView2.ContextMenuRequested"/> event is handled by host; otherwise, <c>false</c>.
    /// </param>
    public static void Handled(this CoreWebView2ContextMenuRequestedEventArgs e, bool handled) => Resolver.Handled(e, handled);

    /// <summary>
    /// Gets the coordinates where the context menu request occurred in relation to the upper left corner
    /// of the WebView bounds.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ContextMenuRequestedEventArgs"/>.</param>
    /// <returns>
    /// The coordinates where the context menu request occurred in relation to the upper left corner of the WebView bounds.
    /// </returns>
    public static Point Location(this CoreWebView2ContextMenuRequestedEventArgs e) => Resolver.Location(e);

    /// <summary>
    /// Gets the collection of <see cref="CoreWebView2ContextMenuItem"/> objects.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ContextMenuRequestedEventArgs"/>.</param>
    /// <returns>The collection of <see cref="CoreWebView2ContextMenuItem"/> objects.</returns>
    public static IList<CoreWebView2ContextMenuItem> MenuItems(this CoreWebView2ContextMenuRequestedEventArgs e) => Resolver.MenuItems(e);

    /// <summary>
    /// Gets the selected <see cref="CoreWebView2ContextMenuItem"/>'s <see cref="CoreWebView2ContextMenuItem.CommandId"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ContextMenuRequestedEventArgs"/>.</param>
    /// <returns>
    /// The selected <see cref="CoreWebView2ContextMenuItem"/>'s <see cref="CoreWebView2ContextMenuItem.CommandId"/>.
    /// </returns>
    public static int SelectedCommandId(this CoreWebView2ContextMenuRequestedEventArgs e) => Resolver.SelectedCommandId(e);

    /// <summary>
    /// Sets the selected <see cref="CoreWebView2ContextMenuItem"/>'s <see cref="CoreWebView2ContextMenuItem.CommandId"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ContextMenuRequestedEventArgs"/>.</param>
    /// <param name="selectedCommandId">
    /// The selected <see cref="CoreWebView2ContextMenuItem"/>'s <see cref="CoreWebView2ContextMenuItem.CommandId"/>.
    /// </param>
    public static void SelectedCommandId(this CoreWebView2ContextMenuRequestedEventArgs e, int selectedCommandId) => Resolver.SelectedCommandId(e, selectedCommandId);

    /// <summary>
    /// Gets a <see cref="CoreWebView2Deferral"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ContextMenuRequestedEventArgs"/>.</param>
    /// <returns>A <see cref="CoreWebView2Deferral"/> object.</returns>
    public static CoreWebView2Deferral GetDeferralWrapped(this CoreWebView2ContextMenuRequestedEventArgs e) => Resolver.GetDeferral(e);

    private sealed class DefaultCoreWebView2ContextMenuRequestedEventArgsResolver : ICoreWebView2ContextMenuRequestedEventArgsResolver
    {
        CoreWebView2ContextMenuTarget ICoreWebView2ContextMenuRequestedEventArgsResolver.ContextMenuTarget(CoreWebView2ContextMenuRequestedEventArgs e) => e.ContextMenuTarget;
        bool ICoreWebView2ContextMenuRequestedEventArgsResolver.Handled(CoreWebView2ContextMenuRequestedEventArgs e) => e.Handled;
        void ICoreWebView2ContextMenuRequestedEventArgsResolver.Handled(CoreWebView2ContextMenuRequestedEventArgs e, bool handled) => e.Handled = handled;
        Point ICoreWebView2ContextMenuRequestedEventArgsResolver.Location(CoreWebView2ContextMenuRequestedEventArgs e) => e.Location;
        IList<CoreWebView2ContextMenuItem> ICoreWebView2ContextMenuRequestedEventArgsResolver.MenuItems(CoreWebView2ContextMenuRequestedEventArgs e) => e.MenuItems;
        int ICoreWebView2ContextMenuRequestedEventArgsResolver.SelectedCommandId(CoreWebView2ContextMenuRequestedEventArgs e) => e.SelectedCommandId;
        void ICoreWebView2ContextMenuRequestedEventArgsResolver.SelectedCommandId(CoreWebView2ContextMenuRequestedEventArgs e, int selectedCommandId) => e.SelectedCommandId = selectedCommandId;
        CoreWebView2Deferral ICoreWebView2ContextMenuRequestedEventArgsResolver.GetDeferral(CoreWebView2ContextMenuRequestedEventArgs e) => e.GetDeferral();
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2ContextMenuRequestedEventArgs"/>.
/// </summary>
public interface ICoreWebView2ContextMenuRequestedEventArgsResolver
{
    /// <summary>
    /// Gets the target information associated with the requested context menu.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ContextMenuRequestedEventArgs"/>.</param>
    /// <returns>The target information associated with the requested context menu.</returns>
    CoreWebView2ContextMenuTarget ContextMenuTarget(CoreWebView2ContextMenuRequestedEventArgs e);

    /// <summary>
    /// Gets a value that indicates whether the <see cref="CoreWebView2.ContextMenuRequested"/> event is handled by host
    /// after the event handler completes or after the deferral is completed if there is a taken <see cref="CoreWebView2Deferral"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ContextMenuRequestedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> if the <see cref="CoreWebView2.ContextMenuRequested"/> event is handled by host; otherwise, <c>false</c>.
    /// </returns>
    bool Handled(CoreWebView2ContextMenuRequestedEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether the <see cref="CoreWebView2.ContextMenuRequested"/> event is handled by host
    /// after the event handler completes or after the deferral is completed if there is a taken <see cref="CoreWebView2Deferral"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ContextMenuRequestedEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> if the <see cref="CoreWebView2.ContextMenuRequested"/> event is handled by host; otherwise, <c>false</c>.
    /// </param>
    void Handled(CoreWebView2ContextMenuRequestedEventArgs e, bool handled);

    /// <summary>
    /// Gets the coordinates where the context menu request occurred in relation to the upper left corner
    /// of the WebView bounds.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ContextMenuRequestedEventArgs"/>.</param>
    /// <returns>
    /// The coordinates where the context menu request occurred in relation to the upper left corner of the WebView bounds.
    /// </returns>
    Point Location(CoreWebView2ContextMenuRequestedEventArgs e);

    /// <summary>
    /// Gets the collection of <see cref="CoreWebView2ContextMenuItem"/> objects.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ContextMenuRequestedEventArgs"/>.</param>
    /// <returns>The collection of <see cref="CoreWebView2ContextMenuItem"/> objects.</returns>
    IList<CoreWebView2ContextMenuItem> MenuItems(CoreWebView2ContextMenuRequestedEventArgs e);

    /// <summary>
    /// Gets the selected <see cref="CoreWebView2ContextMenuItem"/>'s <see cref="CoreWebView2ContextMenuItem.CommandId"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ContextMenuRequestedEventArgs"/>.</param>
    /// <returns>
    /// The selected <see cref="CoreWebView2ContextMenuItem"/>'s <see cref="CoreWebView2ContextMenuItem.CommandId"/>.
    /// </returns>
    int SelectedCommandId(CoreWebView2ContextMenuRequestedEventArgs e);

    /// <summary>
    /// Sets the selected <see cref="CoreWebView2ContextMenuItem"/>'s <see cref="CoreWebView2ContextMenuItem.CommandId"/>.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ContextMenuRequestedEventArgs"/>.</param>
    /// <param name="selectedCommandId">
    /// The selected <see cref="CoreWebView2ContextMenuItem"/>'s <see cref="CoreWebView2ContextMenuItem.CommandId"/>.
    /// </param>
    void SelectedCommandId(CoreWebView2ContextMenuRequestedEventArgs e, int selectedCommandId);

    /// <summary>
    /// Gets a <see cref="CoreWebView2Deferral"/> object.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2ContextMenuRequestedEventArgs"/>.</param>
    /// <returns>A <see cref="CoreWebView2Deferral"/> object.</returns>
    CoreWebView2Deferral GetDeferral(CoreWebView2ContextMenuRequestedEventArgs e);
}