// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Input;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="InertiaRotationBehavior"/>
/// resolved by <see cref="IInertiaRotationBehaviorResolver"/>.
/// </summary>
public static class InertiaRotationBehaviorWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IInertiaRotationBehaviorResolver"/>
    /// that resolves data of the <see cref="InertiaRotationBehavior"/>.
    /// </summary>
    public static IInertiaRotationBehaviorResolver Resolver { get; set; } = new DefaultInertiaRotationBehaviorResolver();

    /// <summary>
    /// Gets the rate the rotation slows in degrees per squared millisecond.
    /// </summary>
    /// <param name="inertiaRotationBehavior">The requested <see cref="InertiaRotationBehavior"/>.</param>
    /// <returns>The rate the rotation slows in degrees per squared millisecond.</returns>
    public static double DesiredDeceleration(this InertiaRotationBehavior inertiaRotationBehavior) => Resolver.DesiredDeceleration(inertiaRotationBehavior);

    /// <summary>
    /// Sets the rate the rotation slows in degrees per squared millisecond.
    /// </summary>
    /// <param name="inertiaRotationBehavior">The requested <see cref="InertiaRotationBehavior"/>.</param>
    /// <param name="desiredDeceleration">The rate the rotation slows in degrees per squared millisecond.</param>
    public static void DesiredDeceleration(this InertiaRotationBehavior inertiaRotationBehavior, double desiredDeceleration) => Resolver.DesiredDeceleration(inertiaRotationBehavior, desiredDeceleration);

    /// <summary>
    /// Gets the rotation, in degrees, at the end of the inertial movement.
    /// </summary>
    /// <param name="inertiaRotationBehavior">The requested <see cref="InertiaRotationBehavior"/>.</param>
    /// <returns>The rotation, in degrees, at the end of the inertial movement.</returns>
    public static double DesiredRotation(this InertiaRotationBehavior inertiaRotationBehavior) => Resolver.DesiredRotation(inertiaRotationBehavior);

    /// <summary>
    /// Sets the rotation, in degrees, at the end of the inertial movement.
    /// </summary>
    /// <param name="inertiaRotationBehavior">The requested <see cref="InertiaRotationBehavior"/>.</param>
    /// <param name="desiredRotation">The rotation, in degrees, at the end of the inertial movement.</param>
    public static void DesiredRotation(this InertiaRotationBehavior inertiaRotationBehavior, double desiredRotation) => Resolver.DesiredRotation(inertiaRotationBehavior, desiredRotation);

    private sealed class DefaultInertiaRotationBehaviorResolver : IInertiaRotationBehaviorResolver
    {
        double IInertiaRotationBehaviorResolver.DesiredDeceleration(InertiaRotationBehavior inertiaRotationBehavior) => inertiaRotationBehavior.DesiredDeceleration;
        void IInertiaRotationBehaviorResolver.DesiredDeceleration(InertiaRotationBehavior inertiaRotationBehavior, double desiredDeceleration) => inertiaRotationBehavior.DesiredDeceleration = desiredDeceleration;
        double IInertiaRotationBehaviorResolver.DesiredRotation(InertiaRotationBehavior inertiaRotationBehavior) => inertiaRotationBehavior.DesiredRotation;
        void IInertiaRotationBehaviorResolver.DesiredRotation(InertiaRotationBehavior inertiaRotationBehavior, double desiredRotation) => inertiaRotationBehavior.DesiredRotation = desiredRotation;
    }
}

/// <summary>
/// Resolves data of the <see cref="InertiaRotationBehavior"/>.
/// </summary>
public interface IInertiaRotationBehaviorResolver
{
    /// <summary>
    /// Gets the rate the rotation slows in degrees per squared millisecond.
    /// </summary>
    /// <param name="inertiaRotationBehavior">The requested <see cref="InertiaRotationBehavior"/>.</param>
    /// <returns>The rate the rotation slows in degrees per squared millisecond.</returns>
    double DesiredDeceleration(InertiaRotationBehavior inertiaRotationBehavior);

    /// <summary>
    /// Sets the rate the rotation slows in degrees per squared millisecond.
    /// </summary>
    /// <param name="inertiaRotationBehavior">The requested <see cref="InertiaRotationBehavior"/>.</param>
    /// <param name="desiredDeceleration">The rate the rotation slows in degrees per squared millisecond.</param>
    void DesiredDeceleration(InertiaRotationBehavior inertiaRotationBehavior, double desiredDeceleration);

    /// <summary>
    /// Gets the rotation, in degrees, at the end of the inertial movement.
    /// </summary>
    /// <param name="inertiaRotationBehavior">The requested <see cref="InertiaRotationBehavior"/>.</param>
    /// <returns>The rotation, in degrees, at the end of the inertial movement.</returns>
    double DesiredRotation(InertiaRotationBehavior inertiaRotationBehavior);

    /// <summary>
    /// Sets the rotation, in degrees, at the end of the inertial movement.
    /// </summary>
    /// <param name="inertiaRotationBehavior">The requested <see cref="InertiaRotationBehavior"/>.</param>
    /// <param name="desiredRotation">The rotation, in degrees, at the end of the inertial movement.</param>
    void DesiredRotation(InertiaRotationBehavior inertiaRotationBehavior, double desiredRotation);
}