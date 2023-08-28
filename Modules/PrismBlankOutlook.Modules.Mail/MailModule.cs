using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismBlankOutlook.Core;
using PrismBlankOutlook.Modules.Mail.Menus;
using PrismBlankOutlook.Modules.Mail.Views;

namespace PrismBlankOutlook.Modules.Mail
{
    public class MailModule : IModule
    {
        private readonly IRegionManager _regionManager;
        public MailModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ViewA));
            _regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(HomeTab));
            _regionManager.RegisterViewWithRegion(RegionNames.OutlookGroupRegion, typeof(MailGroup));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

            //containerRegistry.RegisterSingleton<ViewA, ViewA>();
        }
    }
}