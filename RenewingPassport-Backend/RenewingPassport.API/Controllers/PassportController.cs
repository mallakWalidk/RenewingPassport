using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenewingPassport.Core.Data;
using RenewingPassport.Core.DTO;
using RenewingPassport.Core.Service;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;


namespace RenewingPassport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassportController : Controller
    {
        private readonly IPassportService passportService;
        private readonly IUserService userService;

        public PassportController(IPassportService _passportService, IUserService _userService)
        {
            passportService = _passportService;
            userService = _userService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Passport), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreatePassport([FromBody] Passport passport)
        {
            if (passport.Status == "Pending")
            {
                sendEmail(Page_Load(passport.Status, ""), userService.GetUserById(passport.User_Id)[0].User_Email);
            }
            passport.DateOfIssue = DateTime.Now;
            passport.DateOfExpiry = null;

            return passportService.CreatePassport(passport);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Passport), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{id}")]
        public bool DeletePassport(int id)
        {
            return passportService.DeletePassport(id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Passport>), StatusCodes.Status200OK)]
        public List<Passport> GetAllPassport()
        {
            return passportService.GetAllPassport();
        } 
       
     
        [HttpGet]
        [ProducesResponseType(typeof(List<Passport>), StatusCodes.Status200OK)]
        [Route("GetCountRequests")]
        public List<CountRequestsDto> GetCountRequests()
        {
            return passportService.GetCountRequests();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Passport), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetPassportByID/{id}")]
        public List<Passport> GetPassportByID(int id)
        {
            return passportService.GetPassportByID(id);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PassportDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetPassportByStatus")]
        public List<PassportDTO> GetPassportByStatus([FromBody] Passport passport)
        {
            return passportService.GetPassportByStatus(passport);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Passport), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("SearchByEndDate")]
        public List<PassportDTO> SearchByEndDate([FromBody] Passport passport)
        {
            return passportService.SearchByEndDate(passport);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Passport), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("SearchByInterval")]
        public List<PassportDTO> SearchByInterval([FromBody] Passport passport)
        {
            return passportService.SearchByInterval(passport);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Passport), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("SearchByStartDate")]
        public List<PassportDTO> SearchByStartDate([FromBody] Passport passport)
        {
            return passportService.SearchByStartDate(passport);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Passport), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdatePassport([FromBody] PassportRequestDTO passportr)
        {
            Passport passport = new Passport();
            passport.PassId = passportr.PassId;
            passport.Status = passportr.Status;
            passport.Athority = passportr.Athority;
            passport.DateOfIssue = passportr.DateOfIssue;
            passport.DateOfExpiry = passportr.DateOfExpiry;
            passport.User_Id = passportr.User_Id;

            if (passport.Status == "Rejected")
            {
            sendEmail(Page_Load(passportr.Status, passportr.RejectReason), userService.GetUserById(passport.User_Id)[0].User_Email);
                
                passport.DateOfExpiry = DateTime.Now;
                return passportService.UpdatePassport(passport);

            }
            else if (passport.Status == "Approved")
            {
             sendEmail(Page_Load(passportr.Status, ""), userService.GetUserById(passport.User_Id)[0].User_Email);
                
                passport.DateOfExpiry = DateTime.Now;

                passportService.UpdatePassport(passport);

                Passport newPassport = new Passport();
                newPassport = passport;
                newPassport.Status = "UnPaid";
                newPassport.DateOfIssue = DateTime.Now;
                newPassport.DateOfExpiry = null;
                passportService.CreatePassport(newPassport);
                return true; }

            else if (passport.Status == "Renewed") {
                sendEmail(Page_Load2(passport.Status), userService.GetUserById(passport.User_Id)[0].User_Email);

                var oldPassport = passportService.GetExpiredPassport(passport.User_Id);
                passport.DateOfIssue = DateTime.Now;
                passport.DateOfExpiry = DateTime.Now.AddYears(4);
                passportService.UpdatePassport(passport);

                if (oldPassport.Count != 0)
                {
                    var Old = oldPassport[0];
                    Old.Status = "Disabled";
                    return passportService.UpdatePassport(Old);
                }
                else
                    return true;

            }
            else
            {
                return passportService.UpdatePassport(passport); }
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<PassportDTO>), StatusCodes.Status200OK)]
        [Route("GetUserPassport")]
       public List<PassportDTO> GetUserPassport()
        {
            return passportService.GetUserPassport();
        }

        [HttpGet]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [Route("GenerateExpiredPassport")]

        public bool GenerateExpiredPassport()
        {
            var res = passportService.GetExpiredPassport();
            foreach (var passport in res)
            {
                passport.Status = "Expired";
                sendEmail(Page_Load(passport.Status, ""), userService.GetUserById(passport.User_Id)[0].User_Email);  
               passportService.UpdatePassport(passport);
            }
            return true;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PassportDTO>), StatusCodes.Status200OK)]
        [Route("GetRequests")]
        public List<PassportDTO> GetRequests()
        {
            return passportService.GetRequests();
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<ReportDto>), StatusCodes.Status200OK)]
        [Route("GetReportMonthly")]
        public List<ReportDto> GetReportMonthly()
        {
            return passportService.GetReportMonthly();
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<ReportDto>), StatusCodes.Status200OK)]
        [Route("GetReportAnnual")]
        public List<ReportDto> GetReportAnnual()
        {
            return passportService.GetReportAnnual();
        }

        [HttpGet]
        [ProducesResponseType(typeof(Passport), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetPassport/{id}")]

        public PassportDTO GetPassportByUserId(int id)
        {
            return passportService.GetPassportByUserId(id);
        }


        private static string Page_Load2(string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<h1 style='color: blue; text - align:center; '>Your payment succeed </h1>");

            sb.Append("<h1 style='color: blue; text - align:center; '>Your passport " + message + " go to website to download it...</h1>");

            return sb.ToString();
        }
        private static string Page_Load(string message, string reason)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<h1 style='color: blue; text - align:center; '>Your Request " + message + "</h1>");

            if (reason != "")
                sb.Append("<h1 style='color: blue; text - align:center; '>Because " + reason + "</h1>");

            return sb.ToString();
        }

        private static void sendEmail(string body, string email)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                System.Net.NetworkCredential credential =
                    new System.Net.NetworkCredential("RenewingPassport@outlook.com", "Passport12345", "outlook.com");

                client.EnableSsl = true;
                client.Credentials = credential;

                MailMessage message = new MailMessage("RenewingPassport@outlook.com", email);
                message.Subject = "Request Status";

                message.Body = body;
                message.IsBodyHtml = true;
                client.Send(message);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message.ToString());
            }
        }



    }
}