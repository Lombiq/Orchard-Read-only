using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lombiq.Hosting.Readonly.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Localization;
using Orchard.Settings;

namespace Lombiq.Hosting.Readonly.Drivers
{
    public class ReadonlyDriver : ContentPartDriver<ContentPart>
    {
        private readonly ISiteService _siteService;

        public Localizer T { get; set; }


        public ReadonlyDriver(ISiteService siteService)
        {
            _siteService = siteService;

            T = NullLocalizer.Instance;
        }


        protected override DriverResult Editor(ContentPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            var readonlyPart = _siteService.GetSiteSettings().As<IReadonlyAspect>();
            if (readonlyPart.Readonly && (part.ContentItem.ContentType != "Site" || readonlyPart.Force))
            {
                updater.AddModelError("SiteIsReadonly", T(readonlyPart.Message));
            }

            return null;
        }
    }
}