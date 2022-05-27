// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
namespace Charites.Windows.Mvc;

/// <summary>
/// Provides the function to get all controller types defined in a project.
/// </summary>
public interface IWinUIControllerTypeContainer
{
    /// <summary>
    /// Gets all controllers.
    /// </summary>
    /// <returns>The controllers defined in a project.</returns>
    IEnumerable<Type> GetControllerTypes();
}