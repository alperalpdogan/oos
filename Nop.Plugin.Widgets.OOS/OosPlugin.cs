using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Widgets.OOS.Components;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.OOS
{
    public class OosPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ILocalizationService _localizationService;

        public OosPlugin(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

        public Type GetWidgetViewComponent(string widgetZone) => widgetZone == PublicWidgetZones.HeadHtmlTag ? typeof(OosHeaderViewComponent) : typeof(OosViewComponent);

        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(new List<string> { PublicWidgetZones.ProductBoxAddinfoBefore, PublicWidgetZones.ProductDetailsBeforePictures, PublicWidgetZones.HeadHtmlTag });
        }

        public override async Task InstallAsync()
        {
            await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Plugins.Widgets.Oos.OutOfStock"] = "Sold Out",
            });

            await base.InstallAsync();
        }

        public override async Task UninstallAsync()
        {
            await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.Oos");

            await base.UninstallAsync();
        }
        public bool HideInWidgetList => false;
    }
}
