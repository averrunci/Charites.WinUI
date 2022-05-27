// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Graphics.Printing;
using Windows.Storage.Streams;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="PrintTaskOptions"/>
/// resolved by <see cref="IPrintTaskOptionsResolver"/>.
/// </summary>
public static class PrintTaskOptionsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IPrintTaskOptionsResolver"/>
    /// that resolves data of the <see cref="PrintTaskOptions"/>.
    /// </summary>
    public static IPrintTaskOptionsResolver Resolver { get; set; } = new DefaultPrintTaskOptionsResolver();

    /// <summary>
    /// Gets the binding option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The binding option.</returns>
    public static PrintBinding Binding(this PrintTaskOptions printTaskOptions) => Resolver.Binding(printTaskOptions);

    /// <summary>
    /// Sets the binding option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="binding">The binding option.</param>
    public static void Binding(this PrintTaskOptions printTaskOptions, PrintBinding binding) => Resolver.Binding(printTaskOptions, binding);

    /// <summary>
    /// Gets the bordering option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The bordering option.</returns>
    public static PrintBordering Bordering(this PrintTaskOptions printTaskOptions) => Resolver.Bordering(printTaskOptions);

    /// <summary>
    /// Sets the bordering option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="bordering">The bordering option.</param>
    public static void Bordering(this PrintTaskOptions printTaskOptions, PrintBordering bordering) => Resolver.Bordering(printTaskOptions, bordering);

    /// <summary>
    /// Gets the collation option of the print tasks.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The collation option.</returns>
    public static PrintCollation Collation(this PrintTaskOptions printTaskOptions) => Resolver.Collation(printTaskOptions);

    /// <summary>
    /// Sets the collation option of the print tasks.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="collation">The collation option.</param>
    public static void Collation(this PrintTaskOptions printTaskOptions, PrintCollation collation) => Resolver.Collation(printTaskOptions, collation);

    /// <summary>
    /// Gets the color mode option of the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The color mode option.</returns>
    public static PrintColorMode ColorMode(this PrintTaskOptions printTaskOptions) => Resolver.ColorMode(printTaskOptions);

    /// <summary>
    /// Sets the color mode option of the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="colorMode">The color mode option.</param>
    public static void ColorMode(this PrintTaskOptions printTaskOptions, PrintColorMode colorMode) => Resolver.ColorMode(printTaskOptions, colorMode);

    /// <summary>
    /// Gets the custom page range options for the print task.
    /// </summary>
    ///<param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The custom page range options.</returns>
    public static IList<PrintPageRange> CustomPageRanges(this PrintTaskOptions printTaskOptions) => Resolver.CustomPageRanges(printTaskOptions);

    /// <summary>
    /// Gets the list of options displayed for the print experience.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The list of displayed options.</returns>
    public static IList<string> DisplayedOptions(this PrintTaskOptions printTaskOptions) => Resolver.DisplayedOptions(printTaskOptions);

    /// <summary>
    /// Gets the duplex option of the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The duplex option.</returns>
    public static PrintDuplex Duplex(this PrintTaskOptions printTaskOptions) => Resolver.Duplex(printTaskOptions);

    /// <summary>
    /// Sets the duplex option of the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="duplex">The duplex option.</param>
    public static void Duplex(this PrintTaskOptions printTaskOptions, PrintDuplex duplex) => Resolver.Duplex(printTaskOptions, duplex);

    /// <summary>
    /// Gets the hole punch option of the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The hole punch option.</returns>
    public static PrintHolePunch HolePunch(this PrintTaskOptions printTaskOptions) => Resolver.HolePunch(printTaskOptions);

    /// <summary>
    /// Sets the hole punch option of the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="holePunch">The hole punch option.</param>
    public static void HolePunch(this PrintTaskOptions printTaskOptions, PrintHolePunch holePunch) => Resolver.HolePunch(printTaskOptions, holePunch);

    /// <summary>
    /// Gets the maximum number of copies supported for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The maximum number of copies.</returns>
    public static uint MaxCopies(this PrintTaskOptions printTaskOptions) => Resolver.MaxCopies(printTaskOptions);

    /// <summary>
    /// Gets the media size option of the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The media size option.</returns>
    public static PrintMediaSize MediaSize(this PrintTaskOptions printTaskOptions) => Resolver.MediaSize(printTaskOptions);

    /// <summary>
    /// Sets the media size option of the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="mediaSize">The media size option.</param>
    public static void MediaSize(this PrintTaskOptions printTaskOptions, PrintMediaSize mediaSize) => Resolver.MediaSize(printTaskOptions, mediaSize);

    /// <summary>
    /// Gets the media type option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The media type option.</returns>
    public static PrintMediaType MediaType(this PrintTaskOptions printTaskOptions) => Resolver.MediaType(printTaskOptions);

    /// <summary>
    /// Sets the media type option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="mediaType">The media type option.</param>
    public static void MediaType(this PrintTaskOptions printTaskOptions, PrintMediaType mediaType) => Resolver.MediaType(printTaskOptions, mediaType);

    /// <summary>
    /// Gets the minimum number of copies allowed for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The minimum number of copies.</returns>
    public static uint MinCopies(this PrintTaskOptions printTaskOptions) => Resolver.MinCopies(printTaskOptions);

    /// <summary>
    /// Gets the value for the number of copies for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The value for the number of copies.</returns>
    public static uint NumberOfCopies(this PrintTaskOptions printTaskOptions) => Resolver.NumberOfCopies(printTaskOptions);

    /// <summary>
    /// Sets the value for the number of copies for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="numberOfCopies">The value for the number of copies.</param>
    public static void NumberOfCopies(this PrintTaskOptions printTaskOptions, uint numberOfCopies) => Resolver.NumberOfCopies(printTaskOptions, numberOfCopies);

    /// <summary>
    /// Gets the orientation option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The orientation for the print task.</returns>
    public static PrintOrientation Orientation(this PrintTaskOptions printTaskOptions) => Resolver.Orientation(printTaskOptions);

    /// <summary>
    /// Sets the orientation option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="orientation">The orientation for the print task.</param>
    public static void Orientation(this PrintTaskOptions printTaskOptions, PrintOrientation orientation) => Resolver.Orientation(printTaskOptions, orientation);

    /// <summary>
    /// Gets the page range options for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The page range options.</returns>
    public static PrintPageRangeOptions PageRangeOptions(this PrintTaskOptions printTaskOptions) => Resolver.PageRangeOptions(printTaskOptions);

    /// <summary>
    /// Gets the print quality option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The print quality for the print task.</returns>
    public static PrintQuality PrintQuality(this PrintTaskOptions printTaskOptions) => Resolver.PrintQuality(printTaskOptions);

    /// <summary>
    /// Sets the print quality option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="printQuality">The print quality for the print task.</param>
    public static void PrintQuality(this PrintTaskOptions printTaskOptions, PrintQuality printQuality) => Resolver.PrintQuality(printTaskOptions, printQuality);

    /// <summary>
    /// Gets the staple option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The staple option for the print task.</returns>
    public static PrintStaple Staple(this PrintTaskOptions printTaskOptions) => Resolver.Staple(printTaskOptions);

    /// <summary>
    /// Sets the staple option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="staple">The staple option for the print task.</param>
    public static void Staple(this PrintTaskOptions printTaskOptions, PrintStaple staple) => Resolver.Staple(printTaskOptions, staple);

    /// <summary>
    /// Retrieves the physical dimensions of the printed page.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="jobPageNumber">The page number.</param>
    /// <returns>The page description data.</returns>
    public static PrintPageDescription GetPageDescriptionWrapped(this PrintTaskOptions printTaskOptions, uint jobPageNumber) => Resolver.GetPageDescription(printTaskOptions, jobPageNumber);

    /// <summary>
    /// Retrieves the physical dimensions and formatting data of a printed page.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="printPageInfo">The formatting data for a given print section.</param>
    /// <returns>The print ticket data for the given page(s), to be sent down the print pipeline.</returns>
    public static IRandomAccessStream GetPagePrintTicketWrapped(this PrintTaskOptions printTaskOptions, PrintPageInfo printPageInfo) => Resolver.GetPagePrintTicket(printTaskOptions, printPageInfo);

    private sealed class DefaultPrintTaskOptionsResolver : IPrintTaskOptionsResolver
    {
        PrintBinding IPrintTaskOptionsResolver.Binding(PrintTaskOptions printTaskOptions) => printTaskOptions.Binding;
        void IPrintTaskOptionsResolver.Binding(PrintTaskOptions printTaskOptions, PrintBinding binding) => printTaskOptions.Binding = binding;
        PrintBordering IPrintTaskOptionsResolver.Bordering(PrintTaskOptions printTaskOptions) => printTaskOptions.Bordering;
        void IPrintTaskOptionsResolver.Bordering(PrintTaskOptions printTaskOptions, PrintBordering bordering) => printTaskOptions.Bordering = bordering;
        PrintCollation IPrintTaskOptionsResolver.Collation(PrintTaskOptions printTaskOptions) => printTaskOptions.Collation;
        void IPrintTaskOptionsResolver.Collation(PrintTaskOptions printTaskOptions, PrintCollation collation) => printTaskOptions.Collation = collation;
        PrintColorMode IPrintTaskOptionsResolver.ColorMode(PrintTaskOptions printTaskOptions) => printTaskOptions.ColorMode;
        void IPrintTaskOptionsResolver.ColorMode(PrintTaskOptions printTaskOptions, PrintColorMode colorMode) => printTaskOptions.ColorMode = colorMode;
        IList<PrintPageRange> IPrintTaskOptionsResolver.CustomPageRanges(PrintTaskOptions printTaskOptions) => printTaskOptions.CustomPageRanges;
        IList<string> IPrintTaskOptionsResolver.DisplayedOptions(PrintTaskOptions printTaskOptions) => printTaskOptions.DisplayedOptions;
        PrintDuplex IPrintTaskOptionsResolver.Duplex(PrintTaskOptions printTaskOptions) => printTaskOptions.Duplex;
        void IPrintTaskOptionsResolver.Duplex(PrintTaskOptions printTaskOptions, PrintDuplex duplex) => printTaskOptions.Duplex = duplex;
        PrintHolePunch IPrintTaskOptionsResolver.HolePunch(PrintTaskOptions printTaskOptions) => printTaskOptions.HolePunch;
        void IPrintTaskOptionsResolver.HolePunch(PrintTaskOptions printTaskOptions, PrintHolePunch holePunch) => printTaskOptions.HolePunch = holePunch;
        uint IPrintTaskOptionsResolver.MaxCopies(PrintTaskOptions printTaskOptions) => printTaskOptions.MaxCopies;
        PrintMediaSize IPrintTaskOptionsResolver.MediaSize(PrintTaskOptions printTaskOptions) => printTaskOptions.MediaSize;
        void IPrintTaskOptionsResolver.MediaSize(PrintTaskOptions printTaskOptions, PrintMediaSize mediaSize) => printTaskOptions.MediaSize = mediaSize;
        PrintMediaType IPrintTaskOptionsResolver.MediaType(PrintTaskOptions printTaskOptions) => printTaskOptions.MediaType;
        void IPrintTaskOptionsResolver.MediaType(PrintTaskOptions printTaskOptions, PrintMediaType mediaType) => printTaskOptions.MediaType = mediaType;
        uint IPrintTaskOptionsResolver.MinCopies(PrintTaskOptions printTaskOptions) => printTaskOptions.MinCopies;
        uint IPrintTaskOptionsResolver.NumberOfCopies(PrintTaskOptions printTaskOptions) => printTaskOptions.NumberOfCopies;
        void IPrintTaskOptionsResolver.NumberOfCopies(PrintTaskOptions printTaskOptions, uint numberOfCopies) => printTaskOptions.NumberOfCopies = numberOfCopies;
        PrintOrientation IPrintTaskOptionsResolver.Orientation(PrintTaskOptions printTaskOptions) => printTaskOptions.Orientation;
        void IPrintTaskOptionsResolver.Orientation(PrintTaskOptions printTaskOptions, PrintOrientation orientation) => printTaskOptions.Orientation = orientation;
        PrintPageRangeOptions IPrintTaskOptionsResolver.PageRangeOptions(PrintTaskOptions printTaskOptions) => printTaskOptions.PageRangeOptions;
        PrintQuality IPrintTaskOptionsResolver.PrintQuality(PrintTaskOptions printTaskOptions) => printTaskOptions.PrintQuality;
        void IPrintTaskOptionsResolver.PrintQuality(PrintTaskOptions printTaskOptions, PrintQuality printQuality) => printTaskOptions.PrintQuality = printQuality;
        PrintStaple IPrintTaskOptionsResolver.Staple(PrintTaskOptions printTaskOptions) => printTaskOptions.Staple;
        void IPrintTaskOptionsResolver.Staple(PrintTaskOptions printTaskOptions, PrintStaple staple) => printTaskOptions.Staple = staple;
        PrintPageDescription IPrintTaskOptionsResolver.GetPageDescription(PrintTaskOptions printTaskOptions, uint jobPageNumber) => printTaskOptions.GetPageDescription(jobPageNumber);
        IRandomAccessStream IPrintTaskOptionsResolver.GetPagePrintTicket(PrintTaskOptions printTaskOptions, PrintPageInfo printPageInfo) => printTaskOptions.GetPagePrintTicket(printPageInfo);
    }
}

