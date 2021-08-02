using email_app.Models;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;

namespace email_app.Controllers
{
    public class HomeController : Controller
    {
		public ActionResult email(EmailData model)
		{
			ViewBag.Message = "Email page";

			return View("email", model);
		}

		[HttpPost]
		public string SendEmail(EmailData info)
        {
			SmtpClient client = new SmtpClient(info.MailServer);
			client.Credentials = new NetworkCredential(info.MailUsername, info.MailPassword);
			client.Port = info.MailPort;
			client.EnableSsl = info.MailSSL;

			MailMessage mail = new MailMessage();
			mail.From = new MailAddress(info.MailFrom, "Email");
			mail.Subject = "Medismarts Email from Server";
			mail.Body = "Email Testing from the Server";

			string[] receivers = info.Recipients;

			try
			{
				for (int i = 0; i < receivers.Length; i++)
				{
					mail.To.Add(receivers[i]);
					//mail.Bcc.Add("maskitq@yahoo.com");
					//mail.CC.Add("uanusionwu@medismarts.com.ng");
				}

				// Not recommended in production. Code to bypass security check
				//ServicePointManager.ServerCertificateValidationCallback =
				//delegate (object s, X509Certificate certificate, X509Chain chain,
				//SslPolicyErrors sslPolicyErrors)
				//{ 
				//	return true;
				//};

				client.Send(mail);
				return "success";
			}
			catch (SmtpException ex)
			{
				string msg = ex.Message;
				return msg;
			}
		}

    }
}