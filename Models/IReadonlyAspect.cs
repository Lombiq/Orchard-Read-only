using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orchard.ContentManagement;

namespace Lombiq.Readonly.Models
{
    public interface IReadonlyAspect : IContent
    {
        bool Readonly { get; set; }
        bool Force { get; set; }
        string Message { get; set; }
    }
}