/// <summary>
/// Resolves data of the <see cref="PrintTaskOptions"/>.
/// </summary>
public interface IPrintTaskOptionsResolver
{
    /// <summary>
    /// Gets the binding option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The binding option.</returns>
    PrintBinding Binding(PrintTaskOptions printTaskOptions);

    /// <summary>
    /// Sets the binding option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="binding">The binding option.</param>
    void Binding(PrintTaskOptions printTaskOptions, PrintBinding binding);

    /// <summary>
    /// Gets the bordering option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The bordering option.</returns>
    PrintBordering Bordering(PrintTaskOptions printTaskOptions);

    /// <summary>
    /// Sets the bordering option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="bordering">The bordering option.</param>
    void Bordering(PrintTaskOptions printTaskOptions, PrintBordering bordering);

    /// <summary>
    /// Gets the collation option of the print tasks.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The collation option.</returns>
    PrintCollation Collation(PrintTaskOptions printTaskOptions);

    /// <summary>
    /// Sets the collation option of the print tasks.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="collation">The collation option.</param>
    void Collation(PrintTaskOptions printTaskOptions, PrintCollation collation);

    /// <summary>
    /// Gets the color mode option of the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The color mode option.</returns>
    PrintColorMode ColorMode(PrintTaskOptions printTaskOptions);

