using Hackathon.Foundation.Email.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Hackathon.Foundation.Email
{
    public static class EmailUtil
    {
        public static void SendEmail(Mail _mail)
        {

            MailMessage msg = new MailMessage(new MailAddress(_mail.FromAddress),
                                                    new MailAddress(_mail.ToAddress));
            msg.Subject = _mail.Subject;
            msg.Body = _mail.Body;
            msg.IsBodyHtml = true;

            Sitecore.MainUtil.SendMail(msg);
        }
    }
}