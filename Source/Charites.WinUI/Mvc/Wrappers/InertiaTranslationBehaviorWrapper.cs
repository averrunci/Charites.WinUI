// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Input;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="InertiaTranslationBehavior"/>
/// resolved by <see cref="IInertiaTranslationBehaviorResolver"/>.
/// </summary>
public static class InertiaTranslationBehaviorWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IInertiaTranslationBehaviorResolver"/>
    /// that resolves data of the <see cref="InertiaTranslationBehavior"/>.
    /// </summary>
    public static IInertiaTranslationBehaviorResolver Resolver { get; set; } = new DefaultInertiaTranslationBehaviorResolver();

    /// <summary>
    /// Gets the rate the linear movement slows in device-independent units (1/96th inch per unit) per squared millisecond.
    /// </summary>
    /// <param name="inertiaTranslationBehavior">The requested <see cref="InertiaTranslationBehavior"/>.</param>
    /// <returns>
    /// The rate the linear movement slows in device-independent units (1/96th inch per unit) per squared millisecond.
    /// </returns>
    public static double DesiredDeceleration(this InertiaTranslationBehavior inertiaTranslationBehavior) => Resolver.DesiredDeceleration(inertiaTranslationBehavior);

    /// <summary>
    /// Sets the rate the linear movement slows in device-independent units (1/96th inch per unit) per squared millisecond.
    /// </summary>
    /// <param name="inertiaTranslationBehavior">The requested <see cref="InertiaTranslationBehavior"/>.</param>
    /// <param name="desiredDeceleration">
    /// The rate the linear movement slows in device-independent units (1/96th inch per unit) per squared millisecond.
    /// </param>
    public static void DesiredDeceleration(this InertiaTranslationBehavior inertiaTranslationBehavior, double desiredDeceleration) => Resolver.DesiredDeceleration(inertiaTranslationBehavior, desiredDeceleration);

    /// <summary>
    /// Gets the linear movement of the manipulation at the end of inertia.
    /// </summary>
    /// <param name="inertiaTranslationBehavior">The requested <see cref="InertiaTranslationBehavior"/>.</param>
    /// <returns>The linear movement of the manipulation at the end of inertia.</returns>
    public static double DesiredDisplacement(this InertiaTranslationBehavior inertiaTranslationBehavior) => Resolver.DesiredDisplacement(inertiaTranslationBehavior);

    /// <summary>
    /// Sets the linear movement of the manipulation at the end of inertia.
    /// </summary>
    /// <param name="inertiaTranslationBehavior">The requested <see cref="InertiaTranslationBehavior"/>.</param>
    /// <param name="desiredDisplacement">The linear movement of the manipulation at the end of inertia.</param>
    public static void DesiredDisplacement(this InertiaTranslationBehavior inertiaTranslationBehavior, double desiredDisplacement) => Resolver.DesiredDisplacement(inertiaTranslationBehavior, desiredDisplacement);

    private sealed class DefaultInertiaTranslationBehaviorResolver : IInertiaTranslationBehaviorResolver
    {
        double IInertiaTranslationBehaviorResolver.DesiredDeceleration(InertiaTranslationBehavior inertiaTranslationBehavior) => inertiaTranslationBehavior.DesiredDeceleration;
        void IInertiaTranslationBehaviorResolver.DesiredDeceleration(InertiaTranslationBehavior inertiaTranslationBehavior, double desiredDeceleration) => inertiaTranslationBehavior.DesiredDeceleration = desiredDeceleration;
        double IInertiaTranslationBehaviorResolver.DesiredDisplacement(InertiaTranslationBehavior inertiaTranslationBehavior) => inertiaTranslationBehavior.DesiredDisplacement;
        void IInertiaTranslationBehaviorResolver.DesiredDisplacement(InertiaTranslationBehavior inertiaTranslationBehavior, double desiredDisplacement) => inertiaTranslationBehavior.DesiredDisplacement = desiredDisplacement;
    }
}

/// <summary>
/// Resolves data of the <see cref="InertiaTranslationBehavior"/>.
/// </summary>
public interface IInertiaTranslationBehaviorResolver
{
    /// <summary>
    /// Gets the rate the linear movement slows in device-independent units (1/96th inch per unit) per squared millisecond.
    /// </summary>
    /// <param name="inertiaTranslationBehavior">The requested <see cref="InertiaTranslationBehavior"/>.</param>
    /// <returns>
    /// The rate the linear movement slows in device-independent units (1/96th inch per unit) per squared millisecond.
    /// </returns>
    double DesiredDeceleration(InertiaTranslationBehavior inertiaTranslationBehavior);

    /// <summary>
    /// Sets the rate the linear movement slows in device-independent units (1/96th inch per unit) per squared millisecond.
    /// </summary>
    /// <param name="inertiaTranslationBehavior">The requested <see cref="InertiaTranslationBehavior"/>.</param>
    /// <param name="desiredDeceleration">
    /// The rate the linear movement slows in device-independent units (1/96th inch per unit) per squared millisecond.
    /// </param>
    void DesiredDeceleration(InertiaTranslationBehavior inertiaTranslationBehavior, double desiredDeceleration);

    /// <summary>
    /// Gets the linear movement of the manipulation at the end of inertia.
    /// </summary>
    /// <param name="inertiaTranslationBehavior">The requested <see cref="InertiaTranslationBehavior"/>.</param>
    /// <returns>The linear movement of the manipulation at the end of inertia.</returns>
    double DesiredDisplacement(InertiaTranslationBehavior inertiaTranslationBehavior);

    /// <summary>
    /// Sets the linear movement of the manipulation at the end of inertia.
    /// </summary>
    /// <param name="inertiaTranslationBehavior">The requested <see cref="InertiaTranslationBehavior"/>.</param>
    /// <param name="desiredDisplacement">The linear movement of the manipulation at the end of inertia.</param>
    void DesiredDisplacement(InertiaTranslationBehavior inertiaTranslationBehavior, double desiredDisplacement);
}