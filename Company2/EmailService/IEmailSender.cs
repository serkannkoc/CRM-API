using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company2.EmailService
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
