// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc;

internal class TestElement : ContentControl
{
    public event RoutedEventHandler? Changed;

    public void RaiseChanged() => Changed?.Invoke(this, new RoutedEventArgs());
}