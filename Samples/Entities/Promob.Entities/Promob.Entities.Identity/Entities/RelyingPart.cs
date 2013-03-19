using System.Resources;

namespace Promob.Entities.Identity
{
    public class RelyingPart
    {
        #region Properties

        public int RelyingPartID { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string ImageRelativeUrl { get; set; }
        public string DescriptionKey { get; set; }
        public string AdditionalInfoKey { get; set; }
       
        #endregion

        #region Constructor

        public RelyingPart()
        {
        }

        #endregion
    }
}