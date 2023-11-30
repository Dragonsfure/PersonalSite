using MailKit.Net.Smtp;
using MimeKit;
using PersonalSite.Models;

namespace PersonalSite.Vms {
    public class MailVm {

        public MailVm() {
            IsSended = false;
            Mail = new();
        }

        public MailItem Mail {
            get;
            set;
        }

        /// <summary>
        /// Gets if the Mail got Send or sets it.
        /// </summary>
        public bool IsSended {
            get;
            set;
        }

        internal void SendMail() {
            try {
                var email = new MimeMessage();

                email.From.Add(new MailboxAddress(Mail.Name, Mail.FromMail));
                email.To.Add(new MailboxAddress("Dragon Business", Config.MailAdress));

                email.Subject = Mail.Subject;
                email.Body = new TextPart(MimeKit.Text.TextFormat.Plain) {
                    Text = Mail.Content
                };

                using var smtp = new SmtpClient();
                smtp.Connect(Config.SMTPAdress, 587, false);
                // Note: only needed if the SMTP server requires authentication
                smtp.Authenticate(Config.MailAdress,Config.AppPassword);

                smtp.Send(email);
                smtp.Disconnect(true);

                IsSended = true;
            } catch (Exception) {

            }
        }
    }
}
