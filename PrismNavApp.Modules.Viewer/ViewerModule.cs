using Prism.Modularity;
using PrismNavApp.Modules.Viewer.Views;
using PrismNavApp.Modules.Viewer.ViewModels;
using DryIoc;
using Prism.DryIoc;

namespace PrismNavApp.Modules.Viewer
{
    public class ViewerModule : IModule
    {
        private IContainer _container;

        public ViewerModule(IContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<ImageViewerPage, ImageViewerPageViewModel>();
        }
    }
}
