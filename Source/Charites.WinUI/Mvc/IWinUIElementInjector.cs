﻿// Copyright (C) 2022-2025 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc;

/// <summary>
/// Provides the function to inject elements in a view to a controller.
/// </summary>
public interface IWinUIElementInjector : IElementInjector<FrameworkElement>;