using Company2.Models;
using Company2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using Company2.EmailService;

namespace Company2.Services
{
    public class PreRegistrationService
    {
        private Company2Context _context;
        private readonly IEmailSender _emailSender;
        public PreRegistrationService(Company2Context context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        public void AddPreRegistration(PreRegistrationVM preRegistration)
        {
            string sSourceData = preRegistration.Email + preRegistration.Ip;
            byte[] tmpSource;
            byte[] tmpHash;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
            //Compute hash based on source data.
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            string hash = "";
            foreach (var item in tmpHash)
            {
                hash += item.ToString();
            }
            var _preRegistration = new PreRegistration()
            {
                Email = preRegistration.Email,
                Ip = preRegistration.Ip,
                Hash = hash,
                EndDate = DateTime.Now.AddDays(7),
                CreatedAt = DateTime.Now,
                UpdatedAt = null,
                DeletedAt = null
            };
            _context.PreRegistrations.Add(_preRegistration);
            _context.SaveChanges();
            var message = new Message(new string[] { preRegistration.Email }, "PreRegistration Hash ", "This is the hash for your registration: " + hash);
            _emailSender.SendEmail(message);
        }
        public List<PreRegistration> getPreRegistrations() => _context.PreRegistrations.ToList();
    }
}
