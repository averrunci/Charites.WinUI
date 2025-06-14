﻿// Copyright (C) 2022-2025 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using System.Reflection;

namespace Charites.Windows.Mvc;

internal sealed class WinUIEventHandlerAction(
    MethodInfo method, object? target,
    IParameterDependencyResolver parameterDependencyResolver
) : EventHandlerAction(method, target, parameterDependencyResolver)
{
    protected override bool HandleUnhandledException(Exception exc) => WinUIController.HandleUnhandledException(exc);
}