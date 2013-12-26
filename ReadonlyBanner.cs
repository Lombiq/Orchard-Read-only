using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Localization;
using Orchard.Settings;
using Orchard.UI.Admin.Notification;
using Orchard.UI.Notify;
using Orchard.ContentManagement;
using Lombiq.Readonly.Models;

namespace Lombiq.Readonly
{
    public class ReadonlyBanner : INotificationProvider
    {
        private readonly ISiteService _siteService;

        public Localizer T { get; set; }


        public ReadonlyBanner(ISiteService siteService)
        {
            _siteService = siteService;

            T = NullLocalizer.Instance;
        }
        

        public IEnumerable<NotifyEntry> GetNotifications()
        {
            if (_siteService.GetSiteSettings().As<IReadonlyAspect>().Readonly)
            {
                yield return new NotifyEntry { Message = T("The site is currently in read-only mode: no changes can be made and no changes will be preserved. Please wait a few minutes."), Type = NotifyType.Warning };
            }
        }
    }
}