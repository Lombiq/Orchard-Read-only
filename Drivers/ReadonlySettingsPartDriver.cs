using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lombiq.Readonly.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Localization;

namespace Lombiq.Readonly.Drivers
{
    public class ReadonlySettingsPartDriver : ContentPartDriver<ReadonlySettingsPart>
    {
        protected override string Prefix
        {
            get { return "Lombiq.Readonly.ReadonlySettingsPart"; }
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

        protected override void Exporting(ReadonlySettingsPart part, ExportContentContext context)
        {
            var element = context.Element(part.PartDefinition.Name);

            element.SetAttributeValue("Readonly", part.Readonly);
            element.SetAttributeValue("Message", part.Message);
        }

        protected override void Importing(ReadonlySettingsPart part, ImportContentContext context)
        {
            var partName = part.PartDefinition.Name;

            context.ImportAttribute(partName, "Readonly", value => part.Readonly = bool.Parse(value));
            context.ImportAttribute(partName, "Message", value => part.Message = value);
        }
    }
}