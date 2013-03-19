using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Promob.Entities
{
    public class PublicationLibrary
    {
        public int PublicationLibraryId { get; set; }
        public int PublicationId { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Revision { get; set; }
        public virtual Publication Publication { get; set; }
    }
}
