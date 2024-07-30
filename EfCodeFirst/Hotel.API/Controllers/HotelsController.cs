﻿using Business.Abstract;
using DataAccess.Abstract;
using EfCodeFirst.Entity;
using Entity.DTOs.Hotel;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService) 
        {
            _hotelService = hotelService;   
        }

        [HttpPost]
        public IActionResult Create([FromBody] HotelCreateRequestDto hotelCreateRequestDto)
        {
            _hotelService.Insert(hotelCreateRequestDto);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update([FromBody] HotelUpdateRequestDto hotelUpdateRequestDto)
        {
            _hotelService.Update(hotelUpdateRequestDto);
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _hotelService.Delete(id);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAll() 
        {
            var hotels = _hotelService.GetAll();
            return Ok(hotels);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var hotel = _hotelService.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        
        }
        [HttpGet("filter")]
        public IActionResult Filter([FromQuery]GetHotelRequestDto filterDto)
        {
            var hotels = _hotelService.Filter(filterDto);
            return Ok(hotels);
        }

    
    
    
    }
}