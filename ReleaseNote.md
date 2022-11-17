# Release Note

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
