// Copyright (C) 2023 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="XamlResourceReferenceFailedEventArgs"/>
/// resolved by <see cref="IXamlResourceReferenceFailedEventArgsResolver"/>.
/// </summary>
public static class XamlResourceReferenceFailedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IXamlResourceReferenceFailedEventArgsResolver"/>
    /// that resolves data of the <see cref="XamlResourceReferenceFailedEventArgs"/>.
    /// </summary>
    public static IXamlResourceReferenceFailedEventArgsResolver Resolver { get; set; } = new DefaultXamlResourceReferenceFailedEventArgsResolver();

    /// <summary>
    /// Gets the message.
    /// </summary>
    /// <param name="e">The requested <see cref="XamlResourceReferenceFailedEventArgs"/>.</param>
    /// <returns>The message.</returns>
    public static string Message(this XamlResourceReferenceFailedEventArgs e) => Resolver.Message(e);

    private sealed class DefaultXamlResourceReferenceFailedEventArgsResolver : IXamlResourceReferenceFailedEventArgsResolver
    {
        string IXamlResourceReferenceFailedEventArgsResolver.Message(XamlResourceReferenceFailedEventArgs e) => e.Message;
    }
}

/// <summary>
/// Resolves data of the <see cref="XamlResourceReferenceFailedEventArgs"/>.
/// </summary>
public interface IXamlResourceReferenceFailedEventArgsResolver
{
    /// <summary>
    /// Gets the message.
    /// </summary>
    /// <param name="e">The requested <see cref="XamlResourceReferenceFailedEventArgs"/>.</param>
    /// <returns>The message.</returns>
    string Message(XamlResourceReferenceFailedEventArgs e);
}