using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace email_app.Models
{
    public class EmailData
    {
		//private string _MailServer = "smtp.gmail.com";
		//private string _MailUsername = "Tellababatunde@gmail.com";
		//private string _MailPassword = "veemncrlnbjezmur";
		//private string _MailFrom = "Tellababatunde@gmail.com";   
		
		private string _MailServer;
		private string _MailUsername;
		private string _MailPassword;
		private string _MailFrom;
		private string _MailSubject = "";
		private string[] _Recipients;
		private string _Message;
		private bool _IsHTML;
		private string _DisplayName;



		public string MailServer
		{
			get { return _MailServer; }
			set { _MailServer = value; }
		}

		public string MailUsername
		{
			get { return _MailUsername; }
			set { _MailUsername = value; }
		}

		public string MailPassword
		{
			get { return _MailPassword; }
			set { _MailPassword = value; }
		}

		public string MailFrom
		{
			get { return _MailFrom; }
			set { _MailFrom = value; }
		}

		public string MailSubject
		{
			get { return _MailSubject; }
			set { _MailSubject = value; }
		}

		public string[] Recipients
		{
			get { return _Recipients; }
			set { _Recipients = value; }
		}

		public string Message
		{
			get { return _Message; }
			set { _Message = value; }
		}

        public string DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }

        public bool IsHTML
		{
			get { return _IsHTML; }
			set { _IsHTML = value; }
		}

		public int MailPort { get; set; }

		public bool MailSSL { get; set; }
	}
}