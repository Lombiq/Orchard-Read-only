using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lombiq.Hosting.Readonly.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Localization;

namespace Lombiq.Hosting.Readonly.Drivers
{
    public class ReadonlySettingsPartDriver : ContentPartDriver<ReadonlySettingsPart>
    {
        protected override string Prefix
        {
            get { return "Lombiq.Hosting.Readonly.ReadonlySettingsPart"; }
        }


        protected override DriverResult Editor(ReadonlySettingsPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_ReadonlySettings_SiteSettings",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts.ReadonlySettings.SiteSettings",
                    Model: part,
                    Prefix: Prefix));
        }

        protected override DriverResult Editor(ReadonlySettingsPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null); 
            return Editor(part, shapeHelper);
        }
    }
}