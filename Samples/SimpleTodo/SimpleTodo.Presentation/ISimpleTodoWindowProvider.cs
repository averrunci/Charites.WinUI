﻿// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;

namespace Charites.Windows.Samples.SimpleTodo.Presentation;

public interface ISimpleTodoWindowProvider
{
    Window Window { get; }
}