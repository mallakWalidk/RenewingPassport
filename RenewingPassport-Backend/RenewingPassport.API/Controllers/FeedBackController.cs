using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenewingPassport.Core.Data;
using RenewingPassport.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RenewingPassport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : Controller
    {
        private readonly IFeedBackService _feedBackService;
        public FeedBackController(IFeedBackService feedBackService)
        {
            _feedBackService = feedBackService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<FeedBack>), StatusCodes.Status200OK)]
        [Route("GetAllFeedBack")]
        public List<FeedBack> GetAllFeedBack()
        {
            return _feedBackService.GetAllFeedBack();
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<FeedBack>), StatusCodes.Status200OK)]
        [Route("GetFeedbackById/{id}")]
        public List<FeedBack> GetFeedBackById(int id)
        {
            return _feedBackService.GetFeedBackById(id);
        }
        [HttpDelete]
        [ProducesResponseType(typeof(List<FeedBack>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("DeleteFeedBack/{id}")]
        public bool DeleteFeedBack(int id)
        {
            return _feedBackService.DeleteFeedBack(id);
        }
        [HttpPut]
        [ProducesResponseType(typeof(List<FeedBack>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateFeedback([FromBody] FeedBack feedBack)
        {

            return _feedBackService.UpdateFeedBack(feedBack);
        }
        [HttpPost]
        [ProducesResponseType(typeof(List<FeedBack>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateFeedBack([FromBody] FeedBack feedBack)
        {

            return _feedBackService.CreateFeedBack(feedBack);
        }

    }
}
