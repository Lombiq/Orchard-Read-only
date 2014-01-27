using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lombiq.Hosting.Readonly.Models;
using Orchard.Data.Migration;

namespace Lombiq.Hosting.Readonly
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            // Only creation of the ReadonlySettingsPartRecord table was here. 

            return 2;
        }

        public int UpdateFrom1()
        {
            SchemaBuilder.DropTable("ReadonlySettingsPartRecord");

            return 2;
        }
    }
}