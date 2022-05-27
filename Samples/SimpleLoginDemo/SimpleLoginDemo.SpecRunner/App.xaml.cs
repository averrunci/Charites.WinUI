﻿// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Carna.WinUIRunner;
using Microsoft.UI.Xaml;

namespace Charites.Windows.Samples.SimpleLoginDemo.SpecRunner;

public partial class App
{
    public App()
    {
        InitializeComponent();
    }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        CarnaWinUIRunner.Run();
    }
}