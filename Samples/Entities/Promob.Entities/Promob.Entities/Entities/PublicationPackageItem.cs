using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Promob.Entities.Enums;

namespace Promob.Entities
{
    public class PublicationPackageItem
    {
        public int PublicationId { get; set; }

        public int ComponentId { get; set; }

        public string ComponentName { get; set; }

        public eComponentType eComponentType { get; set; }

        public bool IsVisibleOnUI { get; set; }

        public string BaseUrl { get; set; }

        public string RelativeUrl { get; set; }

        public string PublicationDescription { get; set; }

        public string PublicationVersion { get; set; }

        public string Lenght { get; set; }

        public string LenghtDescription
        {
            get
            {
                var lenght = long.Parse(this.Lenght);
                if (lenght / 1048576 < 1)
                {
                    lenght = lenght / 1024;
                    return lenght + " Kb";
                }
                else
                {
                    lenght = lenght / 1048576;
                    return lenght + " Mb";
                }
            }
        }

        public DateTime PublicationDate { get; set; }
    }
}
