﻿// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using System.Reflection;
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc;

internal sealed class WinUIControllerTypeFinder : ControllerTypeFinder<FrameworkElement>, IWinUIControllerTypeFinder
{
    public IWinUIControllerTypeContainer? ControllerTypeContainer { get; set; }

    public WinUIControllerTypeFinder(IWinUIElementKeyFinder elementKeyFinder, IWinUIDataContextFinder dataContextFinder) : base(elementKeyFinder, dataContextFinder)
    {
    }

    protected override IEnumerable<Type> FindControllerTypeCandidates(FrameworkElement view)
        => GetControllerTypes()
            .Concat(GetType().Assembly.GetTypes().Where(type => type.GetCustomAttributes<ViewAttribute>(true).Any()))
            .Concat(view.DataContext?.GetType().Assembly.GetTypes() ?? Enumerable.Empty<Type>())
            .Distinct();

    private IEnumerable<Type> GetControllerTypes()
        => ControllerTypeContainer?.GetControllerTypes() ?? Enumerable.Empty<Type>();
}