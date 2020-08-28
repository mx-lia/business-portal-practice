using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IEmailService
    {
        public Task<bool> SendRecoveryPasswordMessage(string token, string email, string subject);
    }
}
