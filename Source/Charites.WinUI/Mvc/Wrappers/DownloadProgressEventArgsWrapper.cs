// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml.Media.Imaging;

namespace Charites.Windows.Mvc.Wrappers;

/// <summary>
/// Provides data of the <see cref="DownloadProgressEventArgs"/>
/// resolved by <see cref="IDownloadProgressEventArgsResolver"/>.
/// </summary>
public static class DownloadProgressEventArgsWrapper
{
    /// <summary>
    /// Gets or sets the <see cref="IDownloadProgressEventArgsResolver"/>
    /// that resolves data of the <see cref="DownloadProgressEventArgs"/>.
    /// </summary>
    public static IDownloadProgressEventArgsResolver Resolver { get; set; } = new DefaultDownloadProgressEventArgsResolver();

    /// <summary>
    /// Gets download progress as a value that is between 0 and 100.
    /// </summary>
    /// <param name="e">The requested <see cref="DownloadProgressEventArgs"/>.</param>
    /// <returns>
    /// The download progress. A value of 0 indicates no progress; 100 indicates that the download is complete.
    /// </returns>
    public static int Progress(this DownloadProgressEventArgs e) => Resolver.Progress(e);

    /// <summary>
    /// Sets download progress as a value that is between 0 and 100.
    /// </summary>
    /// <param name="e">The requested <see cref="DownloadProgressEventArgs"/>.</param>
    /// <param name="progress">
    /// The download progress. A value of 0 indicates no progress; 100 indicates that the download is complete.
    /// </param>
    public static void Progress(this DownloadProgressEventArgs e, int progress) => Resolver.Progress(e, progress);

    private sealed class DefaultDownloadProgressEventArgsResolver : IDownloadProgressEventArgsResolver
    {
        int IDownloadProgressEventArgsResolver.Progress(DownloadProgressEventArgs e) => e.Progress;
        void IDownloadProgressEventArgsResolver.Progress(DownloadProgressEventArgs e, int progress) => e.Progress = progress;
    }
}

/// <summary>
/// Resolves data of the <see cref="DownloadProgressEventArgs"/>.
/// </summary>
public interface IDownloadProgressEventArgsResolver
{
    /// <summary>
    /// Gets download progress as a value that is between 0 and 100.
    /// </summary>
    /// <param name="e">The requested <see cref="DownloadProgressEventArgs"/>.</param>
    /// <returns>
    /// The download progress. A value of 0 indicates no progress; 100 indicates that the download is complete.
    /// </returns>
    int Progress(DownloadProgressEventArgs e);

    /// <summary>
    /// Sets download progress as a value that is between 0 and 100.
    /// </summary>
    /// <param name="e">The requested <see cref="DownloadProgressEventArgs"/>.</param>
    /// <param name="progress">
    /// The download progress. A value of 0 indicates no progress; 100 indicates that the download is complete.
    /// </param>
    void Progress(DownloadProgressEventArgs e, int progress);
}