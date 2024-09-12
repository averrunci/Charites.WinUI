// Copyright (C) 2024 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Foundation;
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers
{
    /// <summary>
    /// Provides data of the <see cref="CoreWebView2Deferral"/>
    /// resolved by <see cref="ICoreWebView2DeferralResolver"/>.
    /// </summary>
    public static class CoreWebView2DeferralWrapper
    {
        /// <summary>
        /// Gets or sets the <see cref="ICoreWebView2DeferralResolver"/>
        /// that resolves data of the <see cref="CoreWebView2Deferral"/>.
        /// </summary>
        public static ICoreWebView2DeferralResolver Resolver { get; set; } = new DefaultCoreWebView2DeferralResolver();

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        /// <param name="deferral">The requested <see cref="Deferral"/>.</param>
        public static void DisposeWrapped(this CoreWebView2Deferral deferral) => Resolver.Dispose(deferral);

        /// <summary>
        /// If the <see cref="DeferralCompletedHandler"/> has not yet been invoked,
        /// this will call it and drop the reference to the delegate.
        /// </summary>
        /// <param name="deferral">The requested <see cref="Deferral"/>.</param>
        public static void CompleteWrapped(this CoreWebView2Deferral deferral) => Resolver.Complete(deferral);

        private sealed class DefaultCoreWebView2DeferralResolver : ICoreWebView2DeferralResolver
        {
            void ICoreWebView2DeferralResolver.Dispose(CoreWebView2Deferral deferral) => deferral.Dispose();
            void ICoreWebView2DeferralResolver.Complete(CoreWebView2Deferral deferral) => deferral.Complete();
        }
    }

    /// <summary>
    /// Resolves data of the <see cref="CoreWebView2Deferral"/>.
    /// </summary>
    public interface ICoreWebView2DeferralResolver
    {
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        /// <param name="deferral">The requested <see cref="CoreWebView2Deferral"/>.</param>
        void Dispose(CoreWebView2Deferral deferral);

        /// <summary>
        /// Completes the associated deferred event.
        /// </summary>
        /// <param name="deferral">The requested <see cref="CoreWebView2Deferral"/>.</param>
        void Complete(CoreWebView2Deferral deferral);
    }
}