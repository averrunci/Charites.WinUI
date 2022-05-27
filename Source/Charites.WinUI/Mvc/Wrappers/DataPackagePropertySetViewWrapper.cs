// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage.Streams;
using Windows.UI;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="DataPackagePropertySetView"/>
/// resolved by <see cref="IDataPackagePropertySetViewResolver"/>.
/// </summary>
public static class DataPackagePropertySetViewWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IDataPackagePropertySetViewResolver"/>
    /// that resolves data of the <see cref="DataPackagePropertySetView"/>.
    /// </summary>
    public static IDataPackagePropertySetViewResolver Resolver { get; set; } = new DefaultDataPackagePropertySetViewResolver();

    /// <summary>
    /// Gets the Uniform Resource Identifier (URI) of the app's location in the Microsoft Store.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The Uniform Resource Identifier (URI) of the app in the Microsoft Store.</returns>
    public static Uri ApplicationListingUri(this DataPackagePropertySetView dataPackagePropertySetView) => Resolver.ApplicationListingUri(dataPackagePropertySetView);

    /// <summary>
    /// Gets the name of the app that created the <see cref="DataPackage"/> object.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The name of the app that created the <see cref="DataPackage"/> object.</returns>
    public static string ApplicationName(this DataPackagePropertySetView dataPackagePropertySetView) => Resolver.ApplicationName(dataPackagePropertySetView);

    /// <summary>
    /// Gets the application link to the content from the source app.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The Uniform Resource Identifier (URI) of the application link to shared content.</returns>
    public static Uri ContentSourceApplicationLink(this DataPackagePropertySetView dataPackagePropertySetView) => Resolver.ContentSourceApplicationLink(dataPackagePropertySetView);

    /// <summary>
    /// Gets the UserActivity in serialized JSON format to be shared with another app.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The UserActivity in serialized JSON format to be shared with another app.</returns>
    public static string ContentSourceUserActivityJson(this DataPackagePropertySetView dataPackagePropertySetView) => Resolver.ContentSourceUserActivityJson(dataPackagePropertySetView);

    /// <summary>
    /// Gets a web link to shared content that's currently displayed in the app.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The Uniform Resource Identifier (URI) of the web link to shared content.</returns>
    public static Uri ContentSourceWebLink(this DataPackagePropertySetView dataPackagePropertySetView) => Resolver.ContentSourceWebLink(dataPackagePropertySetView);

    /// <summary>
    /// Gets the text that describes the contents of the <see cref="DataPackage"/>.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>Text that describes the contents of the <see cref="DataPackage"/>.</returns>
    public static string Description(this DataPackagePropertySetView dataPackagePropertySetView) => Resolver.Description(dataPackagePropertySetView);

    /// <summary>
    /// Gets the enterprise Id.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The enterprise Id.</returns>
    public static string EnterpriseId(this DataPackagePropertySetView dataPackagePropertySetView) => Resolver.EnterpriseId(dataPackagePropertySetView);

    /// <summary>
    /// Gets a vector object that contains the types of files stored in the <see cref="DataPackage"/> object.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>Contains the types of files stored in the <see cref="DataPackage"/> object.</returns>
    public static IReadOnlyList<string> FileTypes(this DataPackagePropertySetView dataPackagePropertySetView) => Resolver.FileTypes(dataPackagePropertySetView);

    /// <summary>
    /// Gets a value that indicates whether the shared content in the <see cref="DataPackageView"/> comes from clipboard data that was synced from another device for the current user.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>True if the shared content in the <see cref="DataPackageView"/> comes from clipboard data that was synced from another device for the current user; otherwise, false.</returns>
    public static bool IsFromRoamingClipboard(this DataPackagePropertySetView dataPackagePropertySetView) => Resolver.IsFromRoamingClipboard(dataPackagePropertySetView);

    /// <summary>
    /// Gets a background color for the sharing app's Square30x30Logo.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The background color for the sharing app's Square30x30Logo.</returns>
    public static Color LogoBackgroundColor(this DataPackagePropertySetView dataPackagePropertySetView) => Resolver.LogoBackgroundColor(dataPackagePropertySetView);

    /// <summary>
    /// Gets the package family name of the source app.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The package family name.</returns>
    public static string PackageFamilyName(this DataPackagePropertySetView dataPackagePropertySetView) => Resolver.PackageFamilyName(dataPackagePropertySetView);

    /// <summary>
    /// Gets the source app's logo.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The logo's bitmap.</returns>
    public static IRandomAccessStreamReference Square30x30Logo(this DataPackagePropertySetView dataPackagePropertySetView) => Resolver.Square30x30Logo(dataPackagePropertySetView);

    /// <summary>
    /// Gets the thumbnail image for the <see cref="DataPackageView"/>.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The <see cref="IRandomAccessStreamReference"/> that represents the thumbnail image.</returns>
    public static RandomAccessStreamReference Thumbnail(this DataPackagePropertySetView dataPackagePropertySetView) => Resolver.Thumbnail(dataPackagePropertySetView);

    /// <summary>
    /// Gets the text that displays as a title for the contents of the <see cref="DataPackagePropertySetView"/> object.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The text that displays as a title for the contents of the <see cref="DataPackagePropertySetView"/> object.</returns>
    public static string Title(this DataPackagePropertySetView dataPackagePropertySetView) => Resolver.Title(dataPackagePropertySetView);

    private sealed class DefaultDataPackagePropertySetViewResolver : IDataPackagePropertySetViewResolver
    {
        Uri IDataPackagePropertySetViewResolver.ApplicationListingUri(DataPackagePropertySetView dataPackagePropertySetView) => dataPackagePropertySetView.ApplicationListingUri;
        string IDataPackagePropertySetViewResolver.ApplicationName(DataPackagePropertySetView dataPackagePropertySetView) => dataPackagePropertySetView.ApplicationName;
        Uri IDataPackagePropertySetViewResolver.ContentSourceApplicationLink(DataPackagePropertySetView dataPackagePropertySetView) => dataPackagePropertySetView.ContentSourceApplicationLink;
        string IDataPackagePropertySetViewResolver.ContentSourceUserActivityJson(DataPackagePropertySetView dataPackagePropertySetView) => dataPackagePropertySetView.ContentSourceUserActivityJson;
        Uri IDataPackagePropertySetViewResolver.ContentSourceWebLink(DataPackagePropertySetView dataPackagePropertySetView) => dataPackagePropertySetView.ContentSourceWebLink;
        string IDataPackagePropertySetViewResolver.Description(DataPackagePropertySetView dataPackagePropertySetView) => dataPackagePropertySetView.Description;
        string IDataPackagePropertySetViewResolver.EnterpriseId(DataPackagePropertySetView dataPackagePropertySetView) => dataPackagePropertySetView.EnterpriseId;
        IReadOnlyList<string> IDataPackagePropertySetViewResolver.FileTypes(DataPackagePropertySetView dataPackagePropertySetView) => dataPackagePropertySetView.FileTypes;
        bool IDataPackagePropertySetViewResolver.IsFromRoamingClipboard(DataPackagePropertySetView dataPackagePropertySetView) => dataPackagePropertySetView.IsFromRoamingClipboard;
        Color IDataPackagePropertySetViewResolver.LogoBackgroundColor(DataPackagePropertySetView dataPackagePropertySetView) => dataPackagePropertySetView.LogoBackgroundColor;
        string IDataPackagePropertySetViewResolver.PackageFamilyName(DataPackagePropertySetView dataPackagePropertySetView) => dataPackagePropertySetView.PackageFamilyName;
        IRandomAccessStreamReference IDataPackagePropertySetViewResolver.Square30x30Logo(DataPackagePropertySetView dataPackagePropertySetView) => dataPackagePropertySetView.Square30x30Logo;
        RandomAccessStreamReference IDataPackagePropertySetViewResolver.Thumbnail(DataPackagePropertySetView dataPackagePropertySetView) => dataPackagePropertySetView.Thumbnail;
        string IDataPackagePropertySetViewResolver.Title(DataPackagePropertySetView dataPackagePropertySetView) => dataPackagePropertySetView.Title;
    }
}

