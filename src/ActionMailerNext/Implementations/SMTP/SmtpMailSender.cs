﻿using System.Collections.Generic;

namespace ActionMailerNext.Implementations.SMTP
{
    using System.Net.Mail;
    using System.Threading.Tasks;
    using Interfaces;

    /// <summary>
    ///     Implements IMailSender by using System.Net.MailAttributes.SmtpClient.
    /// </summary>
    public class SmtpMailSender : IMailSender
    {
        private readonly SmtpClient _client;

        /// <summary>
        ///     Creates a new SMTPMailMessage sender based on System.Net.MailAttributes.SmtpClient
        /// </summary>
        public SmtpMailSender() : this(new SmtpClient())
        {
        }

        /// <summary>
        ///     Creates a new SMTPMailMessage sender based on System.Net.MailAttributes.SmtpClient
        /// </summary>
        /// <param name="client">The underlying SmtpClient instance to use.</param>
        public SmtpMailSender(SmtpClient client)
        {
            _client = client;
        }


        /// <summary>
        ///     Sends SMTPMailMessage synchronously.
        /// </summary>
        /// <param name="mailAttributes">The SmtpMailAttributes you wish to send.</param>
        public List<IMailResponse> Send(IMailAttributes mailAttributes)
        {
            var mail = ((SmtpMailAttributes) mailAttributes).GenerateProspectiveMailMessage();
            _client.Send(mail);

            return null;
        }

        /// <summary>
        ///     Sends SMTPMailMessage asynchronously using tasks.
        /// </summary>
        /// <param name="mailAttributes">The IMailAttributes message you wish to send.</param>
        public async Task<List<IMailResponse>> SendAsync(IMailAttributes mailAttributes)
        {
            var mail = ((SmtpMailAttributes) mailAttributes).GenerateProspectiveMailMessage();
            _client.SendMailAsync(mail);

            return null;
        }

        /// <summary>
        ///     Destroys the underlying SmtpClient.
        /// </summary>
        public void Dispose()
        {
            _client.Dispose();
        }
    }
}