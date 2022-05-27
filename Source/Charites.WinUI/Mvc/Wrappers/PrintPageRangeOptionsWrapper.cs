// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Windows.Graphics.Printing;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="PrintPageRangeOptions"/>
/// resolved by <see cref="IPrintPageRangeOptionsResolver"/>.
/// </summary>
public static class PrintPageRangeOptionsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IPrintPageRangeOptionsResolver"/>
    /// that resolves data of the <see cref="PrintPageRangeOptions"/>.
    /// </summary>
    public static IPrintPageRangeOptionsResolver Resolver { get; set; } = new DefaultPrintPageRangeOptionsResolver();

    /// <summary>
    /// Gets the allow all pages option of the print page range.
    /// </summary>
    /// <param name="printPageRangeOptions">The requested <see cref="PrintPageRangeOptions"/>.</param>
    /// <returns>The allow all pages option.</returns>
    public static bool AllowAllPages(this PrintPageRangeOptions printPageRangeOptions) => Resolver.AllowAllPages(printPageRangeOptions);

    /// <summary>
    /// Sets the allow all pages option of the print page range.
    /// </summary>
    /// <param name="printPageRangeOptions">The requested <see cref="PrintPageRangeOptions"/>.</param>
    /// <param name="allowAllPages">The allow all pages option.</param>
    public static void AllowAllPages(this PrintPageRangeOptions printPageRangeOptions, bool allowAllPages) => Resolver.AllowAllPages(printPageRangeOptions, allowAllPages);

    /// <summary>
    /// Gets the allow current page option of the print page range.
    /// </summary>
    /// <param name="printPageRangeOptions">The requested <see cref="PrintPageRangeOptions"/>.</param>
    /// <returns>The allow current page option.</returns>
    public static bool AllowCurrentPage(this PrintPageRangeOptions printPageRangeOptions) => Resolver.AllowCurrentPage(printPageRangeOptions);

    /// <summary>
    /// Sets the allow current page option of the print page range.
    /// </summary>
    /// <param name="printPageRangeOptions">The requested <see cref="PrintPageRangeOptions"/>.</param>
    /// <param name="allowCurrentPage">The allow current page option.</param>
    public static void AllowCurrentPage(this PrintPageRangeOptions printPageRangeOptions, bool allowCurrentPage) => Resolver.AllowCurrentPage(printPageRangeOptions, allowCurrentPage);

    /// <summary>
    /// Gets the allow custom set of pages option for the print page range.
    /// </summary>
    /// <param name="printPageRangeOptions">The requested <see cref="PrintPageRangeOptions"/>.</param>
    /// <returns>The allow custom set of pages option.</returns>
    public static bool AllowCustomSetOfPages(this PrintPageRangeOptions printPageRangeOptions) => Resolver.AllowCustomSetOfPages(printPageRangeOptions);

    /// <summary>
    /// Sets the allow custom set of pages option for the print page range.
    /// </summary>
    /// <param name="printPageRangeOptions">The requested <see cref="PrintPageRangeOptions"/>.</param>
    /// <param name="allowCustomSetOfPages">The allow custom set of pages option.</param>
    public static void AllowCustomSetOfPages(this PrintPageRangeOptions printPageRangeOptions, bool allowCustomSetOfPages) => Resolver.AllowCustomSetOfPages(printPageRangeOptions, allowCustomSetOfPages);

    private sealed class DefaultPrintPageRangeOptionsResolver : IPrintPageRangeOptionsResolver
    {
        bool IPrintPageRangeOptionsResolver.AllowAllPages(PrintPageRangeOptions printPageRangeOptions) => printPageRangeOptions.AllowAllPages;
        void IPrintPageRangeOptionsResolver.AllowAllPages(PrintPageRangeOptions printPageRangeOptions, bool allowAllPages) => printPageRangeOptions.AllowAllPages = allowAllPages;
        bool IPrintPageRangeOptionsResolver.AllowCurrentPage(PrintPageRangeOptions printPageRangeOptions) => printPageRangeOptions.AllowCurrentPage;
        void IPrintPageRangeOptionsResolver.AllowCurrentPage(PrintPageRangeOptions printPageRangeOptions, bool allowCurrentPage) => printPageRangeOptions.AllowCurrentPage = allowCurrentPage;
        bool IPrintPageRangeOptionsResolver.AllowCustomSetOfPages(PrintPageRangeOptions printPageRangeOptions) => printPageRangeOptions.AllowCustomSetOfPages;
        void IPrintPageRangeOptionsResolver.AllowCustomSetOfPages(PrintPageRangeOptions printPageRangeOptions, bool allowCustomSetOfPages) => printPageRangeOptions.AllowCustomSetOfPages = allowCustomSetOfPages;
    }
}

/// <summary>
/// Resolves data of the <see cref="PrintPageRangeOptions"/>.
/// </summary>
public interface IPrintPageRangeOptionsResolver
{
    /// <summary>
    /// Gets the allow all pages option of the print page range.
    /// </summary>
    /// <param name="printPageRangeOptions">The requested <see cref="PrintPageRangeOptions"/>.</param>
    /// <returns>The allow all pages option.</returns>
    bool AllowAllPages(PrintPageRangeOptions printPageRangeOptions);

    /// <summary>
    /// Sets the allow all pages option of the print page range.
    /// </summary>
    /// <param name="printPageRangeOptions">The requested <see cref="PrintPageRangeOptions"/>.</param>
    /// <param name="allowAllPages">The allow all pages option.</param>
    void AllowAllPages(PrintPageRangeOptions printPageRangeOptions, bool allowAllPages);

    /// <summary>
    /// Gets the allow current page option of the print page range.
    /// </summary>
    /// <param name="printPageRangeOptions">The requested <see cref="PrintPageRangeOptions"/>.</param>
    /// <returns>The allow current page option.</returns>
    bool AllowCurrentPage(PrintPageRangeOptions printPageRangeOptions);

    /// <summary>
    /// Sets the allow current page option of the print page range.
    /// </summary>
    /// <param name="printPageRangeOptions">The requested <see cref="PrintPageRangeOptions"/>.</param>
    /// <param name="allowCurrentPage">The allow current page option.</param>
    void AllowCurrentPage(PrintPageRangeOptions printPageRangeOptions, bool allowCurrentPage);

    /// <summary>
    /// Gets the allow custom set of pages option for the print page range.
    /// </summary>
    /// <param name="printPageRangeOptions">The requested <see cref="PrintPageRangeOptions"/>.</param>
    /// <returns>The allow custom set of pages option.</returns>
    bool AllowCustomSetOfPages(PrintPageRangeOptions printPageRangeOptions);

    /// <summary>
    /// Sets the allow custom set of pages option for the print page range.
    /// </summary>
    /// <param name="printPageRangeOptions">The requested <see cref="PrintPageRangeOptions"/>.</param>
    /// <param name="allowCustomSetOfPages">The allow custom set of pages option.</param>
    void AllowCustomSetOfPages(PrintPageRangeOptions printPageRangeOptions, bool allowCustomSetOfPages);
}