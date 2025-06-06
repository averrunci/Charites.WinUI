// Copyright (C) 2022-2025 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc;

/// <summary>
/// Provides the function to find a data context in a view.
/// </summary>
public interface IWinUIDataContextFinder : IDataContextFinder<FrameworkElement>;