// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc;

/// <summary>
/// Default styles for the controls in the Charites.WinUI.
/// </summary>
public class XamlControlsResources : ResourceDictionary
{
    /// <summary>
    /// Initializes a new instance of the <see cref="XamlControlsResources"/> class.
    /// </summary>
    public XamlControlsResources()
    {
        Source = new Uri("ms-appx:///Charites.WinUI/Resources.xaml");
    }
}