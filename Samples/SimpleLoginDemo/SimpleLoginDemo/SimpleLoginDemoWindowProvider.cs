// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Charites.Windows.Samples.SimpleLoginDemo.Presentation;
using Microsoft.UI.Xaml;

namespace Charites.Windows.Samples.SimpleLoginDemo;

internal sealed class SimpleLoginDemoWindowProvider : ISimpleLoginDemoWindowProvider
{
    public Window Window => window ?? throw new InvalidOperationException();
    private Window? window;

    public void Register(Window window) => this.window = window;
}