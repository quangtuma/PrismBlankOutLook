using Infragistics.Windows.Ribbon;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismBlankOutLook.Core.Region
{
    public class XamRibbonRegionAdapter : RegionAdapterBase<XamRibbon>
    {
        public XamRibbonRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
            
        }

        protected override void Adapt(IRegion region, XamRibbon regionTarget)
        {
            if (region == null) throw new ArgumentNullException(nameof(region));
            if (regionTarget == null) throw new ArgumentNullException(nameof(regionTarget));

            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (var view in e.NewItems)
                    {
                        AddViewRegion(view, regionTarget);
                    }
                }
                else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    foreach (var view in e.OldItems)
                    {
                        RemoveViewRegion(view, regionTarget);
                    }
                }
            };
        }

        static void RemoveViewRegion(object view, XamRibbon regionTarget)
        {
            if (view is RibbonTabItem ribbonTabItem)
            {
                regionTarget.Tabs.Remove(ribbonTabItem);
            }
        }

        static void AddViewRegion(object view, XamRibbon regionTarget)
        {
            if (view is RibbonTabItem ribbonTabItem)
            {
                regionTarget.Tabs.Add(ribbonTabItem);
            }
        }

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }
    }
}
