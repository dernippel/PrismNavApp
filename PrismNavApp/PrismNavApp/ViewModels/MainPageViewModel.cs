using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrismNavApp.ViewModels
{
    using PrismNavApp.Core.Interfaces.Services;

    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand NavigateCommand=>new DelegateCommand(this.OnNavigate);

        

        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            
            Title = "Main Page";
        }


        private void OnNavigate()
        {
            this.NavigationService.NavigateAsync("AttachmentsPage", useModalNavigation: false);
        }

    }
}
