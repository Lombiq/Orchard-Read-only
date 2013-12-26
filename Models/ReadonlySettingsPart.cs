﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.FieldStorage.InfosetStorage;
using Orchard.ContentManagement.Records;

namespace Lombiq.Readonly.Models
{
    public class ReadonlySettingsPart : ContentPart<ReadonlySettingsPartRecord>, IReadonlyAspect
    {
        public bool Readonly
        {
            get { return Record.Readonly; }
            set { Record.Readonly = value; }
        }

        public bool Force
        {
            get { return bool.Parse(this.As<InfosetPart>().Get("ReadonlySettingsPart", "Force") ?? "False"); }
            set { this.As<InfosetPart>().Set("ReadonlySettingsPart", "Force", value.ToString()); }
        }

        public string Message
        {
            get { return Record.Message; }
            set { Record.Message = value; }
        }
    }


    public class ReadonlySettingsPartRecord : ContentPartRecord
    {
        public virtual bool Readonly { get; set; }
        public virtual string Message { get; set; }


        public ReadonlySettingsPartRecord()
        {
            Message = "The site is currently in read-only mode. Please re-send the form in a few minutes.";
        }
    }
}