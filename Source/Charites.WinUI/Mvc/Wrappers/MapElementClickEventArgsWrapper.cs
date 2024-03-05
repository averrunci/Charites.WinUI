// Copyright (C) 2024 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Devices.Geolocation;
using Microsoft.UI.Xaml.Controls;

namespace Charites.Windows.Mvc.Wrappers
{
    /// <summary>
    /// Provides data of the <see cref="MapElementClickEventArgs"/>
    /// resolved by <see cref="IMapElementClickEventArgsResolver"/>.
    /// </summary>
    public static class MapElementClickEventArgsWrapper
    {
        /// <summary>
        /// Gets or sets the <see cref="IMapElementClickEventArgsResolver"/>
        /// that resolves data of the <see cref="MapElementClickEventArgs"/>.
        /// </summary>
        public static IMapElementClickEventArgsResolver Resolver { get; set; } = new DefaultMapElementClickEventArgsResolver();

        /// <summary>
        /// Gets the map element that corresponds to where the map received user input.
        /// </summary>
        /// <param name="e">The requested <see cref="MapElementClickEventArgs"/>.</param>
        /// <returns>The map element that corresponds to where the map received user input.</returns>
        public static MapElement Element(this MapElementClickEventArgs e) => Resolver.Element(e);

        /// <summary>
        /// Gets the geographic location that corresponds to where the map received user input.
        /// </summary>
        /// <param name="e">The requested <see cref="MapElementClickEventArgs"/>.</param>
        /// <returns>The geographic location that corresponds to where the map received user input.</returns>
        public static Geopoint Location(this MapElementClickEventArgs e) => Resolver.Location(e);

        private sealed class DefaultMapElementClickEventArgsResolver : IMapElementClickEventArgsResolver
        {
            MapElement IMapElementClickEventArgsResolver.Element(MapElementClickEventArgs e) => e.Element;
            Geopoint IMapElementClickEventArgsResolver.Location(MapElementClickEventArgs e) => e.Location;
        }
    }

    /// <summary>
    /// Resolves data of the <see cref="MapElementClickEventArgs"/>.
    /// </summary>
    public interface IMapElementClickEventArgsResolver
    {
        /// <summary>
        /// Gets the map element that corresponds to where the map received user input.
        /// </summary>
        /// <param name="e">The requested <see cref="MapElementClickEventArgs"/>.</param>
        /// <returns>The map element that corresponds to where the map received user input.</returns>
        MapElement Element(MapElementClickEventArgs e);

        /// <summary>
        /// Gets the geographic location that corresponds to where the map received user input.
        /// </summary>
        /// <param name="e">The requested <see cref="MapElementClickEventArgs"/>.</param>
        /// <returns>The geographic location that corresponds to where the map received user input.</returns>
        Geopoint Location(MapElementClickEventArgs e);
    }
}