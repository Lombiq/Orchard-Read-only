using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lombiq.Readonly.Models;
using Orchard.Data.Migration;

namespace Lombiq.Readonly
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable(typeof(ReadonlySettingsPartRecord).Name,
                table => table
                    .ContentPartRecord()
                    .Column<bool>("Readonly")
                    .Column<string>("Message", column => column.WithLength(2048))
                );


            return 1;
        }
    }
}