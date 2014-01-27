using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.FieldStorage.InfosetStorage;
using Orchard.ContentManagement.Records;

namespace Lombiq.Hosting.Readonly.Models
{
    public class ReadonlySettingsPart : ContentPart, IReadonlyAspect
    {
        public bool Readonly
        {
            get { return this.Retrieve(x => x.Readonly); }
            set { this.Store(x => x.Readonly, value); }
        }
    
        public bool Force
        {
            get { return this.Retrieve(x => x.Force); }
            set { this.Store(x => x.Force, value); }
        }

        public string Message
        {
            get { return this.Retrieve(x => x.Message, "The site is currently in read-only mode. Please re-send the form in a few minutes."); }
            set { this.Store(x => x.Message, value); }
        }
    }
}