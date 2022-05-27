// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Foundation;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="Deferral"/>
/// resolved by <see cref="IDeferralResolver"/>.
/// </summary>
public static class DeferralWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IDeferralResolver"/>
    /// that resolves data of the <see cref="Deferral"/>.
    /// </summary>
    public static IDeferralResolver Resolver { get; set; } = new DefaultDeferralResolver();

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing,
    /// or resetting unmanaged resources.
    /// </summary>
    /// <param name="deferral">The requested <see cref="Deferral"/>.</param>
    public static void Dispose(this Deferral deferral) => Resolver.Dispose(deferral);

    /// <summary>
    /// If the <see cref="DeferralCompletedHandler"/> has not yet been invoked,
    /// this will call it and drop the reference to the delegate.
    /// </summary>
    /// <param name="deferral">The requested <see cref="Deferral"/>.</param>
    public static void Complete(this Deferral deferral) => Resolver.Complete(deferral);

    private sealed class DefaultDeferralResolver : IDeferralResolver
    {
        void IDeferralResolver.Dispose(Deferral deferral) => deferral.Dispose();
        void IDeferralResolver.Complete(Deferral deferral) => deferral.Complete();
    }
}

/// <summary>
/// Resolves data of the <see cref="Deferral"/>.
/// </summary>
public interface IDeferralResolver
{
    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing,
    /// or resetting unmanaged resources.
    /// </summary>
    /// <param name="deferral">The requested <see cref="Deferral"/>.</param>
    void Dispose(Deferral deferral);

    /// <summary>
    /// If the <see cref="DeferralCompletedHandler"/> has not yet been invoked,
    /// this will call it and drop the reference to the delegate.
    /// </summary>
    /// <param name="deferral">The requested <see cref="Deferral"/>.</param>
    void Complete(Deferral deferral);
}