using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vacay.Models;
using vacay.Services;

namespace vacay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripController : ControllerBase
    {
        private readonly TripsServices _tservice;
        public TripController(TripsServices tservice)
        {
            _tservice = tservice;
        }
        [HttpGet]  // GETALL
        public ActionResult<IEnumerable<Trip>> Get()
        {
            try
            {
                return Ok(_tservice.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet("{id}")] // GETBYID
        public ActionResult<Trip> Get(int id)
        {
            try
            {
                return Ok(_tservice.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost] // POST
        public ActionResult<Trip> Create([FromBody] Trip newTrip)
        {
            try
            {
                return Ok(_tservice.Create(newTrip));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")] // PUT
        public ActionResult<Trip> Edit([FromBody] Trip editTrip, int id)
        {
            try
            {
                editTrip.Id = id;
                return Ok(_tservice.Edit(editTrip));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")] // DELETE
        public ActionResult<Trip> Delete(int id)
        {
            try
            {
                return Ok(_tservice.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}