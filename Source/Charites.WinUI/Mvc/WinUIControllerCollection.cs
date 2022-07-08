// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using Microsoft.UI.Xaml;

namespace Charites.Windows.Mvc;

/// <summary>
/// Represents a collection of controller objects.
/// </summary>
public sealed class WinUIControllerCollection : ControllerCollection<FrameworkElement>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WinUIControllerCollection"/> class
    /// with the specified <see cref="IWinUIDataContextFinder"/>, <see cref="IDataContextInjector"/>,
    /// <see cref="IWinUIElementInjector"/>, and the enumerable of the <see cref="IWinUIControllerExtension"/>.
    /// </summary>
    /// <param name="dataContextFinder">The finder to find a data context.</param>
    /// <param name="dataContextInjector">The injector to inject a data context.</param>
    /// <param name="elementInjector">The injector to inject elements.</param>
    /// <param name="extensions">The extensions for a controller.</param>
    public WinUIControllerCollection(IWinUIDataContextFinder dataContextFinder, IDataContextInjector dataContextInjector, IWinUIElementInjector elementInjector, IEnumerable<IWinUIControllerExtension> extensions) : base(dataContextFinder, dataContextInjector, elementInjector, extensions)
    {
    }

    /// <summary>
    /// Adds the controllers of the specified collection to the end of the <see cref="WinUIControllerCollection"/>.
    /// </summary>
    /// <param name="controllers">
    /// The controllers to add to the end of the<see cref="WinUIControllerCollection"/>.
    /// </param>
    public void AddRange(IEnumerable<object> controllers) => controllers.ForEach(Add);

    /// <summary>
    /// Gets the value that indicates whether the element to which controllers are attached is loaded.
    /// </summary>
    /// <param name="associatedElement">The element to which controllers are attached.</param>
    /// <returns>
    /// <c>true</c> if the element to which controllers are attached is loaded;
    /// otherwise, <c>false</c> is returned.
    /// </returns>
    protected override bool IsAssociatedElementLoaded(FrameworkElement associatedElement) => associatedElement.IsLoaded;

    /// <summary>
    /// Subscribes events of the element to which controllers are attached.
    /// </summary>
    /// <param name="associatedElement">The element to which controllers are attached.</param>
    protected override void SubscribeAssociatedElementEvents(FrameworkElement associatedElement)
    {
        associatedElement.Loading += OnElementLoading;
        associatedElement.Unloaded += OnElementUnloaded;
        associatedElement.DataContextChanged += OnElementDataContextChanged;
    }

    /// <summary>
    /// Unsubscribes events of the element to which controllers are attached.
    /// </summary>
    /// <param name="associatedElement">The element to which controllers are attached.</param>
    protected override void UnsubscribeAssociatedElementEvents(FrameworkElement associatedElement)
    {
        associatedElement.Loading -= OnElementLoading;
        associatedElement.Unloaded -= OnElementUnloaded;
        associatedElement.DataContextChanged -= OnElementDataContextChanged;
    }

    private void OnElementLoading(FrameworkElement? element, object _)
    {
        SetElement(element);
        AttachExtensions();
    }

    private void OnElementUnloaded(object? sender, RoutedEventArgs e)
    {
        Detach();

        if (sender is not FrameworkElement element) return;
        WinUIController.ClearControllers(element);
    }

    private void OnElementDataContextChanged(object? sender, DataContextChangedEventArgs e)
    {
        SetDataContext(e.NewValue);
    }
}