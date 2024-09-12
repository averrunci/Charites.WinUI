// Copyright (C) 2024 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers
{
    /// <summary>
    /// Provides data of the <see cref="TabViewTabTearOutRequestedEventArgs"/>
    /// resolved by <see cref="ITabViewTabTearOutRequestedEventArgsResolver"/>.
    /// </summary>
    public static class TabViewTabTearOutRequestedEventArgsWrapper
    {
        /// <summary>
        /// Gets or sets the <see cref="ITabViewTabTearOutRequestedEventArgsResolver"/>
        /// that resolves data of the <see cref="TabViewTabTearOutRequestedEventArgs"/>.
        /// </summary>
        public static ITabViewTabTearOutRequestedEventArgsResolver Resolver { get; set; } = new DefaultTabViewTabTearOutRequestedEventArgsResolver();

        /// <summary>
        /// Gets the items to tear out.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewTabTearOutRequestedEventArgs"/>.</param>
        /// <returns>The items to tear out.</returns>
        public static object[] Items(this TabViewTabTearOutRequestedEventArgs e) => Resolver.Items(e);

        /// <summary>
        /// Gets the new window id.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewTabTearOutRequestedEventArgs"/>.</param>
        /// <returns>The new window id.</returns>
        public static WindowId NewWindowId(this TabViewTabTearOutRequestedEventArgs e) => Resolver.NewWindowId(e);

        /// <summary>
        /// Gets the tabs to tear out.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewTabTearOutRequestedEventArgs"/>.</param>
        /// <returns>The tabs to tear out.</returns>
        public static UIElement[] Tabs(this TabViewTabTearOutRequestedEventArgs e) => Resolver.Tabs(e);

        private sealed class DefaultTabViewTabTearOutRequestedEventArgsResolver : ITabViewTabTearOutRequestedEventArgsResolver
        {
            object[] ITabViewTabTearOutRequestedEventArgsResolver.Items(TabViewTabTearOutRequestedEventArgs e) => e.Items;
            WindowId ITabViewTabTearOutRequestedEventArgsResolver.NewWindowId(TabViewTabTearOutRequestedEventArgs e) => e.NewWindowId;
            UIElement[] ITabViewTabTearOutRequestedEventArgsResolver.Tabs(TabViewTabTearOutRequestedEventArgs e) => e.Tabs;
        }
    }

    /// <summary>
    /// Resolves data of the <see cref="TabViewTabTearOutRequestedEventArgs"/>.
    /// </summary>
    public interface ITabViewTabTearOutRequestedEventArgsResolver
    {
        /// <summary>
        /// Gets the items to tear out.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewTabTearOutRequestedEventArgs"/>.</param>
        /// <returns>The items to tear out.</returns>
        object[] Items(TabViewTabTearOutRequestedEventArgs e);

        /// <summary>
        /// Gets the new window id.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewTabTearOutRequestedEventArgs"/>.</param>
        /// <returns>The new window id.</returns>
        WindowId NewWindowId(TabViewTabTearOutRequestedEventArgs e);

        /// <summary>
        /// Gets the tabs to tear out.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewTabTearOutRequestedEventArgs"/>.</param>
        /// <returns>The tabs to tear out.</returns>
        UIElement[] Tabs(TabViewTabTearOutRequestedEventArgs e);
    }
}