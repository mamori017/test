using System.Net.Mail;
using System.Text;

namespace Common
{
    public class Smtp
    {
        SmtpClient SmtpClient = new SmtpClient();
        MailMessage MailMessage = new MailMessage();

        public void SetSender(string senderAddress, string senderName = "")
        {
            MailMessage.From = new MailAddress(senderAddress, senderName);
        }

        public void SetRecipientTo(string recipientAddress, string recipientName = "")
        {
            MailMessage.To.Add(new MailAddress(recipientAddress, recipientName));
        }

        public void SetRecipientTo(string[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                MailMessage.To.Add(new MailAddress(array[i, 0], array[i, 1]));
            }
        }

        public void SetRecipientCc(string recipientAddress, string recipientName = "")
        {
            MailMessage.CC.Add(new MailAddress(recipientAddress, recipientName));
        }

        public void SetRecipientCc(string[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                MailMessage.CC.Add(new MailAddress(array[i, 0], array[i, 1]));
            }
        }

        public void SetRecipientBcc(string recipientAddress, string recipientName = "")
        {
            MailMessage.Bcc.Add(new MailAddress(recipientAddress, recipientName));
        }

        public void SetRecipientBcc(string[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                MailMessage.Bcc.Add(new MailAddress(array[i, 0], array[i, 1]));
            }
        }

        public void SetAttachments(string file)
        {
            System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(file);
            MailMessage.Attachments.Add(attachment);
        }

        public void SetAttachments(string[] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(array[i]);
                MailMessage.Attachments.Add(attachment);
            }
        }

        public void SetNotify(DeliveryNotificationOptions options)
        {
            MailMessage.DeliveryNotificationOptions = options;
        }

        public void SetMailDetail(string subject, string body)
        {
            MailMessage.Subject = subject;
            MailMessage.Body = body;
        }

        public void SetEncoding(Encoding encoding)
        {
            MailMessage.SubjectEncoding = encoding;
            MailMessage.BodyEncoding = encoding;
        }

        public void SetTimeout(int timeOut)
        {
            SmtpClient.Timeout = timeOut;
        }

        public void SetServerDetail(string host, int port)
        {
            SmtpClient.Host = host;
            SmtpClient.Port = port;
            SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        public void MailSend()
        {
            SmtpClient.Send(MailMessage);
        }

        public void Dispose()
        {
            MailMessage.Dispose();
            SmtpClient.Dispose();
        }
    }
}