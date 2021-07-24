using email_app.Models;
using System.Net;
using System.Net.Mail;
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