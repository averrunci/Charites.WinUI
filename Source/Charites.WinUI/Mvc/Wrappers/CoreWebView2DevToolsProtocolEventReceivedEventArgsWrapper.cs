﻿// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.Web.WebView2.Core;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="CoreWebView2DevToolsProtocolEventReceivedEventArgs"/>
/// resolved by <see cref="ICoreWebView2DevToolsProtocolEventReceivedEventArgsResolver"/>.
/// </summary>
public static class CoreWebView2DevToolsProtocolEventReceivedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ICoreWebView2DevToolsProtocolEventReceivedEventArgsResolver"/>
    /// that resolves data of the <see cref="CoreWebView2DevToolsProtocolEventReceivedEventArgs"/>.
    /// </summary>
    public static ICoreWebView2DevToolsProtocolEventReceivedEventArgsResolver Resolver { get; set; } = new DefaultCoreWebView2DevToolsProtocolEventReceivedEventArgsResolver();

    /// <summary>
    /// Gets the parameter object of the corresponding <see cref="CoreWebView2DevToolsProtocolEventReceiver.DevToolsProtocolEventReceived"/>
    /// event represented as a JSON string.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2DevToolsProtocolEventReceivedEventArgs"/>.</param>
    /// <returns>
    /// The parameter object of the corresponding <see cref="CoreWebView2DevToolsProtocolEventReceiver.DevToolsProtocolEventReceived"/>
    /// event represented as a JSON string.
    /// </returns>
    public static string ParameterObjectAsJson(this CoreWebView2DevToolsProtocolEventReceivedEventArgs e) => Resolver.ParameterObjectAsJson(e);

    private sealed class DefaultCoreWebView2DevToolsProtocolEventReceivedEventArgsResolver : ICoreWebView2DevToolsProtocolEventReceivedEventArgsResolver
    {
        string ICoreWebView2DevToolsProtocolEventReceivedEventArgsResolver.ParameterObjectAsJson(CoreWebView2DevToolsProtocolEventReceivedEventArgs e) => e.ParameterObjectAsJson;
    }
}

/// <summary>
/// Resolves data of the <see cref="CoreWebView2DevToolsProtocolEventReceivedEventArgs"/>.
/// </summary>
public interface ICoreWebView2DevToolsProtocolEventReceivedEventArgsResolver
{
    /// <summary>
    /// Gets the parameter object of the corresponding <see cref="CoreWebView2DevToolsProtocolEventReceiver.DevToolsProtocolEventReceived"/>
    /// event represented as a JSON string.
    /// </summary>
    /// <param name="e">The requested <see cref="CoreWebView2DevToolsProtocolEventReceivedEventArgs"/>.</param>
    /// <returns>
    /// The parameter object of the corresponding <see cref="CoreWebView2DevToolsProtocolEventReceiver.DevToolsProtocolEventReceived"/>
    /// event represented as a JSON string.
    /// </returns>
    string ParameterObjectAsJson(CoreWebView2DevToolsProtocolEventReceivedEventArgs e);
}