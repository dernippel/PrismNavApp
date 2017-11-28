using PrismNavApp.ViewModels;
using PrismNavApp.Views;
using DryIoc;
using Prism.DryIoc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismNavApp
{
    using Prism.Modularity;

    using PrismNavApp.Core.Interfaces.Services;
    using PrismNavApp.Core.Services;
    using PrismNavApp.Modules.Attachments;
    using PrismNavApp.Modules.Viewer;

    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();

            // register services
            Container.Register<IAttachmentService, AttachmentService>(Reuse.Singleton);
        }

        protected override void ConfigureModuleCatalog()
        {
            var viewerModuleType = typeof(ViewerModule);
            this.ModuleCatalog.AddModule(
                new ModuleInfo()
                    {
                        ModuleName = viewerModuleType.Name,
                        ModuleType = viewerModuleType,
                        InitializationMode = InitializationMode.WhenAvailable
                    });

            var attachmentsModuleType = typeof(AttachmentsModule);
            this.ModuleCatalog.AddModule(
                new ModuleInfo()
                    {
                        ModuleName = attachmentsModuleType.Name,
                        ModuleType = attachmentsModuleType,
                        InitializationMode = InitializationMode.WhenAvailable
                    });
        }
    }
}
