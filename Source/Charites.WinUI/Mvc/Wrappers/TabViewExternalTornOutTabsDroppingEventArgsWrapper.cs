// Copyright (C) 2024 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers
{
    /// <summary>
    /// Provides data of the <see cref="TabViewExternalTornOutTabsDroppingEventArgs"/>
    /// resolved by <see cref="ITabViewExternalTornOutTabsDroppingEventArgsResolver"/>.
    /// </summary>
    public static class TabViewExternalTornOutTabsDroppingEventArgsWrapper
    {
        /// <summary>
        /// Gets or sets the <see cref="ITabViewExternalTornOutTabsDroppingEventArgsResolver"/>
        /// that resolves data of the <see cref="TabViewExternalTornOutTabsDroppingEventArgs"/>.
        /// </summary>
        public static ITabViewExternalTornOutTabsDroppingEventArgsResolver Resolver { get; set; } = new DefaultTabViewExternalTornOutTabsDroppingEventArgsResolver();

        /// <summary>
        /// Gets the value that indicates whether to allow dropping tabs.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewExternalTornOutTabsDroppingEventArgs"/>.</param>
        /// <returns><c>true</c> if it is allowed to drop tabs; otherwise <c>false</c>.</returns>
        public static bool AllowDrop(this TabViewExternalTornOutTabsDroppingEventArgs e) => Resolver.AllowDrop(e);

        /// <summary>
        /// Sets the value that indicates whether to allow dropping tabs.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewExternalTornOutTabsDroppingEventArgs"/>.</param>
        /// <param name="allowDrop"><c>true</c> if it is allowed to drop tabs; otherwise <c>false</c>.</param>
        public static void AllowDrop(this TabViewExternalTornOutTabsDroppingEventArgs e, bool allowDrop) => Resolver.AllowDrop(e, allowDrop);

        /// <summary>
        /// Gets the drop index.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewExternalTornOutTabsDroppingEventArgs"/>.</param>
        /// <returns>The drop index.</returns>
        public static int DropIndex(this TabViewExternalTornOutTabsDroppingEventArgs e) => Resolver.DropIndex(e);

        /// <summary>
        /// Gets the dropping items.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewExternalTornOutTabsDroppingEventArgs"/>.</param>
        /// <returns>The dropping items.</returns>
        public static object[] Items(this TabViewExternalTornOutTabsDroppingEventArgs e) => Resolver.Items(e);

        /// <summary>
        /// Gets the dropping tabs.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewExternalTornOutTabsDroppingEventArgs"/>.</param>
        /// <returns>The dropping tabs.</returns>
        public static UIElement[] Tabs(this TabViewExternalTornOutTabsDroppingEventArgs e) => Resolver.Tabs(e);

        private sealed class DefaultTabViewExternalTornOutTabsDroppingEventArgsResolver : ITabViewExternalTornOutTabsDroppingEventArgsResolver
        {
            bool ITabViewExternalTornOutTabsDroppingEventArgsResolver.AllowDrop(TabViewExternalTornOutTabsDroppingEventArgs e) => e.AllowDrop;
            void ITabViewExternalTornOutTabsDroppingEventArgsResolver.AllowDrop(TabViewExternalTornOutTabsDroppingEventArgs e, bool allowDrop) => e.AllowDrop = allowDrop;
            int ITabViewExternalTornOutTabsDroppingEventArgsResolver.DropIndex(TabViewExternalTornOutTabsDroppingEventArgs e) => e.DropIndex;
            object[] ITabViewExternalTornOutTabsDroppingEventArgsResolver.Items(TabViewExternalTornOutTabsDroppingEventArgs e) => e.Items;
            UIElement[] ITabViewExternalTornOutTabsDroppingEventArgsResolver.Tabs(TabViewExternalTornOutTabsDroppingEventArgs e) => e.Tabs;
        }
    }

    /// <summary>
    /// Resolves data of the <see cref="TabViewExternalTornOutTabsDroppingEventArgs"/>.
    /// </summary>
    public interface ITabViewExternalTornOutTabsDroppingEventArgsResolver
    {
        /// <summary>
        /// Gets the value that indicates whether to allow dropping tabs.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewExternalTornOutTabsDroppingEventArgs"/>.</param>
        /// <returns><c>true</c> if it is allowed to drop tabs; otherwise <c>false</c>.</returns>
        bool AllowDrop(TabViewExternalTornOutTabsDroppingEventArgs e);

        /// <summary>
        /// Sets the value that indicates whether to allow dropping tabs.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewExternalTornOutTabsDroppingEventArgs"/>.</param>
        /// <param name="allowDrop"><c>true</c> if it is allowed to drop tabs; otherwise <c>false</c>.</param>
        void AllowDrop(TabViewExternalTornOutTabsDroppingEventArgs e, bool allowDrop);

        /// <summary>
        /// Gets the drop index.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewExternalTornOutTabsDroppingEventArgs"/>.</param>
        /// <returns>The drop index.</returns>
        int DropIndex(TabViewExternalTornOutTabsDroppingEventArgs e);

        /// <summary>
        /// Gets the dropping items.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewExternalTornOutTabsDroppingEventArgs"/>.</param>
        /// <returns>The dropping items.</returns>
        object[] Items(TabViewExternalTornOutTabsDroppingEventArgs e);

        /// <summary>
        /// Gets the dropping tabs.
        /// </summary>
        /// <param name="e">The requested <see cref="TabViewExternalTornOutTabsDroppingEventArgs"/>.</param>
        /// <returns>The dropping tabs.</returns>
        UIElement[] Tabs(TabViewExternalTornOutTabsDroppingEventArgs e);
    }
}