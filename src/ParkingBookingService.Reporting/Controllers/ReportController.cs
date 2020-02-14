using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingBookingService.Dal.Mapper;
using ParkingBookingService.Definition.Services;


namespace ParkingBookingService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        //private readonly IReportService _reportService;

        //public ReportController(IReportService reportService)
        //{
        //    _reportService = reportService;
        //}
        [HttpGet("min")]
        public IActionResult GetAverage()
        {
            return Ok("Display AVGvalue, already generated via worker");
        }

        [HttpGet("min")]
        public IActionResult GetMinimal()
        {
            return Ok("Display MAX value, already generated via worker");
        }

    }
}