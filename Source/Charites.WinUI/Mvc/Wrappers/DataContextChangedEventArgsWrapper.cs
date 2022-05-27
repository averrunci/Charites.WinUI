// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="DataContextChangedEventArgs"/>
/// resolved by <see cref="IDataContextChangedEventArgsResolver"/>.
/// </summary>
public static class DataContextChangedEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IDataContextChangedEventArgsResolver"/>
    /// that resolves data of the <see cref="DataContextChangedEventArgs"/>.
    /// </summary>
    public static IDataContextChangedEventArgsResolver Resolver { get; set; } = new DefaultDataContextChangedEventArgsResolver();

    /// <summary>
    /// Gets a value that influences whether another <see cref="FrameworkElement.DataContextChanged"/> event should be fired
    /// from child elements that inherit the <see cref="FrameworkElement.DataContext"/> value and detect that the value has changed.
    /// </summary>
    /// <param name="e">The requested <see cref="DataContextChangedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> to prevent further <see cref="FrameworkElement.DataContextChanged"/> events from being fired
    /// for each child <see cref="FrameworkElement"/> that inherits the <see cref="FrameworkElement.DataContext"/> value.
    /// You would do this to indicate to other handlers that the necessary logic for responding to the data context change has already been performed.
    /// <c>false</c> to permit the event to be fired by each immediate child <see cref="FrameworkElement"/> in the element tree
    /// that detects a change to the inherited <see cref="FrameworkElement.DataContext"/> value.
    /// </returns>
    public static bool Handled(this DataContextChangedEventArgs e) => Resolver.Handled(e);

    /// <summary>
    /// Sets a value that influences whether another <see cref="FrameworkElement.DataContextChanged"/> event should be fired
    /// from child elements that inherit the <see cref="FrameworkElement.DataContext"/> value and detect that the value has changed.
    /// </summary>
    /// <param name="e">The requested <see cref="DataContextChangedEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> to prevent further <see cref="FrameworkElement.DataContextChanged"/> events from being fired
    /// for each child <see cref="FrameworkElement"/> that inherits the <see cref="FrameworkElement.DataContext"/> value.
    /// You would do this to indicate to other handlers that the necessary logic for responding to the data context change has already been performed.
    /// <c>false</c> to permit the event to be fired by each immediate child <see cref="FrameworkElement"/> in the element tree
    /// that detects a change to the inherited <see cref="FrameworkElement.DataContext"/> value.
    /// </param>
    public static void Handled(this DataContextChangedEventArgs e, bool handled) => Resolver.Handled(e, handled);

    /// <summary>
    /// Gets the new <see cref="FrameworkElement.DataContext"/> value for the element
    /// where the <see cref="FrameworkElement.DataContextChanged"/> event fired.
    /// </summary>
    /// <param name="e">The requested <see cref="DataContextChangedEventArgs"/>.</param>
    /// <returns>
    /// An object representing the new <see cref="FrameworkElement.DataContext"/> value for the element
    /// where the <see cref="FrameworkElement.DataContextChanged"/> event fired.
    /// </returns>
    public static object? NewValue(this DataContextChangedEventArgs e) => Resolver.NewValue(e);

    private sealed class DefaultDataContextChangedEventArgsResolver : IDataContextChangedEventArgsResolver
    {
        bool IDataContextChangedEventArgsResolver.Handled(DataContextChangedEventArgs e) => e.Handled;
        void IDataContextChangedEventArgsResolver.Handled(DataContextChangedEventArgs e, bool handled) => e.Handled = handled;
        object? IDataContextChangedEventArgsResolver.NewValue(DataContextChangedEventArgs e) => e.NewValue;
    }
}

/// <summary>
/// Resolves data of the <see cref="DataContextChangedEventArgs"/>.
/// </summary>
public interface IDataContextChangedEventArgsResolver
{
    /// <summary>
    /// Gets a value that influences whether another <see cref="FrameworkElement.DataContextChanged"/> event should be fired
    /// from child elements that inherit the <see cref="FrameworkElement.DataContext"/> value and detect that the value has changed.
    /// </summary>
    /// <param name="e">The requested <see cref="DataContextChangedEventArgs"/>.</param>
    /// <returns>
    /// <c>true</c> to prevent further <see cref="FrameworkElement.DataContextChanged"/> events from being fired
    /// for each child <see cref="FrameworkElement"/> that inherits the <see cref="FrameworkElement.DataContext"/> value.
    /// You would do this to indicate to other handlers that the necessary logic for responding to the data context change has already been performed.
    /// <c>false</c> to permit the event to be fired by each immediate child <see cref="FrameworkElement"/> in the element tree
    /// that detects a change to the inherited <see cref="FrameworkElement.DataContext"/> value.
    /// </returns>
    bool Handled(DataContextChangedEventArgs e);

    /// <summary>
    /// Sets a value that influences whether another <see cref="FrameworkElement.DataContextChanged"/> event should be fired
    /// from child elements that inherit the <see cref="FrameworkElement.DataContext"/> value and detect that the value has changed.
    /// </summary>
    /// <param name="e">The requested <see cref="DataContextChangedEventArgs"/>.</param>
    /// <param name="handled">
    /// <c>true</c> to prevent further <see cref="FrameworkElement.DataContextChanged"/> events from being fired
    /// for each child <see cref="FrameworkElement"/> that inherits the <see cref="FrameworkElement.DataContext"/> value.
    /// You would do this to indicate to other handlers that the necessary logic for responding to the data context change has already been performed.
    /// <c>false</c> to permit the event to be fired by each immediate child <see cref="FrameworkElement"/> in the element tree
    /// that detects a change to the inherited <see cref="FrameworkElement.DataContext"/> value.
    /// </param>
    void Handled(DataContextChangedEventArgs e, bool handled);

    /// <summary>
    /// Gets the new <see cref="FrameworkElement.DataContext"/> value for the element
    /// where the <see cref="FrameworkElement.DataContextChanged"/> event fired.
    /// </summary>
    /// <param name="e">The requested <see cref="DataContextChangedEventArgs"/>.</param>
    /// <returns>
    /// An object representing the new <see cref="FrameworkElement.DataContext"/> value for the element
    /// where the <see cref="FrameworkElement.DataContextChanged"/> event fired.
    /// </returns>
    object? NewValue(DataContextChangedEventArgs e);
}