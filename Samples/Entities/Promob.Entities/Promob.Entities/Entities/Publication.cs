using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace Promob.Entities
{
    [DataContract]
    public class Publication
    {
        #region Propierties
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public bool Deleted { get; set; }
        [DataMember]
        public int PublicationId { get; set; }
        [DataMember]
        public string StorageUri { get; set; }
        [DataMember]
        public string StorageRelativeFilesPath { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int ComponentId { get; set; }
        [DataMember]
        public virtual Component Component { get; set; }
        [DataMember]
        public string Version { get; set; }
        [DataMember]
        public string Lenght { get; set; }
        [DataMember]
        public DateTime PublicationDate { get; set; }
        [DataMember]
        public string FilesPathUri
        {
            get
            {
                return this.StorageUri + this.StorageRelativeFilesPath;
            }
        }
        [DataMember]
        public string PackagePathUri
        {
            get
            {
                return this.StorageUri + this.PublicationId;
            }
        }
        [DataMember]
        public virtual ICollection<PublicationLibrary> PublicationLibraries { get; set; }

        #endregion
    }
}
