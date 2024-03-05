// Copyright (C) 2024 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Foundation;
using Microsoft.UI.Xaml.Hosting;

namespace Charites.Windows.Mvc.Wrappers
{
    /// <summary>
    /// Provides data of the <see cref="XamlShutdownCompletedOnThreadEventArgs"/>
    /// resolved by <see cref="IXamlShutdownCompletedOnThreadEventArgsResolver"/>.
    /// </summary>
    public static class XamlShutdownCompletedOnThreadEventArgsWrapper
    {
        /// <summary>
        /// Gets or sets the <see cref="IXamlShutdownCompletedOnThreadEventArgsResolver"/>
        /// that resolves data of the <see cref="XamlShutdownCompletedOnThreadEventArgs"/>.
        /// </summary>
        public static IXamlShutdownCompletedOnThreadEventArgsResolver Resolver { get; set; } = new DefaultXamlShutdownCompletedOnThreadEventArgsResolver();

        /// <summary>
        /// Gets a <see cref="Deferral"/> object that lets you delay completion of the shutdown until
        /// your operations are complete.
        /// </summary>
        /// <param name="e">The requested <see cref="XamlShutdownCompletedOnThreadEventArgs"/>.</param>
        /// <returns>
        /// A <see cref="Deferral"/> object that lets you delay completion of the shutdown until your operations are complete.
        /// </returns>
        public static Deferral GetDispatcherQueueDeferralWrapped(this XamlShutdownCompletedOnThreadEventArgs e) => Resolver.GetDispatcherQueueDeferral(e);

        private sealed class DefaultXamlShutdownCompletedOnThreadEventArgsResolver : IXamlShutdownCompletedOnThreadEventArgsResolver
        {
            Deferral IXamlShutdownCompletedOnThreadEventArgsResolver.GetDispatcherQueueDeferral(XamlShutdownCompletedOnThreadEventArgs e) => e.GetDispatcherQueueDeferral();
        }
    }

    /// <summary>
    /// Resolves data of the <see cref="XamlShutdownCompletedOnThreadEventArgs"/>.
    /// </summary>
    public interface IXamlShutdownCompletedOnThreadEventArgsResolver
    {
        /// <summary>
        /// Gets a <see cref="Deferral"/> object that lets you delay completion of the shutdown until
        /// your operations are complete.
        /// </summary>
        /// <param name="e">The requested <see cref="XamlShutdownCompletedOnThreadEventArgs"/>.</param>
        /// <returns>
        /// A <see cref="Deferral"/> object that lets you delay completion of the shutdown until your operations are complete.
        /// </returns>
        Deferral GetDispatcherQueueDeferral(XamlShutdownCompletedOnThreadEventArgs e);
    }
}