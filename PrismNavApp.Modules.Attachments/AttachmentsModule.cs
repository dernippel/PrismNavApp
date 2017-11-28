using Prism.Modularity;
using PrismNavApp.Modules.Attachments.Views;
using PrismNavApp.Modules.Attachments.ViewModels;
using DryIoc;
using Prism.DryIoc;

namespace PrismNavApp.Modules.Attachments
{
    public class AttachmentsModule : IModule
    {
        private IContainer _container;

        public AttachmentsModule(IContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<AttachmentsPage, AttachmentsPageViewModel>();
        }
    }
}