/// <summary>
/// Resolves data of the <see cref="DataPackagePropertySetView"/>.
/// </summary>
public interface IDataPackagePropertySetViewResolver
{
    /// <summary>
    /// Gets the Uniform Resource Identifier (URI) of the app's location in the Microsoft Store.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The Uniform Resource Identifier (URI) of the app in the Microsoft Store.</returns>
    Uri ApplicationListingUri(DataPackagePropertySetView dataPackagePropertySetView);

    /// <summary>
    /// Gets the name of the app that created the <see cref="DataPackage"/> object.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The name of the app that created the <see cref="DataPackage"/> object.</returns>
    string ApplicationName(DataPackagePropertySetView dataPackagePropertySetView);

    /// <summary>
    /// Gets the application link to the content from the source app.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The Uniform Resource Identifier (URI) of the application link to shared content.</returns>
    Uri ContentSourceApplicationLink(DataPackagePropertySetView dataPackagePropertySetView);

    /// <summary>
    /// Gets the UserActivity in serialized JSON format to be shared with another app.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The UserActivity in serialized JSON format to be shared with another app.</returns>
    string ContentSourceUserActivityJson(DataPackagePropertySetView dataPackagePropertySetView);

    /// <summary>
    /// Gets a web link to shared content that's currently displayed in the app.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The Uniform Resource Identifier (URI) of the web link to shared content.</returns>
    Uri ContentSourceWebLink(DataPackagePropertySetView dataPackagePropertySetView);

