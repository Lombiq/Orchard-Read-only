using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lombiq.Readonly.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace Lombiq.Readonly.Handlers
{
    public class ReadonlySettingsPartHandler : ContentHandler
    {
        public ReadonlySettingsPartHandler(IRepository<ReadonlySettingsPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
            Filters.Add(new ActivatingFilter<ReadonlySettingsPart>("Site"));
        }
    }
}