using System.Runtime.Serialization;
using Promob.Entities.Enums;
namespace Promob.Entities.ERP
{
    [DataContract]
    public class ERPProduct
    {
        #region Properties
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public string ProductKey { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string PromobVersion { get; set; }
        [DataMember]
        public string ProductType { get; set; }
        [DataMember]
        public bool IsWildcardProduct { get; set; }
        [DataMember]
        public bool IsOptionalCATS { get; set; }
        [DataMember]
        public string WildcardProductKey { get; set; }
        [DataMember]
        public virtual SubGroup SubGroup { get; set; }
        [DataMember]
        public string GroupId { get; set; }
        [DataMember]
        public string Library { get; set; }
        [DataMember]
        public string DeveloperId { get; set; }
        [DataMember]
        public bool? Active { get; set; }
        [DataMember]
        public string ProcadUpdateVersion { get; set; }

        #endregion
    }
}
