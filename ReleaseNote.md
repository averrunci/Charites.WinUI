# Release Note

## v1.5.0

### Add

- Add the following event args wrappers:
  - XamlShutdownCompletedOnThreadEventArgsWrapper.
  - MapControlMapServiceErrorOccurredEventArgsWrapper.
  - MapElementClickEventArgsWrapper.
- Add the IsBrowserAcceleratorKeyEnabled property to the CoreWebView2AcceleratorKeyPressedEventArgsWrapper class.
- Add the NavigationKind property to the CoreWebView2NavigationStartingEventArgsWrapper class.
- Add the OriginalSourceFrameInfo property to the CoreWebView2NewWindowRequestedEventArgsWrapper class.
- Add the CoreWebView2FrameInfoWrapper class.

### Changes

- Change Microsoft.WindowsAppSDK version to 1.5.240227000.

## v1.4.0

### Add

- Add the following event args wrappers:
  - CoreWebView2LaunchingExternalUriSchemeEventArgsWrapper.
  - ResourceManagerRequestedEventArgsWrapper.
  - DesktopWindowXamlSourceGotFocusEventArgsWrapper.
  - DesktopWindowXamlSourceTakeFocusRequestedEventArgsWrapper.
  - AnnotatedScrollBarDetailLabelRequestedEventArgsWrapper.
  - AnnotatedScrollBarScrollingEventArgsWrapper.
  - ItemCollectionTransitionCompletedEventArgsWrapper.
  - ItemsViewItemInvokedEventArgsWrapper.
  - LinedFlowLayoutItemsInfoRequestedEventArgsWrapper.
  - ScrollingAnchorRequestedEventArgsWrapper.
  - ScrollingBringingIntoViewEventArgsWrapper.
  - ScrollingScrollAnimationStartingEventArgsWrapper.
  - ScrollingScrollCompletedEventArgsWrapper.
  - ScrollingZoomAnimationStartingEventArgsWrapper.
  - ScrollingZoomCompletedEventArgsWrapper.
  - TreeViewSelectionChangedEventArgsWrapper.
- Add the AdditionalObjects property to the CoreWebView2WebMessageReceivedEventArgsWrapper class.

### Changes

- Change Microsoft.WindowsAppSDK vertion to 1.4.230822000.

## v1.3.0

### Add

- Add the CoreWebView2ServerCertificateErrorDetectedEventArgsWrapper class.
- Add the XamlResourceReferenceFailedEventArgs class.
- Add the HttpStatusCode method to the CoreWebView2NavigationCompletedEventArgsWrapper class.
- Add the SavesInProfile method to the CoreWebView2PermissionRequestedEventArgsWrapper class.

### Changes

- Change Microsoft.WindowsAppSDK version to 1.3.230331000.

## v1.2.2

### Bug fix

- Fix an issue that Loading and DataContextChanged events can't be handled on a controller is attached when a name of a root element is specified and a name of its event handler is not specified.

## v1.2.1

### Add

- Add the MediaTransportControlsThumbnailRequestedEventArgsWrapper class.
- Add the IsUserInitiated method to the CoreWebView2NewWindowRequestedEventArgsWrapper class.

## v1.2.0

### Changes

- Change Microsoft.WindowsAppSDK version to 1.2.221109.1
- Change Charites version to 2.2.0.
- Change Charites.Bindings version to 2.2.0.

## v1.1.1

### Changes

- Change the event on which elements and extensions are attached to a controller from the FrameworkElement.Loaded event to the FrameworkElement.Loading event.
- Change to raise the FrameworkElement.DataContextChanged event when elements and extensions are attached to a controller.

## v1.1.0

### Add

- Add the IWinUIElementFinder interface that extends IElementFinder&lt;FrameworkElement&gt; interface.
- Add the ElementFinder property to the WinUIController class.
- Add the following event args wrappers:
  - CoreWebView2BasicAuthenticationRequrestedEventArgsWrapper.
  - CoreWebView2ContextMenuItemWrapper.
  - CoreWebView2ContextMenuRequestedEventArgsWrapper.
  - CoreWebView2ContextMenuTargetWrapper.
- Add the following event args wrapper methods:
  - string SessionId(CoreWebVierw2DevToolsProtocolEventReceivedEventArgs) method in the CoreWebView2DevToolsProtocolEventReceivedEventArgsWrapper class.
  - string AdditionalAllowedFrameAncestors(CoreWebView2NavigationStartingEventArgs) method in the CoreWebView2NavigationStratingEventArgsWrapper class.
  - void AdditionalAllowedFrameAncestors(CoreWebView2NavigationStartingEventArgs, string) method in the CoreWebView2NavigationStratingEventArgsWrapper class.
  - bool Handled(CoreWebView2PermissionRequestedEventArgs) method in the CoreWebView2PermissionRequestedEventArgsWrapper class.
  - void Handled(CoreWebView2PermissionRequestedEventArgs, bool) method in the CoreWebView2PermissionRequestedEventArgsWrapper class.

### Changes

 - Change Microsoft.WindowsAppSDK version to 1.1.1.
 - Change Charites version to 2.1.0.
 - Change the WinUIEventHandlerExtension so that event handlers that have parameters attributed by the following attribute can be injected.
   - FromDIAttribute
   - FromElementAttribute
   - FromDataContextAttribute
