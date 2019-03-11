using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests
{
    [TestClass()]
    public class MailTests
    {
        string Server = @"";
        int Port = 25;
        string From = @"";
        string FromName = "";
        string To = "";
        string ToName = "";
        string[,] ToArray = { { "", "" }, { "", "" }};
        string Cc = "";
        string CcName = "";
        string[,] CcArray = { { "", "" }, { "", "" }};
        string Bcc = "";
        string BccName = "";
        string[,] BccArray = { { "", "" }, { "", "" }};
        string Subject = "";
        string Body = "";
        string Attach = @"";
        string[] AttachArray = {@"", @""};

        [TestMethod()]
        public void SendTest()
        {
            Smtp mail = new Smtp();
            mail.SetServerDetail(Server, Port);
            mail.SetSender(From, FromName);
            mail.SetRecipientTo(To, ToName);
            mail.SetRecipientCc(Cc, CcName);
            mail.SetRecipientBcc(Bcc, BccName);
            mail.SetAttachments(Attach);
            mail.SetMailDetail(Subject, Body);
            mail.SetNotify(System.Net.Mail.DeliveryNotificationOptions.None);
            mail.MailSend();
            mail.Dispose();

            mail = new Smtp();
            mail.SetServerDetail(Server, Port);
            mail.SetSender(From, FromName);
            mail.SetRecipientTo(To, ToName);
            mail.SetMailDetail(Subject, Body);
            mail.MailSend();
            mail.Dispose();
            
            mail = new Smtp();
            mail.SetServerDetail(Server, Port);
            mail.SetSender(From, FromName);
            mail.SetRecipientBcc(Bcc, BccName);
            mail.SetAttachments(Attach);
            mail.SetMailDetail(Subject, Body);
            mail.SetNotify(System.Net.Mail.DeliveryNotificationOptions.None);
            mail.MailSend();
            mail.Dispose();

            Assert.AreEqual(true,true);
        }

        [TestMethod()]
        public void MultiUserSendTest()
        {
            Smtp mail = new Smtp();
            mail.SetServerDetail(Server, Port);
            mail.SetSender(From, FromName);

            int len = ToArray.GetLength(1);

            for (int i = 0; i < ToArray.GetLength(0); i++)
            {           
                mail.SetRecipientTo(ToArray[i,0], ToArray[i, 1]);
            }

            for (int i = 0; i < CcArray.GetLength(0); i++)
            {
                mail.SetRecipientCc(CcArray[i, 0], CcArray[i, 1]);
            }


            mail.SetAttachments(AttachArray);

            mail.SetMailDetail(Subject, Body);
            mail.SetNotify(System.Net.Mail.DeliveryNotificationOptions.None);
            mail.MailSend();
            mail.Dispose();
            Assert.AreEqual(true, true);
        }

    }
}