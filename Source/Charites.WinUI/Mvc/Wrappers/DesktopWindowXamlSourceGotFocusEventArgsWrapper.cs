// Copyright (C) 2023 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Hosting;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="DesktopWindowXamlSourceGotFocusEventArgs"/>
/// resolved by <see cref="IDesktopWindowXamlSourceGotFocusEventArgsResolver"/>.
/// </summary>
public static class DesktopWindowXamlSourceGotFocusEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IDesktopWindowXamlSourceGotFocusEventArgsResolver"/>
    /// that resolves data of the <see cref="DesktopWindowXamlSourceGotFocusEventArgs"/>.
    /// </summary>
    public static IDesktopWindowXamlSourceGotFocusEventArgsResolver Resolver { get; set; } = new DefaultDesktopWindowXamlSourceGotFocusEventArgsResolver();

    /// <summary>
    /// Gets the focus navigation request.
    /// </summary>
    /// <param name="e">The requested <see cref="DesktopWindowXamlSourceGotFocusEventArgs"/>.</param>
    /// <returns>The focus navigation request.</returns>
    public static XamlSourceFocusNavigationRequest Request(this DesktopWindowXamlSourceGotFocusEventArgs e) => Resolver.Request(e);

    private sealed class DefaultDesktopWindowXamlSourceGotFocusEventArgsResolver : IDesktopWindowXamlSourceGotFocusEventArgsResolver
    {
        XamlSourceFocusNavigationRequest IDesktopWindowXamlSourceGotFocusEventArgsResolver.Request(DesktopWindowXamlSourceGotFocusEventArgs e) => e.Request;
    }
}

/// <summary>
/// Resolves data of the <see cref="DesktopWindowXamlSourceGotFocusEventArgs"/>.
/// </summary>
public interface IDesktopWindowXamlSourceGotFocusEventArgsResolver
{
    /// <summary>
    /// Gets the focus navigation request.
    /// </summary>
    /// <param name="e">The requested <see cref="DesktopWindowXamlSourceGotFocusEventArgs"/>.</param>
    /// <returns>The focus navigation request.</returns>
    XamlSourceFocusNavigationRequest Request(DesktopWindowXamlSourceGotFocusEventArgs e);
}