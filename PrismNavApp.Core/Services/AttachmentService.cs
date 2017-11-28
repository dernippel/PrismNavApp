namespace PrismNavApp.Core.Services
{
    using System.Diagnostics;

    using Prism.Navigation;

    using PrismNavApp.Core.Interfaces.Services;

    public class AttachmentService:IAttachmentService
    {
        private readonly INavigationService navigationService;

        public AttachmentService(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public async void OpenAttachmentWithViewer(object attachment)
        {
            // ToDo: handle parameter proberbly
            var attachmentType = "image";

            // select correct viewer
            if (attachmentType == "image")
            {
                // navigate to image viewer
                var navParams = new NavigationParameters();
                navParams.Add("object",attachment);
                var navTask = this.navigationService.NavigateAsync(
                    "ImageViewerPage",
                    navParams,
                    useModalNavigation: false);
                await navTask;

                var result = navTask.Status;
                Debug.WriteLine($"Navigation State is {result}");
            }
        }
    }
}