// Copyright (C) 2023 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.

using Microsoft.UI.Xaml.Hosting;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="DesktopWindowXamlSourceTakeFocusRequestedEventArgs"/>
/// resolved by <see cref="IDesktopWindowXamlSourceTakeFocusRequestedEventArgsResolver"/>.
/// </summary>
public static class DesktopWindowXamlSourceTakeFocusRequestedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IDesktopWindowXamlSourceTakeFocusRequestedEventArgsResolver"/>
    /// that resolves data of the <see cref="DesktopWindowXamlSourceTakeFocusRequestedEventArgs"/>.
    /// </summary>
    public static IDesktopWindowXamlSourceTakeFocusRequestedEventArgsResolver Resolver { get; set; } = new DefaultDesktopWindowXamlSourceTakeFocusRequestedEventArgsResolver();

    /// <summary>
    /// Gets the focus navigation request.
    /// </summary>
    /// <param name="e">The requested <see cref="DesktopWindowXamlSourceTakeFocusRequestedEventArgs"/>.</param>
    /// <returns>The focus navigation request.</returns>
    public static XamlSourceFocusNavigationRequest Request(this DesktopWindowXamlSourceTakeFocusRequestedEventArgs e) => Resolver.Request(e);

    private sealed class DefaultDesktopWindowXamlSourceTakeFocusRequestedEventArgsResolver : IDesktopWindowXamlSourceTakeFocusRequestedEventArgsResolver
    {
        XamlSourceFocusNavigationRequest IDesktopWindowXamlSourceTakeFocusRequestedEventArgsResolver.Request(DesktopWindowXamlSourceTakeFocusRequestedEventArgs e) => e.Request;
    }
}

/// <summary>
/// Resolves data of the <see cref="DesktopWindowXamlSourceTakeFocusRequestedEventArgs"/>.
/// </summary>
public interface IDesktopWindowXamlSourceTakeFocusRequestedEventArgsResolver
{
    /// <summary>
    /// Gets the focus navigation request.
    /// </summary>
    /// <param name="e">The requested <see cref="DesktopWindowXamlSourceTakeFocusRequestedEventArgs"/>.</param>
    /// <returns>The focus navigation request.</returns>
    XamlSourceFocusNavigationRequest Request(DesktopWindowXamlSourceTakeFocusRequestedEventArgs e);
}