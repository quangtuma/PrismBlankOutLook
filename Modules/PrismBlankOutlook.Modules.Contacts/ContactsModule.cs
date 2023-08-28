using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismBlankOutlook.Core;
using PrismBlankOutlook.Modules.Contacts.Menus;
using PrismBlankOutlook.Modules.Contacts.Views;

namespace PrismBlankOutlook.Modules.Contacts
{
    public class ContactsModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ContactsModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.OutlookGroupRegion, typeof(ContactsGroup));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}