    /// <summary>
    /// Sets the color mode option of the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="colorMode">The color mode option.</param>
    void ColorMode(PrintTaskOptions printTaskOptions, PrintColorMode colorMode);

    /// <summary>
    /// Gets the custom page range options for the print task.
    /// </summary>
    ///<param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The custom page range options.</returns>
    IList<PrintPageRange> CustomPageRanges(PrintTaskOptions printTaskOptions);

    /// <summary>
    /// Gets the list of options displayed for the print experience.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The list of displayed options.</returns>
    IList<string> DisplayedOptions(PrintTaskOptions printTaskOptions);

    /// <summary>
    /// Gets the duplex option of the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The duplex option.</returns>
    PrintDuplex Duplex(PrintTaskOptions printTaskOptions);

    /// <summary>
    /// Sets the duplex option of the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="duplex">The duplex option.</param>
    void Duplex(PrintTaskOptions printTaskOptions, PrintDuplex duplex);

    /// <summary>
    /// Gets the hole punch option of the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The hole punch option.</returns>
    PrintHolePunch HolePunch(PrintTaskOptions printTaskOptions);

    /// <summary>
    /// Sets the hole punch option of the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="holePunch">The hole punch option.</param>
    void HolePunch(PrintTaskOptions printTaskOptions, PrintHolePunch holePunch);

