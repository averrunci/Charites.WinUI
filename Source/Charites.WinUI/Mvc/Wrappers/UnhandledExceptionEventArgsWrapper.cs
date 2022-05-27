// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="Microsoft.UI.Xaml.UnhandledExceptionEventArgs"/>
/// resolved by <see cref="IUnhandledExceptionEventArgsResolver"/>.
/// </summary>
public static class UnhandledExceptionEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IUnhandledExceptionEventArgsResolver"/>
    /// that resolves data of the <see cref="Microsoft.UI.Xaml.UnhandledExceptionEventArgs"/>.
    /// </summary>
    public static IUnhandledExceptionEventArgsResolver Resolver { get; set; } = new DefaultUnhandledExceptionEventArgsResolver();

    /// <summary>
    /// Gets the <c>HRESULT</c> code associated with the unhandled exception.
    /// </summary>
    /// <param name="e">The requested <see cref="Microsoft.UI.Xaml.UnhandledExceptionEventArgs"/>.</param>
    /// <returns>
    /// The <c>HRESULT</c> code (for Visual C++ component extensions (C++/CX)), or a mapped common language runtime (CLR) <see cref="Exception"/>.
    /// </returns>
    public static Exception Exception(this Microsoft.UI.Xaml.UnhandledExceptionEventArgs e) => Resolver.Exception(e);

    /// <summary>
    /// Gets a value that indicates whether the exception is handled.
    /// </summary>
    /// <param name="e">The requested <see cref="Microsoft.UI.Xaml.UnhandledExceptionEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> to mark the exception as handled, which indicates that the event system should not process it further; otherwise, <c>false</c>.
    /// </returns>
    public static bool Handled(this Microsoft.UI.Xaml.UnhandledExceptionEventArgs e) => Resolver.Handled(e);

    /// <summary>
    /// Sets a value that indicates whether the exception is handled.
    /// </summary>
    /// <param name="e">The requested <see cref="Microsoft.UI.Xaml.UnhandledExceptionEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> to mark the exception as handled, which indicates that the event system should not process it further; otherwise, <c>false</c>.
    /// </param>
    public static void Handled(this Microsoft.UI.Xaml.UnhandledExceptionEventArgs e, bool handled) => Resolver.Handled(e, handled);

    /// <summary>
    /// Gets the message string as passed by the originating unhandled exception.
    /// </summary>
    /// <param name="e">The requested <see cref="Microsoft.UI.Xaml.UnhandledExceptionEventArgs"/>.</param>
    /// <returns>The message string, which may be useful for debugging.</returns>
    public static string Message(this Microsoft.UI.Xaml.UnhandledExceptionEventArgs e) => Resolver.Message(e);

    private sealed class DefaultUnhandledExceptionEventArgsResolver : IUnhandledExceptionEventArgsResolver
    {
        Exception IUnhandledExceptionEventArgsResolver.Exception(Microsoft.UI.Xaml.UnhandledExceptionEventArgs e) => e.Exception;
        bool IUnhandledExceptionEventArgsResolver.Handled(Microsoft.UI.Xaml.UnhandledExceptionEventArgs e) => e.Handled;
        void IUnhandledExceptionEventArgsResolver.Handled(Microsoft.UI.Xaml.UnhandledExceptionEventArgs e, bool handled) => e.Handled = handled;
        string IUnhandledExceptionEventArgsResolver.Message(Microsoft.UI.Xaml.UnhandledExceptionEventArgs e) => e.Message;
    }
}

/// <summary>
/// Resolves data of the <see cref="Microsoft.UI.Xaml.UnhandledExceptionEventArgs"/>.
/// </summary>
public interface IUnhandledExceptionEventArgsResolver
{
    /// <summary>
    /// Gets the <c>HRESULT</c> code associated with the unhandled exception.
    /// </summary>
    /// <param name="e">The requested <see cref="Microsoft.UI.Xaml.UnhandledExceptionEventArgs"/>.</param>
    /// <returns>
    /// The <c>HRESULT</c> code (for Visual C++ component extensions (C++/CX)), or a mapped common language runtime (CLR) <see cref="Exception"/>.
    /// </returns>
    Exception Exception(Microsoft.UI.Xaml.UnhandledExceptionEventArgs e);

    /// <summary>
    /// Gets a value that indicates whether the exception is handled.
    /// </summary>
    /// <param name="e">The requested <see cref="Microsoft.UI.Xaml.UnhandledExceptionEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> to mark the exception as handled, which indicates that the event system should not process it further; otherwise, <c>false</c>.
    /// </returns>
    bool Handled(Microsoft.UI.Xaml.UnhandledExceptionEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether the exception is handled.
    /// </summary>
    /// <param name="e">The requested <see cref="Microsoft.UI.Xaml.UnhandledExceptionEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> to mark the exception as handled, which indicates that the event system should not process it further; otherwise, <c>false</c>.
    /// </param>
    void Handled(Microsoft.UI.Xaml.UnhandledExceptionEventArgs e, bool handled);

    /// <summary>
    /// Gets the message string as passed by the originating unhandled exception.
    /// </summary>
    /// <param name="e">The requested <see cref="Microsoft.UI.Xaml.UnhandledExceptionEventArgs"/>.</param>
    /// <returns>The message string, which may be useful for debugging.</returns>
    string Message(Microsoft.UI.Xaml.UnhandledExceptionEventArgs e);
}