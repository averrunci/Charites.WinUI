// Copyright (C) 2022-2025 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc;

internal sealed class WinUIEventHandlerParameterFromElementResolver(object? associatedElement) : EventHandlerParameterFromElementResolver(associatedElement)
{
    protected override object? FindElement(string name)
        => AssociatedElement is FrameworkElement rootElement ? WinUIController.ElementFinder.FindElement(rootElement, name) : null;
}