    /// <summary>
    /// Gets the maximum number of copies supported for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The maximum number of copies.</returns>
    uint MaxCopies(PrintTaskOptions printTaskOptions);

    /// <summary>
    /// Gets the media size option of the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The media size option.</returns>
    PrintMediaSize MediaSize(PrintTaskOptions printTaskOptions);

    /// <summary>
    /// Sets the media size option of the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="mediaSize">The media size option.</param>
    void MediaSize(PrintTaskOptions printTaskOptions, PrintMediaSize mediaSize);

    /// <summary>
    /// Gets the media type option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The media type option.</returns>
    PrintMediaType MediaType(PrintTaskOptions printTaskOptions);

    /// <summary>
    /// Sets the media type option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="mediaType">The media type option.</param>
    void MediaType(PrintTaskOptions printTaskOptions, PrintMediaType mediaType);

    /// <summary>
    /// Gets the minimum number of copies allowed for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The minimum number of copies.</returns>
    uint MinCopies(PrintTaskOptions printTaskOptions);

    /// <summary>
    /// Gets the value for the number of copies for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The value for the number of copies.</returns>
    uint NumberOfCopies(PrintTaskOptions printTaskOptions);

    /// <summary>
    /// Sets the value for the number of copies for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="numberOfCopies">The value for the number of copies.</param>
    void NumberOfCopies(PrintTaskOptions printTaskOptions, uint numberOfCopies);

