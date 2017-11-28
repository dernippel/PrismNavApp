using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismNavApp.Modules.Attachments.ViewModels
{
    using Prism.Navigation;

    using PrismNavApp.Core.Interfaces.Services;

    public class AttachmentsPageViewModel : BindableBase
	{
	    private readonly INavigationService navigationService;

	    private readonly IAttachmentService attachmentService;

	    public DelegateCommand OpenAttachmentCommand => new DelegateCommand(this.OnOpenAttachment);

        public AttachmentsPageViewModel(INavigationService navigationService,IAttachmentService attachmentService)
        {
            this.navigationService = navigationService;
            this.attachmentService = attachmentService;
        }

	    private void OnOpenAttachment()
	    {
	        // ToDo: get the selected attachment
	        object selectedAttachment = null;

	        // navigating inside a service
	        this.attachmentService.OpenAttachmentWithViewer(selectedAttachment);

            // navigation from view model -- working
            //var navParams = new NavigationParameters();
            //navParams.Add("object", null);
            //this.navigationService.NavigateAsync("ImageViewerPage", navParams, useModalNavigation: false);
        }
    }
}
