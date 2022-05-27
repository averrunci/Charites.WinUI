// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Foundation;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="TeachingTipClosingEventArgs"/>
/// resolved by <see cref="ITeachingTipClosingEventArgsResolver"/>.
/// </summary>
public static class TeachingTipClosingEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="ITeachingTipClosingEventArgsResolver"/>
    /// that resolves data of the <see cref="TeachingTipClosingEventArgs"/>.
    /// </summary>
    public static ITeachingTipClosingEventArgsResolver Resolver { get; set; } = new DefaultTeachingTipClosingEventArgsResolver();

    /// <summary>
    /// Gets a value that indicates whether the <see cref="TeachingTip.Closing"/> event should be canceled.
    /// </summary>
    /// <param name="e">The requested <see cref="TeachingTipClosingEventArgs"/>.</param>
    /// <returns><c>true</c> if the event is canceled; otherwise, <c>false</c>.</returns>
    public static bool Cancel(this TeachingTipClosingEventArgs e) => Resolver.Cancel(e);

    /// <summary>
    /// Sets a value that indicates whether the <see cref="TeachingTip.Closing"/> event should be canceled.
    /// </summary>
    /// <param name="e">The requested <see cref="TeachingTipClosingEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> if the event is canceled; otherwise, <c>false</c>.</param>
    public static void Cancel(this TeachingTipClosingEventArgs e, bool cancel) => Resolver.Cancel(e, cancel);

    /// <summary>
    /// Gets a constant that specifies whether the cause of the <see cref="TeachingTip.Closing"/> event was
    /// due to user interaction (Close button click), light-dismissal, or programmatic closure.
    /// </summary>
    /// <param name="e">The requested <see cref="TeachingTipClosingEventArgs"/>.</param>
    /// <returns>
    /// A constant that specifies whether the cause of the <see cref="TeachingTip.Closing"/> event was
    /// due to user interaction (Close button click), light-dismissal, or programmatic closure.
    /// </returns>
    public static TeachingTipCloseReason Reason(this TeachingTipClosingEventArgs e) => Resolver.Reason(e);

    /// <summary>
    /// Gets a deferral object for managing the work done in the <see cref="TeachingTip.Closing"/> event handler.
    /// </summary>
    /// <param name="e">The requested <see cref="TeachingTipClosingEventArgs"/>.</param>
    /// <returns>
    /// A deferral object for managing the work done in the <see cref="TeachingTip.Closing"/> event handler.
    /// </returns>
    public static Deferral GetDeferralWrapped(this TeachingTipClosingEventArgs e) => Resolver.GetDeferral(e);

    private sealed class DefaultTeachingTipClosingEventArgsResolver : ITeachingTipClosingEventArgsResolver
    {
        bool ITeachingTipClosingEventArgsResolver.Cancel(TeachingTipClosingEventArgs e) => e.Cancel;
        void ITeachingTipClosingEventArgsResolver.Cancel(TeachingTipClosingEventArgs e, bool cancel) => e.Cancel = cancel;
        TeachingTipCloseReason ITeachingTipClosingEventArgsResolver.Reason(TeachingTipClosingEventArgs e) => e.Reason;
        Deferral ITeachingTipClosingEventArgsResolver.GetDeferral(TeachingTipClosingEventArgs e) => e.GetDeferral();
    }
}

/// <summary>
/// Resolves data of the <see cref="TeachingTipClosingEventArgs"/>.
/// </summary>
public interface ITeachingTipClosingEventArgsResolver
{
    /// <summary>
    /// Gets a value that indicates whether the <see cref="TeachingTip.Closing"/> event should be canceled.
    /// </summary>
    /// <param name="e">The requested <see cref="TeachingTipClosingEventArgs"/>.</param>
    /// <returns><c>true</c> if the event is canceled; otherwise, <c>false</c>.</returns>
    bool Cancel(TeachingTipClosingEventArgs e);

    /// <summary>
    /// Sets a value that indicates whether the <see cref="TeachingTip.Closing"/> event should be canceled.
    /// </summary>
    /// <param name="e">The requested <see cref="TeachingTipClosingEventArgs"/>.</param>
    /// <param name="cancel"><c>true</c> if the event is canceled; otherwise, <c>false</c>.</param>
    void Cancel(TeachingTipClosingEventArgs e, bool cancel);

    /// <summary>
    /// Gets a constant that specifies whether the cause of the <see cref="TeachingTip.Closing"/> event was
    /// due to user interaction (Close button click), light-dismissal, or programmatic closure.
    /// </summary>
    /// <param name="e">The requested <see cref="TeachingTipClosingEventArgs"/>.</param>
    /// <returns>
    /// A constant that specifies whether the cause of the <see cref="TeachingTip.Closing"/> event was
    /// due to user interaction (Close button click), light-dismissal, or programmatic closure.
    /// </returns>
    TeachingTipCloseReason Reason(TeachingTipClosingEventArgs e);

    /// <summary>
    /// Gets a deferral object for managing the work done in the <see cref="TeachingTip.Closing"/> event handler.
    /// </summary>
    /// <param name="e">The requested <see cref="TeachingTipClosingEventArgs"/>.</param>
    /// <returns>
    /// A deferral object for managing the work done in the <see cref="TeachingTip.Closing"/> event handler.
    /// </returns>
    Deferral GetDeferral(TeachingTipClosingEventArgs e);
}