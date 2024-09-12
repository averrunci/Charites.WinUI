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
    /// Provides data of the <see cref="TabViewTabTearOutWindowRequestedEventArgs"/>
    /// resolved by <see cref="ITabViewTabTearOutWindowRequestedEventArgsResolver"/>.
    /// </summary>
    public static class TabViewTabTearOutWindowRequestedEventArgsWrapper
    {
        /// <summary>
        /// Gets or sets the <see cref="ITabViewTabTearOutWindowRequestedEventArgsResolver"/>
        /// that resolves data of the <see cref="TabViewTabTearOutWindowRequestedEventArgs"/>.
        /// </summary>
        public static ITabViewTabTearOutWindowRequestedEventArgsResolver Resolver { get; set; } = new DefaultTabViewTabTearOutWindowRequestedEventArgsResolver();

        /// <summary>
        /// Gets the items to tear out.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewTabTearOutWindowRequestedEventArgs"/>.</param>
        /// <returns>The items to tear out.</returns>
        public static object[] Items(this TabViewTabTearOutWindowRequestedEventArgs e) => Resolver.Items(e);

        /// <summary>
        /// Gets the new window id.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewTabTearOutWindowRequestedEventArgs"/>.</param>
        /// <returns>The new window id.</returns>
        public static WindowId NewWindowId(this TabViewTabTearOutWindowRequestedEventArgs e) => Resolver.NewWindowId(e);

        /// <summary>
        /// Sets the new window id.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewTabTearOutWindowRequestedEventArgs"/>.</param>
        /// <param name="newWindowId">The new window id.</param>
        public static void NewWindowId(this TabViewTabTearOutWindowRequestedEventArgs e, WindowId newWindowId) => Resolver.NewWindowId(e, newWindowId);

        /// <summary>
        /// Gets the tabs to tear out.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewTabTearOutWindowRequestedEventArgs"/>.</param>
        /// <returns>The tabs to tear out.</returns>
        public static UIElement[] Tabs(this TabViewTabTearOutWindowRequestedEventArgs e) => Resolver.Tabs(e);

        private sealed class DefaultTabViewTabTearOutWindowRequestedEventArgsResolver : ITabViewTabTearOutWindowRequestedEventArgsResolver
        {
            object[] ITabViewTabTearOutWindowRequestedEventArgsResolver.Items(TabViewTabTearOutWindowRequestedEventArgs e) => e.Items;
            WindowId ITabViewTabTearOutWindowRequestedEventArgsResolver.NewWindowId(TabViewTabTearOutWindowRequestedEventArgs e) => e.NewWindowId;
            void ITabViewTabTearOutWindowRequestedEventArgsResolver.NewWindowId(TabViewTabTearOutWindowRequestedEventArgs e, WindowId newWindowId) => e.NewWindowId = newWindowId;
            UIElement[] ITabViewTabTearOutWindowRequestedEventArgsResolver.Tabs(TabViewTabTearOutWindowRequestedEventArgs e) => e.Tabs;
        }
    }

    /// <summary>
    /// Resolves data of the <see cref="TabViewTabTearOutWindowRequestedEventArgs"/>.
    /// </summary>
    public interface ITabViewTabTearOutWindowRequestedEventArgsResolver
    {
        /// <summary>
        /// Gets the items to tear out.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewTabTearOutWindowRequestedEventArgs"/>.</param>
        /// <returns>The items to tear out.</returns>
        object[] Items(TabViewTabTearOutWindowRequestedEventArgs e);

        /// <summary>
        /// Gets the new window id.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewTabTearOutWindowRequestedEventArgs"/>.</param>
        /// <returns>The new window id.</returns>
        WindowId NewWindowId(TabViewTabTearOutWindowRequestedEventArgs e);

        /// <summary>
        /// Sets the new window id.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewTabTearOutWindowRequestedEventArgs"/>.</param>
        /// <param name="newWindowId">The new window id.</param>
        void NewWindowId(TabViewTabTearOutWindowRequestedEventArgs e, WindowId newWindowId);

        /// <summary>
        /// Gets the tabs to tear out.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewTabTearOutWindowRequestedEventArgs"/>.</param>
        /// <returns>The tabs to tear out.</returns>
        UIElement[] Tabs(TabViewTabTearOutWindowRequestedEventArgs e);
    }
}