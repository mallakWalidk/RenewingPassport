using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenewingPassport.Core.Data;
using RenewingPassport.Core.Service;
using System;
using System.Collections.Generic;
using System.IO;

namespace RenewingPassport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HomepageController : Controller
    {
        private readonly IHomepageService homepageService;

        public HomepageController(IHomepageService homepageService)
        {
            this.homepageService = homepageService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<HomePage>), StatusCodes.Status200OK)]
        public List<HomePage> GetAllHomePage()
        {
            return homepageService.GetAllHomePage();
        }

        [HttpPost]
        [ProducesResponseType(typeof(HomePage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateHomePage(HomePage homepage)
        {
            return homepageService.CreateHomePage(homepage);
        }

        [HttpPut]
        [ProducesResponseType(typeof(HomePage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateHomePage(HomePage homepage)
        {
            return homepageService.UpdateHomePage(homepage);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(HomePage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{id}")]
        public bool DeleteHomePage(int id)
        {
            return homepageService.DeleteHomePage(id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(HomePage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("getbyid/{id}")]
        public HomePage GetHomePageByID(int id)
        {
            return homepageService.GetHomePageByID(id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(HomePage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("getcurrentpage")]
        public HomePage GetCurrentPage()
        {
            return homepageService.GetCurrentPage();
        }

        [Route("UploadImage")]
        [HttpPost]
        public HomePage UploadImage()
        {

            try
            {
                var file = Request.Form.Files[0];
                var fileName = Guid.NewGuid() + "_" + file.FileName;

                var fullPath = Path.Combine("D:\\FinalProjectFront\\FrontEndRenewingPassport\\src\\assets\\images", fileName);

               // var fullPath = Path.Combine("C:\\Users\\Malla\\OneDrive\\Desktop\\FrontEndRenewingPassport-MallakBranch\\FrontEndRenewingPassport-MallakBranch\\FrontEndRenewingPassport\\src\\assets\\images", fileName);
              //  var fullPath = Path.Combine("C:\\Users\\LENOVO\\Desktop\\Training\\11_Final_Project\\Codes\\FrontEndRenewingPassport\\src\\assets\\images", fileName);
                //var fullPath = Path.Combine("C:\\Users\\Malla\\OneDrive\\Desktop\\FrontEndRenewingPassport-MallakBranch\\FrontEndRenewingPassport-MallakBranch\\FrontEndRenewingPassport\\src\\assets\\images", fileName);
                //var fullPath = Path.Combine("C:\\Users\\LENOVO\\Desktop\\Training\\11_Final_Project\\Codes\\FrontEndRenewingPassport\\src\\assets\\images", fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                HomePage item = new HomePage();
                item.ImagePath1 =fileName;

                return item;
            }
            catch (Exception )
            {
                return null;
            }
        }
    }
}
