using Infragistics.Windows.OutlookBar;
using Infragistics.Windows.Ribbon;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismBlankOutlook.Modules.Contacts;
using PrismBlankOutlook.Modules.Mail;
using PrismBlankOutLook.Core.Region;
using PrismBlankOutLook.Views;
using System.Windows;

namespace PrismBlankOutLook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MailModule>();
            moduleCatalog.AddModule<ContactsModule>();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(XamOutlookBar), Container.Resolve<XamOutlookBarRegionAdapter>());
            regionAdapterMappings.RegisterMapping(typeof(XamRibbon), Container.Resolve<XamRibbonRegionAdapter>());
        }
    }
}
