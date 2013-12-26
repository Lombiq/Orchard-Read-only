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

        [OrchardSwitch]
        public bool Force { get; set; } // Use it!


        public ReadonlyCommands(ISiteService siteService)
        {
            _siteService = siteService;
        }


        [CommandName("readonly set")]
        [CommandHelp("readonly set [/Force:true|false]\r\n\t" + "Sets the site to read-only. If Force is specified (defaults to false) the site can only be switched back by commands but not from the admin UI.")]
        [OrchardSwitches("Force")]
        public void SetReadonly()
        {
            var part = _siteService.GetSiteSettings().As<IReadonlyAspect>();
            part.Readonly = true;
            part.Force = Force;

            Context.Output.WriteLine(T("The site is now read-only."));
        }

        [CommandName("readonly reset")]
        [CommandHelp("readonly reset\r\n\t" + "Enables the editing of the site.")]
        public void ResetReadonly()
        {
            var part = _siteService.GetSiteSettings().As<IReadonlyAspect>();
            part.Readonly = false;
            part.Force = false;

            Context.Output.WriteLine(T("The site is not read-only anymore."));
        }

        [CommandName("readonly toggle")]
        [CommandHelp("readonly toggle [/Force:true|false]\r\n\t" + "Toggles the site between the read-only and enabled states. If Force is specified (defaults to false) the site can only be switched back by commands but not from the admin UI.")]
        public void ToggleReadonly()
        {
            if (_siteService.GetSiteSettings().As<IReadonlyAspect>().Readonly) ResetReadonly();
            else SetReadonly();
        }
    }
}