// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc;

internal sealed class WinUIElementFinder : IWinUIElementFinder
{
    public object? FindElement(FrameworkElement? rootElement, string elementName)
        => rootElement.FindElement<object>(elementName);
}