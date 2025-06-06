// Copyright (C) 2022-2025 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc;

internal sealed class WinUIEventHandlerParameterFromDataContextResolver(object? associatedElement) : EventHandlerParameterFromDataContextResolver(associatedElement)
{
    protected override object? FindDataContext()
        => AssociatedElement is FrameworkElement view ? WinUIController.DataContextFinder.Find(view) : null;
}