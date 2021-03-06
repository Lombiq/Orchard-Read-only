﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lombiq.Hosting.Readonly.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace Lombiq.Hosting.Readonly.Handlers
{
    public class ReadonlySettingsPartHandler : ContentHandler
    {
        public ReadonlySettingsPartHandler()
        {
            Filters.Add(new ActivatingFilter<ReadonlySettingsPart>("Site"));
        }
    }
}