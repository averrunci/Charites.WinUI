// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls.Primitives;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="FlyoutBaseClosingEventArgs"/>
/// resolved by <see cref="IFlyoutBaseClosingEventArgsResolver"/>.
/// </summary>
public static class FlyoutBaseClosingEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IFlyoutBaseClosingEventArgsResolver"/>
    /// that resolves data of the <see cref="FlyoutBaseClosingEventArgs"/>.
    /// </summary>
    public static IFlyoutBaseClosingEventArgsResolver Resolver { get; set; } = new DefaultFlyoutBaseClosingEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether the flyout should be prevented from closing.
    /// </summary>
    /// <param name="e">The requested <see cref="FlyoutBaseClosingEventArgs"/>.</param>
    /// <returns><c>true</c> to prevent the flyout from closing; otherwise, <c>false</c>.</returns>
    public static bool Cancel(this FlyoutBaseClosingEventArgs e) => Resolver.Cancel(e);

    /// <summary>
    /// Sets a value that indicates whether the flyout should be prevented from closing.
    /// </summary>
    /// <param name="e">The requested <see cref="FlyoutBaseClosingEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> to prevent the flyout from closing; otherwise, <c>false</c>.</param>
    public static void Cancel(this FlyoutBaseClosingEventArgs e, bool cancel) => Resolver.Cancel(e, cancel);

    private sealed class DefaultFlyoutBaseClosingEventArgsResolver : IFlyoutBaseClosingEventArgsResolver
    {
        bool IFlyoutBaseClosingEventArgsResolver.Cancel(FlyoutBaseClosingEventArgs e) => e.Cancel;
        void IFlyoutBaseClosingEventArgsResolver.Cancel(FlyoutBaseClosingEventArgs e, bool cancel) => e.Cancel = cancel;
    }
}

/// <summary>
/// Resolves data of the <see cref="FlyoutBaseClosingEventArgs"/>.
/// </summary>
public interface IFlyoutBaseClosingEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether the flyout should be prevented from closing.
    /// </summary>
    /// <param name="e">The requested <see cref="FlyoutBaseClosingEventArgs"/>.</param>
    /// <returns><c>true</c> to prevent the flyout from closing; otherwise, <c>false</c>.</returns>
    bool Cancel(FlyoutBaseClosingEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether the flyout should be prevented from closing.
    /// </summary>
    /// <param name="e">The requested <see cref="FlyoutBaseClosingEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> to prevent the flyout from closing; otherwise, <c>false</c>.</param>
    void Cancel(FlyoutBaseClosingEventArgs e, bool cancel);
}