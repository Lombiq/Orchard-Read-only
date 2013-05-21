using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Commands;
using Orchard.Settings;
using Orchard.ContentManagement;
using Lombiq.Readonly.Models;

namespace Lombiq.Readonly.Commands
{
    public class ReadonlyCommands : DefaultOrchardCommandHandler
    {
        private readonly ISiteService _siteService;


        public ReadonlyCommands(ISiteService siteService)
        {
            _siteService = siteService;
        }


        [CommandName("readonly set")]
        [CommandHelp("readonly set\r\n\t" + "Sets the site to read-only.")]
        public void SetReadonly()
        {
            _siteService.GetSiteSettings().As<ReadonlySettingsPart>().Readonly = true;
            Context.Output.WriteLine(T("The site is now read-only."));
        }

        [CommandName("readonly reset")]
        [CommandHelp("readonly reset\r\n\t" + "Enables the editing of the site.")]
        public void ResetReadonly()
        {
            _siteService.GetSiteSettings().As<ReadonlySettingsPart>().Readonly = false;
            Context.Output.WriteLine(T("The site is not read-only anymore."));
        }

        [CommandName("readonly toggle")]
        [CommandHelp("readonly toggle\r\n\t" + "Toggles the site between the read-only and enabled states.")]
        public void ToggleReadonly()
        {
            if (_siteService.GetSiteSettings().As<ReadonlySettingsPart>().Readonly) ResetReadonly();
            else SetReadonly();
        }
    }
}