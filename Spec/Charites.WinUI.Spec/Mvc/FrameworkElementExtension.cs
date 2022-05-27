// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc;

internal static class FrameworkElementExtension
{
    public static T GetController<T>(this FrameworkElement element) => WinUIController.GetControllers(element).OfType<T>().First();
}