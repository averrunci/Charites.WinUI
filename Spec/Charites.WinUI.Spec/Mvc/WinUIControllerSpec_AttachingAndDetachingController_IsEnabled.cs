// Copyright (C) 2022 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using System.Collections;
using Carna;

namespace Charites.Windows.Mvc;

[Context("Attaches a controller when the IsEnabled property of the WinUIController is set to true")]
class WinUIControllerSpec_AttachingAndDetachingController_IsEnabled : DispatcherContext
{
    TestElement Element { get; set; } = default!;

    [Example("The WinUIController is enabled for the element")]
    [Sample(Source = typeof(IsEnabledSampleDataSource))]
    async Task Ex01(object dataContext, IEnumerable<Type> expectedControllerTypes)
    {
        await RunAsync(() =>
        {
            Given("an element that contains the data context", () => Element = new TestElement { DataContext = dataContext });
            When("the WinUIController is enabled for the element", () => WinUIController.SetIsEnabled(Element, true));
            Then("the controller should be attached to the element", () =>
                WinUIController.GetControllers(Element).Select(controller => controller.GetType()).SequenceEqual(expectedControllerTypes) &&
                WinUIController.GetControllers(Element).Cast<TestWinUIControllers.TestController>().All(controller => controller.DataContext == dataContext)
            );
        });
    }

    class IsEnabledSampleDataSource : ISampleDataSource
    {
        IEnumerable ISampleDataSource.GetData()
        {
            yield return new
            {
                Description = "When the key is the name of the data context type",
                DataContext = new TestDataContexts.AttachingTestDataContext(),
                ExpectedControllerTypes = new[] { typeof(TestWinUIControllers.TestDataContextController) }
            };
            yield return new
            {
                Description = "When the key is the name of the data context base type",
                DataContext = new TestDataContexts.DerivedBaseAttachingTestDataContext(),
                ExpectedControllerTypes = new[] { typeof(TestWinUIControllers.BaseTestDataContextController) }
            };
            yield return new
            {
                Description = "When the key is the full name of the data context type",
                DataContext = new TestDataContexts.AttachingTestDataContextFullName(),
                ExpectedControllerTypes = new[] { typeof(TestWinUIControllers.TestDataContextFullNameController) }
            };
            yield return new
            {
                Description = "When the key is the full name of the data context base type",
                DataContext = new TestDataContexts.DerivedBaseAttachingTestDataContextFullName(),
                ExpectedControllerTypes = new[] { typeof(TestWinUIControllers.BaseTestDataContextFullNameController) }
            };
            yield return new
            {
                Description = "When the key is the name of the data context type that is generic",
                DataContext = new TestDataContexts.GenericAttachingTestDataContext<string>(),
                ExpectedControllerTypes = new[] { typeof(TestWinUIControllers.GenericTestDataContextController) }
            };
            yield return new
            {
                Description = "When the key is the full name of the data context type that is generic",
                DataContext = new TestDataContexts.GenericAttachingTestDataContextFullName<string>(),
                ExpectedControllerTypes = new[] { typeof(TestWinUIControllers.GenericTestDataContextFullNameController), typeof(TestWinUIControllers.GenericTestDataContextFullNameWithoutParametersController) }
            };
            yield return new
            {
                Description = "When the key is the name of the interface implemented by the data context",
                DataContext = new TestDataContexts.InterfaceImplementedAttachingTestDataContext(),
                ExpectedControllerTypes = new[] { typeof(TestWinUIControllers.InterfaceImplementedTestDataContextController) }
            };
            yield return new
            {
                Description = "When the key is the full name of hte interface implemented by the data context",
                DataContext = new TestDataContexts.InterfaceImplementedAttachingTestDataContextFullName(),
                ExpectedControllerTypes = new[] { typeof(TestWinUIControllers.InterfaceImplementedTestDataContextFullNameController) }
            };
        }
    }
}