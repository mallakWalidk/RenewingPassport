using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenewingPassport.Core.DTO;
using RenewingPassport.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RenewingPassport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : Controller
    {
        private readonly IChartService _chartService;
       public ChartController(IChartService chartService)       

        {
            _chartService = chartService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<GenderChartDto>), StatusCodes.Status200OK)]
        [Route("GetCountByGender")]
        public List<GenderChartDto> GetCountByGender()
        {
            return _chartService.GetCountPassportByGender();
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<RenewingChartDto>), StatusCodes.Status200OK)]
        [Route("GetCountByDate")]
        public List<RenewingChartDto> GetCountPassportByIssueDate()
        {
            return _chartService.GetCountPassportByIssueDate();
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<RenewingChartDto>), StatusCodes.Status200OK)]
        [Route("GetCountByStatus")]
        public List<StatusChartDto> GetCountPassportByStatus()
        {
            return _chartService.GetCountPassportByStatus();
        }
    }
}
