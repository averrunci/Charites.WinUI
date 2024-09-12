// Copyright (C) 2024 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers
{
    /// <summary>
    /// Provides data of the <see cref="CoreWebView2NonClientRegionChangedEventArgs"/>
    /// resolved by <see cref="ICoreWebView2NonClientRegionChangedEventArgsResolver"/>.
    /// </summary>
    public static class CoreWebView2NonClientRegionChangedEventArgsWrapper
    {
        /// <summary>
        /// Gets or sets the <see cref="ICoreWebView2NonClientRegionChangedEventArgsResolver"/>
        /// that resolves data of the <see cref="CoreWebView2NonClientRegionChangedEventArgs"/>.
        /// </summary>
        public static ICoreWebView2NonClientRegionChangedEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2NonClientRegionChangedEventArgsResolver();

        /// <summary>
        /// Gets the region kind <see cref="CoreWebView2NonClientRegionKind"/> corresponding to the event.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2NonClientRegionChangedEventArgs"/>.</param>
        /// <returns>The region kind <see cref="CoreWebView2NonClientRegionKind"/> corresponding to the event.</returns>
        public static CoreWebView2NonClientRegionKind RegionKind(this CoreWebView2NonClientRegionChangedEventArgs e) => Resolver.RegionKind(e);

        private sealed class DefaultCoreWebView2NonClientRegionChangedEventArgsResolver : ICoreWebView2NonClientRegionChangedEventArgsResolver
        {
            CoreWebView2NonClientRegionKind ICoreWebView2NonClientRegionChangedEventArgsResolver.RegionKind(CoreWebView2NonClientRegionChangedEventArgs e) => e.RegionKind;
        }
    }

    /// <summary>
    /// Resolves data of the <see cref="CoreWebView2NonClientRegionChangedEventArgs"/>.
    /// </summary>
    public interface ICoreWebView2NonClientRegionChangedEventArgsResolver
    {
        /// <summary>
        /// Gets the region kind <see cref="CoreWebView2NonClientRegionKind"/> corresponding to the event.
        /// </summary>
        /// <param name="e">The requested <see cref="CoreWebView2NonClientRegionChangedEventArgs"/>.</param>
        /// <returns>The region kind <see cref="CoreWebView2NonClientRegionKind"/> corresponding to the event.</returns>
        CoreWebView2NonClientRegionKind RegionKind(CoreWebView2NonClientRegionChangedEventArgs e);
    }
}