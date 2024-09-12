// Copyright (C) 2024 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers
{
    /// <summary>
    /// Provides data of the <see cref="TabViewExternalTornOutTabsDroppedEventArgs"/>
    /// resolved by <see cref="ITabViewExternalTornOutTabsDroppedEventArgsResolver"/>.
    /// </summary>
    public static class TabViewExternalTornOutTabsDroppedEventArgsWrapper
    {
        /// <summary>
        /// Gets or sets the <see cref="ITabViewExternalTornOutTabsDroppedEventArgsResolver"/>
        /// that resolves data of the <see cref="TabViewExternalTornOutTabsDroppedEventArgs"/>.
        /// </summary>
        public static ITabViewExternalTornOutTabsDroppedEventArgsResolver Resolver { get; set; } = new DefaultTabViewExternalTornOutTabsDroppedEventArgsResolver();

        /// <summary>
        /// Gets the drop index.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewExternalTornOutTabsDroppedEventArgs"/>.</param>
        /// <returns>The drop index.</returns>
        public static int DropIndex(this TabViewExternalTornOutTabsDroppedEventArgs e) => Resolver.DropIndex(e);

        /// <summary>
        /// Gets the dropped items.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewExternalTornOutTabsDroppedEventArgs"/>.</param>
        /// <returns>The dropped items.</returns>
        public static object[] Items(this TabViewExternalTornOutTabsDroppedEventArgs e) => Resolver.Items(e);

        /// <summary>
        /// Gets the dropped tabs.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewExternalTornOutTabsDroppedEventArgs"/>.</param>
        /// <returns>The dropped tabs.</returns>
        public static UIElement[] Tabs(this TabViewExternalTornOutTabsDroppedEventArgs e) => Resolver.Tabs(e);

        private sealed class DefaultTabViewExternalTornOutTabsDroppedEventArgsResolver : ITabViewExternalTornOutTabsDroppedEventArgsResolver
        {
            int ITabViewExternalTornOutTabsDroppedEventArgsResolver.DropIndex(TabViewExternalTornOutTabsDroppedEventArgs e) => e.DropIndex;
            object[] ITabViewExternalTornOutTabsDroppedEventArgsResolver.Items(TabViewExternalTornOutTabsDroppedEventArgs e) => e.Items;
            UIElement[] ITabViewExternalTornOutTabsDroppedEventArgsResolver.Tabs(TabViewExternalTornOutTabsDroppedEventArgs e) => e.Tabs;
        }
    }

    /// <summary>
    /// Resolves data of the <see cref="TabViewExternalTornOutTabsDroppedEventArgs"/>.
    /// </summary>
    public interface ITabViewExternalTornOutTabsDroppedEventArgsResolver
    {
        /// <summary>
        /// Gets the drop index.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewExternalTornOutTabsDroppedEventArgs"/>.</param>
        /// <returns>The drop index.</returns>
        int DropIndex(TabViewExternalTornOutTabsDroppedEventArgs e);

        /// <summary>
        /// Gets the dropped items.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewExternalTornOutTabsDroppedEventArgs"/>.</param>
        /// <returns>The dropped items.</returns>
        object[] Items(TabViewExternalTornOutTabsDroppedEventArgs e);

        /// <summary>
        /// Gets the dropped tabs.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewExternalTornOutTabsDroppedEventArgs"/>.</param>
        /// <returns>The dropped tabs.</returns>
        UIElement[] Tabs(TabViewExternalTornOutTabsDroppedEventArgs e);
    }
}