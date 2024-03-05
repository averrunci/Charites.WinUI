// Copyright (C) 2024 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers
{
    /// <summary>
    /// Provides data of the <see cref="MapControlMapServiceErrorOccurredEventArgs"/>
    /// resolved by <see cref="IMapControlMapServiceErrorOccurredEventArgsResolver"/>.
    /// </summary>
    public static class MapControlMapServiceErrorOccurredEventArgsWrapper
    {
        /// <summary>
        /// Gets or sets the <see cref="IMapControlMapServiceErrorOccurredEventArgsResolver"/>
        /// that resolves data of the <see cref="MapControlMapServiceErrorOccurredEventArgs"/>.
        /// </summary>
        public static IMapControlMapServiceErrorOccurredEventArgsResolver Resolver { get; set; } = new DefaultMapControlMapServiceErrorOccurredEventArgsResolver();

        /// <summary>
        /// Gets the error string returned from the web exception.
        /// </summary>
        /// <param name="e">The requested <see cref="MapControlMapServiceErrorOccurredEventArgs"/>.</param>
        /// <returns>The error string returned from the web exception.</returns>
        public static string DiagnosticMessage(this MapControlMapServiceErrorOccurredEventArgs e) => Resolver.DiagnosticMessage(e);

        private sealed class DefaultMapControlMapServiceErrorOccurredEventArgsResolver : IMapControlMapServiceErrorOccurredEventArgsResolver
        {
            string IMapControlMapServiceErrorOccurredEventArgsResolver.DiagnosticMessage(MapControlMapServiceErrorOccurredEventArgs e) => e.DiagnosticMessage;
        }
    }

    /// <summary>
    /// Resolves data of the <see cref="MapControlMapServiceErrorOccurredEventArgs"/>.
    /// </summary>
    public interface IMapControlMapServiceErrorOccurredEventArgsResolver
    {
        /// <summary>
        /// Gets the error string returned from the web exception.
        /// </summary>
        /// <param name="e">The requested <see cref="MapControlMapServiceErrorOccurredEventArgs"/>.</param>
        /// <returns>The error string returned from the web exception.</returns>
        string DiagnosticMessage(MapControlMapServiceErrorOccurredEventArgs e);
    }
}