using System;
using System.Globalization;
using Promob.Entities.Enums;

namespace Promob.Entities
{
    public class Mail
    {
        #region Public Properties

        public int MailID { get; set; }

        public int? UserID { get; set; }
        public string UserMail { get; set; }

        public string Subject { get; set; }
        public string CustomHeader { get; set; }
        public string Body { get; set; }
        public string CustomFooter { get; set; }

        public string Template { get; set; }
        public eMailTemplate MailTemplate
        {
            get
            {
                return (eMailTemplate)Enum.Parse(typeof(eMailTemplate), this.Template);
            }
        }

        public DateTime CreationDate { get; set; }
        public DateTime? SentDate { get; set; }
        public bool Sent { get; set; }
                
        public string Culture { get; set; }
        public CultureInfo CultureInfo
        {
            get
            {
                return new CultureInfo(this.Culture);
            }
        }
        
        public string Exception { get; set; }
        public int Tries { get; set; }

        public int Priority { get; set; }
        public eMailPriority MailPriority
        {
            get
            {
                return (eMailPriority)Enum.Parse(typeof(eMailPriority), this.Priority.ToString());
            }
        }

        #endregion

        #region Constructor

        public Mail()
        {
        }

        #endregion
    }
}