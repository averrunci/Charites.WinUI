// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Input;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="InertiaExpansionBehavior"/>
/// resolved by <see cref="IInertiaExpansionBehaviorResolver"/>.
/// </summary>
public static class InertiaExpansionBehaviorWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IInertiaExpansionBehaviorResolver"/>
    /// that resolves data of the <see cref="InertiaExpansionBehavior"/>.
    /// </summary>
    public static IInertiaExpansionBehaviorResolver Resolver { get; set; } = new DefaultInertiaExpansionBehaviorResolver();

    /// <summary>
    /// Gets the rate that resizing slows.
    /// </summary>
    /// <param name="inertiaExpansionBehavior">The requested <see cref="InertiaExpansionBehavior"/>.</param>
    /// <returns>The rate that resizing slows.</returns>
    public static double DesiredDeceleration(this InertiaExpansionBehavior inertiaExpansionBehavior) => Resolver.DesiredDeceleration(inertiaExpansionBehavior);

    /// <summary>
    /// Sets the rate that resizing slows.
    /// </summary>
    /// <param name="inertiaExpansionBehavior">The requested <see cref="InertiaExpansionBehavior"/>.</param>
    /// <param name="desiredDeceleration">The rate that resizing slows.</param>
    public static void DesiredDeceleration(this InertiaExpansionBehavior inertiaExpansionBehavior, double desiredDeceleration) => Resolver.DesiredDeceleration(inertiaExpansionBehavior, desiredDeceleration);

    /// <summary>
    /// Gets the amount the element resizes at the end of inertia.
    /// </summary>
    /// <param name="inertiaExpansionBehavior">The requested <see cref="InertiaExpansionBehavior"/>.</param>
    /// <returns>The amount the element resizes at the end of inertia.</returns>
    public static double DesiredExpansion(this InertiaExpansionBehavior inertiaExpansionBehavior) => Resolver.DesiredExpansion(inertiaExpansionBehavior);

    /// <summary>
    /// Sets the amount the element resizes at the end of inertia.
    /// </summary>
    /// <param name="inertiaExpansionBehavior">The requested <see cref="InertiaExpansionBehavior"/>.</param>
    /// <param name="desiredExpansion">The amount the element resizes at the end of inertia.</param>
    public static void DesiredExpansion(this InertiaExpansionBehavior inertiaExpansionBehavior, double desiredExpansion) => Resolver.DesiredExpansion(inertiaExpansionBehavior, desiredExpansion);

    private sealed class DefaultInertiaExpansionBehaviorResolver : IInertiaExpansionBehaviorResolver
    {
        double IInertiaExpansionBehaviorResolver.DesiredDeceleration(InertiaExpansionBehavior inertiaExpansionBehavior) => inertiaExpansionBehavior.DesiredDeceleration;
        void IInertiaExpansionBehaviorResolver.DesiredDeceleration(InertiaExpansionBehavior inertiaExpansionBehavior, double desiredDeceleration) => inertiaExpansionBehavior.DesiredDeceleration = desiredDeceleration;
        double IInertiaExpansionBehaviorResolver.DesiredExpansion(InertiaExpansionBehavior inertiaExpansionBehavior) => inertiaExpansionBehavior.DesiredExpansion;
        void IInertiaExpansionBehaviorResolver.DesiredExpansion(InertiaExpansionBehavior inertiaExpansionBehavior, double desiredExpansion) => inertiaExpansionBehavior.DesiredExpansion = desiredExpansion;
    }
}

/// <summary>
/// Resolves data of the <see cref="InertiaExpansionBehavior"/>.
/// </summary>
public interface IInertiaExpansionBehaviorResolver
{
    /// <summary>
    /// Gets the rate that resizing slows.
    /// </summary>
    /// <param name="inertiaExpansionBehavior">The requested <see cref="InertiaExpansionBehavior"/>.</param>
    /// <returns>The rate that resizing slows.</returns>
    double DesiredDeceleration(InertiaExpansionBehavior inertiaExpansionBehavior);

    /// <summary>
    /// Sets the rate that resizing slows.
    /// </summary>
    /// <param name="inertiaExpansionBehavior">The requested <see cref="InertiaExpansionBehavior"/>.</param>
    /// <param name="desiredDeceleration">The rate that resizing slows.</param>
    void DesiredDeceleration(InertiaExpansionBehavior inertiaExpansionBehavior, double desiredDeceleration);

    /// <summary>
    /// Gets the amount the element resizes at the end of inertia.
    /// </summary>
    /// <param name="inertiaExpansionBehavior">The requested <see cref="InertiaExpansionBehavior"/>.</param>
    /// <returns>The amount the element resizes at the end of inertia.</returns>
    double DesiredExpansion(InertiaExpansionBehavior inertiaExpansionBehavior);

    /// <summary>
    /// Sets the amount the element resizes at the end of inertia.
    /// </summary>
    /// <param name="inertiaExpansionBehavior">The requested <see cref="InertiaExpansionBehavior"/>.</param>
    /// <param name="desiredExpansion">The amount the element resizes at the end of inertia.</param>
    void DesiredExpansion(InertiaExpansionBehavior inertiaExpansionBehavior, double desiredExpansion);
}