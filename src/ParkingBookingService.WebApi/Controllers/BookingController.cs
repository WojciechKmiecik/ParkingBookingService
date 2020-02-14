using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingBookingService.Dal.Mapper;
using ParkingBookingService.Definition.Services;
using ParkingBookingService.WebApi.WebModels;

namespace ParkingBookingService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status418ImATeapot)] // ;) should be 500        
        public async Task<IActionResult> Post(BookingRequestWebModel bookingRequest)
        {
            if (ValidateRequest(bookingRequest, out string mess))
            {
                return BadRequest($"{nameof(bookingRequest)} {mess}");
            }
            try
            {
                var serviceResponse = await _bookingService.PostNewBooking(bookingRequest.Map());
                return Ok(serviceResponse);
            }
            catch (ArgumentNullException aex)
            {
                // better error handle! 
                return StatusCode(418); // allways - 500

            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
                
            }            
        }
        // it should be FluentValidation or similiar library
        private bool ValidateRequest(BookingRequestWebModel bookingRequest, out string message)
        {
            if (bookingRequest == null)
            {
                message = "Value cannot be null";
                return false;
            }
            if (string.IsNullOrEmpty(bookingRequest.LicencePlate))
            {
                message = "Licence plate cannot be null or empty";
                return false;   
            }
            if (string.IsNullOrEmpty(bookingRequest.GarageName))
            {
                message = "Garage name cannot be null or empty";
                return false;
            }
            message = string.Empty;
            return true;

        }

    }
}