    /// <summary>
    /// Gets the text that describes the contents of the <see cref="DataPackage"/>.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>Text that describes the contents of the <see cref="DataPackage"/>.</returns>
    string Description(DataPackagePropertySetView dataPackagePropertySetView);

    /// <summary>
    /// Gets the enterprise Id.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The enterprise Id.</returns>
    string EnterpriseId(DataPackagePropertySetView dataPackagePropertySetView);

    /// <summary>
    /// Gets a vector object that contains the types of files stored in the <see cref="DataPackage"/> object.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>Contains the types of files stored in the <see cref="DataPackage"/> object.</returns>
    IReadOnlyList<string> FileTypes(DataPackagePropertySetView dataPackagePropertySetView);

    /// <summary>
    /// Gets a value that indicates whether the shared content in the <see cref="DataPackageView"/> comes from clipboard data that was synced from another device for the current user.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>True if the shared content in the <see cref="DataPackageView"/> comes from clipboard data that was synced from another device for the current user; otherwise, false.</returns>
    bool IsFromRoamingClipboard(DataPackagePropertySetView dataPackagePropertySetView);

    /// <summary>
    /// Gets a background color for the sharing app's Square30x30Logo.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The background color for the sharing app's Square30x30Logo.</returns>
    Color LogoBackgroundColor(DataPackagePropertySetView dataPackagePropertySetView);

    /// <summary>
    /// Gets the package family name of the source app.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The package family name.</returns>
    string PackageFamilyName(DataPackagePropertySetView dataPackagePropertySetView);

    /// <summary>
    /// Gets the source app's logo.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The logo's bitmap.</returns>
    IRandomAccessStreamReference Square30x30Logo(DataPackagePropertySetView dataPackagePropertySetView);

    /// <summary>
    /// Gets the thumbnail image for the <see cref="DataPackageView"/>.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The <see cref="IRandomAccessStreamReference"/> that represents the thumbnail image.</returns>
    RandomAccessStreamReference Thumbnail(DataPackagePropertySetView dataPackagePropertySetView);

    /// <summary>
    /// Gets the text that displays as a title for the contents of the <see cref="DataPackagePropertySetView"/> object.
    /// </summary>
    /// <param name="dataPackagePropertySetView">The requested <see cref="DataPackagePropertySetView"/>.</param>
    /// <returns>The text that displays as a title for the contents of the <see cref="DataPackagePropertySetView"/> object.</returns>
    string Title(DataPackagePropertySetView dataPackagePropertySetView);
}