    /// <summary>
    /// Gets the orientation option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The orientation for the print task.</returns>
    PrintOrientation Orientation(PrintTaskOptions printTaskOptions);

    /// <summary>
    /// Sets the orientation option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="orientation">The orientation for the print task.</param>
    void Orientation(PrintTaskOptions printTaskOptions, PrintOrientation orientation);

    /// <summary>
    /// Gets the page range options for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The page range options.</returns>
    PrintPageRangeOptions PageRangeOptions(PrintTaskOptions printTaskOptions);

    /// <summary>
    /// Gets the print quality option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The print quality for the print task.</returns>
    PrintQuality PrintQuality(PrintTaskOptions printTaskOptions);

    /// <summary>
    /// Sets the print quality option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="printQuality">The print quality for the print task.</param>
    void PrintQuality(PrintTaskOptions printTaskOptions, PrintQuality printQuality);

    /// <summary>
    /// Gets the staple option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <returns>The staple option for the print task.</returns>
    PrintStaple Staple(PrintTaskOptions printTaskOptions);

    /// <summary>
    /// Sets the staple option for the print task.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="staple">The staple option for the print task.</param>
    void Staple(PrintTaskOptions printTaskOptions, PrintStaple staple);

    /// <summary>
    /// Retrieves the physical dimensions of the printed page.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="jobPageNumber">The page number.</param>
    /// <returns>The page description data.</returns>
    PrintPageDescription GetPageDescription(PrintTaskOptions printTaskOptions, uint jobPageNumber);

    /// <summary>
    /// Retrieves the physical dimensions and formatting data of a printed page.
    /// </summary>
    /// <param name="printTaskOptions">The requested <see cref="PrintTaskOptions"/>.</param>
    /// <param name="printPageInfo">The formatting data for a given print section.</param>
    /// <returns>The print ticket data for the given page(s), to be sent down the print pipeline.</returns>
    IRandomAccessStream GetPagePrintTicket(PrintTaskOptions printTaskOptions, PrintPageInfo printPageInfo);
}