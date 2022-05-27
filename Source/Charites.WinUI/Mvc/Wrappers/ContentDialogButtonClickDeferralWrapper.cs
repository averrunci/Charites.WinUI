// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="ContentDialogButtonClickDeferral"/>
/// resolved by <see cref="IContentDialogButtonClickDeferralResolver"/>.
/// </summary>
public static class ContentDialogButtonClickDeferralWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IContentDialogButtonClickDeferralResolver"/>
    /// that resolves data of the <see cref="ContentDialogButtonClickDeferral"/>.
    /// </summary>
    public static IContentDialogButtonClickDeferralResolver Resolver { get; set; } = new DefaultContentDialogButtonClickDeferralResolver();

    /// <summary>
    /// Notifies the system that the app has finished processing the button click event.
    /// </summary>
    /// <param name="e">The requested <see cref="ContentDialogButtonClickDeferral"/>.</param>
    public static void CompleteWrapped(this ContentDialogButtonClickDeferral e) => Resolver.Complete(e);

    private sealed class DefaultContentDialogButtonClickDeferralResolver : IContentDialogButtonClickDeferralResolver
    {
        void IContentDialogButtonClickDeferralResolver.Complete(ContentDialogButtonClickDeferral e) => e.Complete();
    }
}

/// <summary>
/// Resolves data of the <see cref="ContentDialogButtonClickDeferral"/>.
/// </summary>
public interface IContentDialogButtonClickDeferralResolver
{
    /// <summary>
    /// Notifies the system that the app has finished processing the button click event.
    /// </summary>
    /// <param name="e">The requested <see cref="ContentDialogButtonClickDeferral"/>.</param>
    void Complete(ContentDialogButtonClickDeferral e);
}