using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HermesChat.Models;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Encodings.Web;

namespace HermesChat.Areas.Identity.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;


        public ForgotPasswordModel(UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string Username { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {
                //var user = await _userManager.FindByEmailAsync(Input.Email);
                var user = _userManager.Users.Where(u => u.UserName == Input.Username).FirstOrDefault();
                if (user == null)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page("ResetPassword", "Account", new { email = user.Email, code = code},protocol: Request.Scheme);
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("hermeschats@gmail.com");
                mailMessage.To.Add(Input.Email);
                mailMessage.Subject = "HermesChat Password";
                mailMessage.Body = string.Format($"To reset your password <a href='{callbackUrl}'>click here</a>.");
                mailMessage.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                NetworkCredential nc = new NetworkCredential();
                smtp.Credentials = nc;
                nc.UserName = "hermeschats@gmail.com";
                nc.Password = "chatApp1";
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(mailMessage);

                
                return RedirectToPage("./ForgotPasswordConfirmation");
            }
            return Page();
        }
        //public void SendPassword(string email, string username)
        //{
        //    MailMessage mailMessage = new MailMessage();
        //    mailMessage.From = new MailAddress("hermeschats@gmail.com");
        //    mailMessage.To.Add(Input.Email);
        //    mailMessage.Subject = "HermesChat Password";
        //    mailMessage.Body = string.Format("Please reset your password...");
        //    mailMessage.IsBodyHtml = true;
        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "smtp.gmail.com";
        //    smtp.Port = 587;         
        //    smtp.EnableSsl = true;
        //    smtp.UseDefaultCredentials = false;
        //    NetworkCredential nc = new NetworkCredential();
        //    smtp.Credentials = nc;
        //    nc.UserName = "hermeschats@gmail.com";
        //    nc.Password = "chatApp1";
        //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

        //    smtp.Send(mailMessage);
        //}
    }
}

