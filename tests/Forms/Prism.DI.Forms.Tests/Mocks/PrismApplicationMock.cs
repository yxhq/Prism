using Prism.DI.Forms.Tests.Mocks.Modules;
using Prism.DI.Forms.Tests.Mocks.Services;
using Prism.DI.Forms.Tests.Mocks.ViewModels;
using Prism.DI.Forms.Tests.Mocks.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation;
using Xamarin.Forms;
using Prism.Mvvm;
using System;
#if DryIoc
using Prism.DryIoc;
using DryIoc;
#elif Unity
using Prism.Unity;
using Unity;
#endif

namespace Prism.DI.Forms.Tests
{
    public class PrismApplicationMock : PrismApplication
    {
        public PrismApplicationMock(IPlatformInitializer platformInitializer)
            : base(platformInitializer, true)
        {
        }

        public PrismApplicationMock(IPlatformInitializer platformInitializer, Func<Page> startPage)
            : this(platformInitializer)
        {
            MainPage = startPage?.Invoke();
        }

        public new INavigationService NavigationService => base.NavigationService;

        public bool Initialized { get; private set; }

        protected override void OnInitialized()
        {
            Initialized = true;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IServiceMock, ServiceMock>();
            containerRegistry.Register<AutowireViewModel>();
            containerRegistry.Register<ViewModelAMock>();
            containerRegistry.Register<ViewModelBMock>(ViewModelBMock.Key);
            containerRegistry.Register<ConstructorArgumentViewModel>();
            containerRegistry.RegisterSingleton<ModuleMock>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ViewMock>("view");
            containerRegistry.RegisterForNavigation<ViewAMock, ViewModelAMock>();
            containerRegistry.RegisterForNavigation<AutowireView, AutowireViewModel>();
            containerRegistry.RegisterForNavigation<ConstructorArgumentView, ConstructorArgumentViewModel>();
            containerRegistry.RegisterForNavigation<XamlViewMock>();
            containerRegistry.RegisterForNavigation<XamlViewMockB, XamlViewMockBViewModel>();
            containerRegistry.RegisterForNavigation<XamlViewMockA, XamlViewMockAViewModel>();

            ViewModelLocationProvider.Register<PartialView, PartialViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule(new ModuleInfo(typeof(ModuleMock))
            {
                InitializationMode = InitializationMode.WhenAvailable,
                ModuleName = "ModuleMock"
            });
        }
    }
}
